using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class HealthChangerButton : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private float _value;

    private Button _button;

    private void Awake()
    {
     _button = GetComponent<Button>();   
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(ApplyHealthChange);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(ApplyHealthChange);
    }

    private void ApplyHealthChange()
    {
        if (_value >= 0)
        {
            _health.TakeHeal(_value);
        }
        else
        {
            _health.TakeDamage(Mathf.Abs(_value));
        }
    }
}