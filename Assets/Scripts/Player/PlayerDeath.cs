using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class PlayerDeath : MonoBehaviour
{
    private Health _health;

    private void Start()
    {
        _health = GetComponent<Health>();

        _health.Died += PlayDeath;
    }

    private void OnDisable()
    {
        _health.Died -= PlayDeath;
    }

    private void PlayDeath()
    {
        gameObject.SetActive(false);
    }
}
