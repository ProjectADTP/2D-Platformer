using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public event Action<Coin> Taked;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out _))
            Taked?.Invoke(this);
    }
}

