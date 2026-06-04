using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class AbilityCast : MonoBehaviour
{
    private const int StandartArrayCount = 10;

    [SerializeField] private float _cooldown;
    [SerializeField] private float _radius;
    [SerializeField] private LayerMask _layer;
    [SerializeField] private float _damagePerSecond;
    [SerializeField] private float _duration;

    private bool _isAbilityActive = false;
    private float _elapsed;
    private float _nextAbilityTime;
    private Health _playerHealth;
    private Collider2D[] _hits = new Collider2D[StandartArrayCount];
    private Coroutine _coroutineLaunch;
    private Coroutine _coroutineCooldown;

    public event Action<float> ProgressChanged;
    public event Action<bool> StateAbilityChanged;

    public float CastProgress =>  1f - (_elapsed / _duration);
    public float CooldownProgress => Mathf.Clamp01(1f - ((_nextAbilityTime - Time.time) / _cooldown));
    public float Radius => _radius;

    private void Start()
    {
        _playerHealth = GetComponent<Health>();
    }

    public void Launch()
    {
        if(Time.time >= _nextAbilityTime && _isAbilityActive == false)
        {
           _coroutineLaunch = StartCoroutine(ActivateVampiric());
        }
    }

    private IEnumerator ActivateVampiric()
    {
        _elapsed = 0;

        _isAbilityActive = true;
        StateAbilityChanged?.Invoke(_isAbilityActive);

        while (_elapsed < _duration)
        {
            ProcessVampirism();

            _elapsed += Time.deltaTime;
            ProgressChanged?.Invoke(CastProgress);
            yield return null;
        }

        StopCasting();
    }

    private void StopCasting()
    {
        _nextAbilityTime = Time.time + _cooldown;

        _isAbilityActive = false;
        StateAbilityChanged?.Invoke(_isAbilityActive);

        if (_coroutineLaunch != null)
        {
            StopCoroutine(_coroutineLaunch);
        }

        if (_coroutineCooldown != null)
        {
            StopCoroutine(_coroutineCooldown);
        }


        _coroutineCooldown = StartCoroutine(CooldownRoutine());
    }

    private IEnumerator CooldownRoutine()
    {
        while (Time.time < _nextAbilityTime)
        {
            ProgressChanged?.Invoke(CooldownProgress);
            yield return null;
        }
    }

    private void ProcessVampirism()
    {
        IDamageable closestTarget = FindClosestTarget();

        StealHealth(closestTarget);
    }

    private void StealHealth(IDamageable target)
    {
        if (target != null)
        {
            float stealAmount = _damagePerSecond * Time.deltaTime;
            target.TakeDamage(stealAmount);
            _playerHealth.TakeHeal(stealAmount);
        }
    }

    private IDamageable FindClosestTarget()
    {
        int count = Physics2D.OverlapCircleNonAlloc(transform.position, _radius, _hits, _layer);
        IDamageable target = null;
        float minimumDistance = float.MaxValue;

        for (int i = 0; i < count; i++)
        {
            Collider2D hit = _hits[i];

            if (hit.TryGetComponent(out IDamageable health))
            {
                Vector3 offset = hit.transform.position - transform.position;

                float squaredDistance = offset.sqrMagnitude;

                if (squaredDistance < minimumDistance)
                {
                    minimumDistance = squaredDistance;
                    target = health;
                }
            }
        }

        return target;
    }
}