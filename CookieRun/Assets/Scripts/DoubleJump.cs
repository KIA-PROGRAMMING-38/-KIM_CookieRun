using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJump : StateMachineBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private Vector2 _doubleJump = Vector2.up;
    [SerializeField]private float _doubleJumpPower;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _rigidbody2D = animator.GetComponent<Rigidbody2D>();
        _rigidbody2D.AddForce(_doubleJump * _doubleJumpPower, ForceMode2D.Impulse);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

}
