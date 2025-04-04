using UnityEngine;

public class Player : MonoBehaviour
{
    private CollisionDetector _groundDetector;
    private InputReader _inputReader;
    private Mover _mover;
    private PlayerAnimator _playerAnimator;
    private Teleporter _teleporter;

    private Vector3 _basePosition;

    private void Awake()
    {
        _playerAnimator = GetComponent<PlayerAnimator>();
        _inputReader = GetComponent<InputReader>();
        _mover = GetComponent<Mover>();
        _groundDetector = GetComponent<CollisionDetector>();
        _teleporter = GetComponent<Teleporter>();

        _basePosition = transform.position;
    }

    private void FixedUpdate()
    {
        if (_inputReader.Direction != 0)
            _mover.Move(_inputReader.Direction);

        if (_inputReader.GetIsJump() && _groundDetector.IsGround)
            _mover.Jump();
    }

    private void Update()
    {
        _playerAnimator.SetIsMoving(_inputReader.Direction != 0);
        _playerAnimator.SetIsGrounded(_groundDetector.IsGround);

        if (_groundDetector.IsDead)
            _teleporter.TeleportToStart(_basePosition);
    }
}