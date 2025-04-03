using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Mover : MonoBehaviour
{
    private float _moveSpeed = 4f;
    private float _jumpForce = 700f;

    private Rigidbody2D _rigidbody;

    private Vector3 _basePosition;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();

        _basePosition = transform.position;
    }

    public void Jump()
    {
        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, 0);
        _rigidbody.AddForce(new Vector2(0, _jumpForce));
    }

    public void TeleportToStart()
    {
        transform.position = _basePosition;
    }

    public void Move(float direction)
    {
        transform.Translate(new Vector3(direction, 0f, 0f) * _moveSpeed * Time.fixedDeltaTime);
        

    }
}
