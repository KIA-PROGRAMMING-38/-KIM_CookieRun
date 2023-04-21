using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using PlayerAnimationID;

public class RunState : StateMachineBehaviour
{
    
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Cookie 점프
        if(Input.GetKeyDown(KeyCode.W)) 
        {
            animator.SetBool(PlayerAniID.IS_Jumping, true);
        }

        // Cookie 슬라이드
        // 누르고 있을 땐 계속 Slide가 진행되도록 설정한다.
        if(Input.GetKey(KeyCode.S))
        {
            animator.SetBool(PlayerAniID.IS_Slide, true);
            
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}