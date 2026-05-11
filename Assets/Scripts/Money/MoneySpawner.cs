using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneySpawner : MonoBehaviour
{
    [SerializeField] private int _startCountMoney;  
    [SerializeField] private Money _moneyPrefabs;
    [SerializeField] private List<MoneyFactory> _spawners;

    private void Start()
    {
        CreateMoney();
    }

    private void CreateMoney()
    {
        List<MoneyFactory> selectedSpawners = SelectSpawners();

        foreach (var spawner in selectedSpawners)
        {
            spawner.CreateMoney(_moneyPrefabs);
        }
    }

    private List<MoneyFactory> SelectSpawners()
    {
        List<MoneyFactory> selected = new List<MoneyFactory>();

        List<MoneyFactory> tempSelected = new List<MoneyFactory>(_spawners);

        for(int i = 0; i < Mathf.Min(_startCountMoney, _spawners.Count); i++)
        {
            int indexSpawn = Random.Range(0, tempSelected.Count);

            selected.Add(tempSelected[indexSpawn]);
            tempSelected.RemoveAt(indexSpawn);
        }    

        return selected;
    }
}
