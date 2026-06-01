using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class AbilityBar : MonoBehaviour
{
    [SerializeField] private AbilityCast _ability;

    private Slider _slider;  

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    private void Update()
    {
        UpdateView();
    }

    private void UpdateView()
    {
        if(_ability.IsAbilityActive)
        {
            _slider.value = _ability.CastProgress;
        }
        else 
        {
            _slider.value = _ability.CooldownProgress;
        }
    }
}
