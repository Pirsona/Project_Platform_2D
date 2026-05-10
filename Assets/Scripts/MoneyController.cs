using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyController : MonoBehaviour
{
    [SerializeField] private int _startCountMoney;  
    [SerializeField] private GameObject _moneyPrefab;
    [SerializeField] private List<MoneySpawner> _spawners;

    private void Start()
    {
        CreateMoney();
    }

    private void CreateMoney()
    {
        List<MoneySpawner> selectedSpawners = SelectSpawners();

        foreach (var spawner in selectedSpawners)
        {
            Instantiate(_moneyPrefab, spawner.transform.position, spawner.transform.rotation);
        }
    }

    private List<MoneySpawner> SelectSpawners()
    {
        List<MoneySpawner> selected = new List<MoneySpawner>();

        List<MoneySpawner> tempSelected = new List<MoneySpawner>(_spawners);

        for(int i = 0; i < Mathf.Min(_startCountMoney, _spawners.Count); i++)
        {
            int indexSpawn = Random.Range(0, tempSelected.Count);

            selected.Add(tempSelected[indexSpawn]);
            tempSelected.RemoveAt(indexSpawn);
        }    

        return selected;
    }
}
