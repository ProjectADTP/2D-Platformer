using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    [SerializeField] private CoinSpawner _coinSpawner;

    public bool IsGround { get; private set; }
    public bool IsDead { get; private set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Ground>(out _))
            IsGround = true;

        if (collision.gameObject.TryGetComponent<DeadZone>(out _) || collision.gameObject.TryGetComponent<Enemy>(out _))
            IsDead = true;

        if (collision.gameObject.TryGetComponent<Coin>(out Coin coin))
            _coinSpawner.DestroyCoin(coin);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Ground>(out _))
            IsGround = false;

        if (collision.gameObject.TryGetComponent<DeadZone>(out _) || collision.gameObject.TryGetComponent<Enemy>(out _))
            IsDead = false;
    }
}