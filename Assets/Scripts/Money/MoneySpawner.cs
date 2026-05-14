using UnityEngine;

public class MoneySpawner : MonoBehaviour
{
    [SerializeField] private int _startCountMoney;  
    [SerializeField] private Money _moneyPrefabs;
    [SerializeField] private Transform[] _spawnersPositions;

    private void OnEnable()
    {
        _moneyPrefabs.OnCollected += DestroyMoney;
    }

    private void OnDisable()
    {
        _moneyPrefabs.OnCollected -= DestroyMoney;
    }


    private void Start()
    {
        CreateMoney();
    }

    private void CreateMoney()
    {
        Transform[] selectedSpawners = ShuffleArray();

        for(int i = 0; i < _startCountMoney; i++)
        {
           Money money =  Instantiate(_moneyPrefabs, selectedSpawners[i].position, selectedSpawners[i].rotation);
            money.OnCollected += DestroyMoney;
        }
    }


    private void DestroyMoney(Money money)
    {
        money.OnCollected -= DestroyMoney;
        Destroy(money.gameObject);
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