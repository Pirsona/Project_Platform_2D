using UnityEngine;

public abstract class HealthView : MonoBehaviour
{
    [SerializeField] protected Health Health;

    private void OnEnable()
    {
        Health.ValueChanged += UpdateView;
    }

    private void OnDisable()
    {
        Health.ValueChanged -= UpdateView;
    }

    protected virtual void Start()
    {
        UpdateView();
    }

    protected abstract void UpdateView();
}