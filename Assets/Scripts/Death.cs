using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    private Health _health;

    private void Start()
    {
        _health = GetComponent<Health>();

        _health.OnDied += PlayDeath;
    }

    private void OnDisable()
    {
        _health.OnDied -= PlayDeath;
    }

    private void PlayDeath()
    {
        gameObject.SetActive(false);
    }
}
