using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(Slider))]
public abstract class SliderView : HealthView
{
    protected Slider Slider;

    private void Awake()
    {
        Slider = GetComponent<Slider>();
    }

    protected override void Start()
    {
        Slider.maxValue = Health.Max;
        Slider.value = Health.Current;

        base.Start();
    }
}