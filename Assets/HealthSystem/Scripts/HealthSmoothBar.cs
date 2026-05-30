using UnityEngine;
using UnityEngine.UI;

public class HealthSmoothBar : SliderView
{
    [SerializeField] private float _speed;

    private void Update()
    {
        UpdateView();
    }

    protected override void UpdateView()
    {
        Slider.value = Mathf.MoveTowards(Slider.value, Health.Current, _speed * Time.deltaTime);
    }
}