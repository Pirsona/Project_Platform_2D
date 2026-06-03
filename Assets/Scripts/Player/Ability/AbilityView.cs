using UnityEngine;

public class AbilityView : MonoBehaviour
{
    [SerializeField] private AbilityCast _ability;
    [SerializeField] private GameObject _aura;

    private void Start()
    {
        float diameter = _ability.Radius * 2f;
        _aura.transform.localScale = new Vector3(diameter, diameter, 1f);

        _aura.SetActive(false);
    }

    private void OnEnable()
    {
        _ability.OnStateChanged += ChangeVisability;
    }

    private void OnDisable()
    {
        _ability.OnStateChanged -= ChangeVisability;
    }

    private void ChangeVisability(bool visible)
    {
        _aura.SetActive(visible);
    }
}