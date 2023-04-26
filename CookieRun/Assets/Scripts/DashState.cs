using PlayerAnimationID;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashState : StateMachineBehaviour
{
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Cookie ����
        if (Input.GetKeyDown(KeyCode.W))
        {
            animator.SetBool("Dash_Jump", true);
        }

        // Cookie �����̵�
        // ������ ���� �� ��� Slide�� ����ǵ��� �����Ѵ�.
        if (Input.GetKey(KeyCode.S))
        {
            animator.SetBool(PlayerAniID.IS_Slide, true);

        }
    }
}
