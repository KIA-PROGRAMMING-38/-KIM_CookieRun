using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class RunState : StateMachineBehaviour
{
    
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Cookie ����
        if(Input.GetKeyDown(KeyCode.W)) 
        {
            animator.SetBool("Cookie_Jump", true);
        }

        // Cookie �����̵�
        // ������ ���� �� ��� Slide�� ����ǵ��� �����Ѵ�.
        if(Input.GetKey(KeyCode.S))
        {
            animator.SetBool("Cookie_Slide", true);
            
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

}