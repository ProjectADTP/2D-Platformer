using UnityEngine;

public class Player : MonoBehaviour
{
    private CollisionDetector _groundDetector;
    private InputReader _inputReader;
    private Mover _mover;
    private PlayerAnimator _playerAnimator;

    private void Awake()
    {
        _playerAnimator = GetComponent<PlayerAnimator>();
        _inputReader = GetComponent<InputReader>();
        _mover = GetComponent<Mover>();
        _groundDetector = GetComponent<CollisionDetector>();
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
        _playerAnimator.Setup(_inputReader.Direction != 0 ? true : false, _groundDetector.IsGround);

        if (_groundDetector.IsDead)
        {
            _mover.TeleportToStart();
        }
    }
}


