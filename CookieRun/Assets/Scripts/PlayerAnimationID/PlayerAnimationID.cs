using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace PlayerAnimationID
{
    class PlayerAniID
    {
        public static readonly int IS_Jumping = Animator.StringToHash("Cookie_Jump");
        public static readonly int IS_DobuleJumping = Animator.StringToHash("Dobule_Jump");
        public static readonly int IS_Slide = Animator.StringToHash("Cookie_Slide");
        public static readonly int IS_TakeDamage = Animator.StringToHash("Cookie_TakeDamage");
        public static readonly int IS_PlayerDeath = Animator.StringToHash("Cookie_Die");
        public static readonly int IS_PlayCrashDeath = Animator.StringToHash("Cookie_CrashDeath");
    }
}
