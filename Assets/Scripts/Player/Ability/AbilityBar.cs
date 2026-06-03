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

    private void OnEnable()
    {
        _ability.ProgressChanged += UpdateView;
    }

    private void OnDisable()
    {
        _ability.ProgressChanged -= UpdateView;
    }

    private void UpdateView(float value)
    {
        _slider.value = value;
    }
}