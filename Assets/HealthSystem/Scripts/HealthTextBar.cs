using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class HealthTextBar : HealthView
{
    private TextMeshProUGUI _text;

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    protected override void UpdateView()
    {
        _text.text = $"{Health.Current}/{Health.Max}";
    }
}