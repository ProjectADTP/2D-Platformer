using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin _coin;
    [SerializeField] private List<SpawnerPoint> _spawnerPoints;

    private void Start()
    {
        SpawnCoins();
    }

    public void DestroyCoin(Coin coin)
    {
        Destroy(coin.gameObject);
    }

    private void SpawnCoins()
    {
        foreach (SpawnerPoint point in _spawnerPoints)
        {
            Instantiate(_coin, point.transform.position, point.transform.rotation, this.transform);
        }
    }
}
