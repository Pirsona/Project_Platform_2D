using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class AbilityCast : MonoBehaviour
{
    [SerializeField] private float _cooldown;
    [SerializeField] private float _radius;
    [SerializeField] private LayerMask _layer;
    [SerializeField] private GameObject _vampireAura;
    [SerializeField] private float _damagePerSecond;
    [SerializeField] private float _duration;

    private bool _isAbilityActive = false;
    private float _elapsed;
    private float _nextAbilityTime;
    private Health _playerHealth;

    public bool IsAbilityActive => _isAbilityActive;
    public float CastProgress =>  1f - (_elapsed / _duration);
    public float CooldownProgress => Mathf.Clamp01(1f - ((_nextAbilityTime - Time.time) / _cooldown));

    private void Start()
    {
        _playerHealth = GetComponent<Health>();

        float diameter = _radius * 2f;
        _vampireAura.transform.localScale = new Vector3(diameter, diameter, 1f);
        _vampireAura.SetActive(false);
    }

    public void Launch()
    {
        if(Time.time >= _nextAbilityTime && _isAbilityActive == false)
        {
            StartCoroutine(VampiricActivate());
        }
    }

    IEnumerator VampiricActivate()
    {
        _elapsed = 0;

        _isAbilityActive = true;
        _vampireAura.SetActive(true);

        while (_elapsed < _duration)
        {
            VampiricDamage();

            _elapsed += Time.deltaTime;

            yield return null;
        }

        _vampireAura.SetActive(false);
        _nextAbilityTime = Time.time + _cooldown;
        _isAbilityActive = false;
    }


    private void VampiricDamage()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, _radius, _layer);

        Health closestTarget = null;
        float minimumDistance = float.MaxValue;

        foreach (Collider2D hit in hits)
        {
            if (hit.TryGetComponent(out Health health))
            {
                Vector3 offset = hit.transform.position - transform.position;

                float squaredDistance = offset.sqrMagnitude;

                if (squaredDistance < minimumDistance)
                {
                    minimumDistance = squaredDistance;
                    closestTarget = health;
                }
            }
        }

        if (closestTarget != null)
        {
            float stealAmount = _damagePerSecond * Time.deltaTime;
            closestTarget.TakeDamage(stealAmount);
            _playerHealth.TakeHeal(stealAmount);
        }
    }
}