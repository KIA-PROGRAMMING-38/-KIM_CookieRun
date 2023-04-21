using PlayerAnimationID;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : StateMachineBehaviour
{
    BraveCookie braveCookie;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        braveCookie = braveCookie.GetComponent<BraveCookie>();
        if (braveCookie.HP <= 0)
        {
            animator.SetTrigger(PlayerAniID.IS_PlayCrashDeath);
        }
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
