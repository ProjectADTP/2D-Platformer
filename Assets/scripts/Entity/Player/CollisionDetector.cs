using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    public bool IsGround { get; private set; }
    public bool IsDead { get; private set; }

    private int _enteredCount = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Ground>(out _))
        {
            _enteredCount++;
            IsGround = true;
        }

        if (collision.gameObject.TryGetComponent<DeadZone>(out _) || collision.gameObject.TryGetComponent<Enemy>(out _))
            IsDead = true;

        if (collision.gameObject.TryGetComponent<Coin>(out Coin coin))
            coin.Remove();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Ground>(out _))
            _enteredCount--;

        if (collision.gameObject.TryGetComponent<DeadZone>(out _) || collision.gameObject.TryGetComponent<Enemy>(out _))
            IsDead = false;

        if (_enteredCount <= 0)
        { 
            _enteredCount = 0;
            IsGround = false;
        }
    }
}