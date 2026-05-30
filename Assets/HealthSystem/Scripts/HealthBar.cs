using UnityEngine;
using UnityEngine.UI;

public class HealthBar : SliderView
{
    protected override void UpdateView()
    {
        Slider.value = Health.Current;
    }
}