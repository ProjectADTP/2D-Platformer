using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private readonly string Horizontal = "Horizontal";
    private readonly string Vertical = "Vertical";

    [SerializeField] private float _moveSpeed;

    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private SpriteRenderer _sprite;

    private bool _isGrounded = true;

    private float _jumpForce = 5f;
    private bool _jumpRequest;

    private Vector3 _startPosition;

    private void Awake()
    {
        _startPosition = transform.position;

        _sprite = GetComponent<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetAxis(Horizontal) != 0)
        {
            if (Input.GetAxis(Horizontal) < 0)
            {
                _sprite.flipX = false;
            }
            else
            {
                _sprite.flipX = true;
            }

            _animator.SetBool("isMoving", true);

            Move();
        }
        else
        {
            _animator.SetBool("isMoving", false);
        }

        if (Input.GetAxis(Vertical) != 0 && _isGrounded)
        {
            _jumpRequest = true; 
        }
    }

    private void FixedUpdate()
    {
        if (_jumpRequest)
        {
            Jump();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _animator.SetBool("isJumping", false);

        if (collision.collider.TryGetComponent<Ground>(out Ground ground))
        {
            _isGrounded = true;
        }
        else if (collision.collider.TryGetComponent<DeadZone>(out DeadZone deadZone) || collision.collider.TryGetComponent<EnemyPatrol>(out EnemyPatrol enemyPatrol))
        {
            transform.position = _startPosition;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        _jumpRequest = false;
        _isGrounded = false;
    }

    private void Move()
    {
        Vector3 direction = new Vector2(Input.GetAxis(Horizontal), 0f);
        transform.Translate(direction * _moveSpeed * Time.deltaTime);
    }

    private void Jump()
    {
        _animator.SetBool("isJumping", true);
        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpForce);
    }
}
