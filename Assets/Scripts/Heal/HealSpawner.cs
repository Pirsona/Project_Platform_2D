using UnityEngine;

public class HealSpawner : MonoBehaviour
{
    [SerializeField] private int _startCountHeal;
    [SerializeField] private Heal _healthPrefabs;
    [SerializeField] private Transform[] _spawnersPositions;

    private void Start()
    {
        CreateHeal();
    }

    private void CreateHeal()
    {
        Transform[] selectedSpawners = ShuffleArray();

        for (int i = 0; i < _startCountHeal; i++)
        {
            Heal heal = Instantiate(_healthPrefabs, selectedSpawners[i].position, selectedSpawners[i].rotation);
            heal.OnCollected += DestroyHealth;
        }
    }

    private void DestroyHealth(Heal health)
    {
        health.OnCollected -= DestroyHealth;
        Destroy(health.gameObject);
    }

    private Transform[] ShuffleArray()
    {
        Transform[] selected = _spawnersPositions;
        System.Random random = new System.Random();

        for (int i = selected.Length - 1; i >= 1; i--)
        {
            int j = random.Next(i + 1);
            var temp = selected[j];
            selected[j] = selected[i];
            selected[i] = temp;
        }

        return selected;
    }
}
