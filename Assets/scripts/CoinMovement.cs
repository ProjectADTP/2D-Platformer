using UnityEngine;

public class CoinMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 4f; 
    [SerializeField] private float _distance = 0.25f;

    private Vector3 _startPosition;
    private float _timer;

    private void Awake()
    {
        _startPosition = transform.position; 
    }

    private void Update()
    {
        _timer += Time.deltaTime * _speed;
        
        float newYposition = Mathf.Sin(_timer) * _distance; 
        transform.position = _startPosition + new Vector3(0, newYposition, 0); 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<PlayerMovement>(out PlayerMovement player))
        {
            Destroy(gameObject);
        }
    }
}
