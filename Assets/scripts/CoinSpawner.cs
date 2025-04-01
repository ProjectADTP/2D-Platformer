using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private CoinMovement _coin;
    [SerializeField] private List<SpawnerPoint> _spawnerPoints;

    private void Start()
    {
        SpawnCoins();
    }

    private void SpawnCoins()
    {
        foreach (SpawnerPoint point in _spawnerPoints)
        {
            Instantiate(_coin, point.transform.position, point.transform.rotation, this.transform);
        }
    }
}
