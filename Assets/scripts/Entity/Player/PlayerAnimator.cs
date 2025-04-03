using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void Setup(bool isMoving, bool isGrounded) 
    {
        _animator.SetBool(PlayerAnimatorData.Params.IsMoving, isMoving);
        _animator.SetBool(PlayerAnimatorData.Params.IsGrounded, isGrounded);
    }

}