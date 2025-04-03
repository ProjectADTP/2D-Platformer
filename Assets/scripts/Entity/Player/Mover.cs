using UnityEngine;

public class Mover : MonoBehaviour
{
    private float _moveSpeed = 4f;
    private float _jumpForce = 700f;

    private Rigidbody2D _rigidbody;

    private Vector3 _baseScale;
    private Vector3 _basePosition;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();

        _baseScale = transform.localScale;
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
        transform.Translate(new Vector3(direction, 0f) * _moveSpeed * Time.fixedDeltaTime);
        
        SetupRotation(direction);
    }

    private void SetupRotation(float directional)
    {
        if (directional > 0)
        {
            transform.localScale = _baseScale;
        }
        else
        {
            transform.localScale = new Vector3(-_baseScale.x, _baseScale.y, _baseScale.z);
        }
    }
}
