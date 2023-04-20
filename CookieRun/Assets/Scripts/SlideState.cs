using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideState : StateMachineBehaviour
{
    private BoxCollider2D _boxCollider2D;

    // slide 충돌 범위 및 offset 
    private Vector2 _slideOffset = new Vector2(0f, -0.95f);
    private Vector2 _slideSize = new Vector2(1.1f, 0.675f);
    
    private Vector2 _originColliderSize;
    private Vector2 _originOffset;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _boxCollider2D = animator.GetComponent<BoxCollider2D>();

        // 기본 상태 충돌 범위 및 offset
        _originColliderSize = _boxCollider2D.size;
        _originOffset = _boxCollider2D.offset;

        // slide 충돌 범위 및 offset 
        _boxCollider2D.size = _slideSize;
        _boxCollider2D.offset = _slideOffset;
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // S키를 때면 Slide를 멈추고 다시 달리는 상태로 전환한다.
        if (Input.GetKeyUp(KeyCode.S))
        {
            animator.SetBool("Cookie_Slide", false);
        }

    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // 슬라이드가 끝나면 기본 상태 충돌 범위, offset으로 돌려 놓는다.
        _boxCollider2D.size = _originColliderSize;
        _boxCollider2D.offset = _originOffset;
    }

}
