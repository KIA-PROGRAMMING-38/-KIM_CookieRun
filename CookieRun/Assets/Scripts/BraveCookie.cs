using PlayerAnimationID;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BraveCookie : PlayerController
{
    Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
        PlayerHP(20);
        _invincible = false;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerDeath();
    }

    public override void PlayerHP(int Health)
    {
        base.PlayerHP(Health);
    }

    public override void PlayerTakeDamageState(int damage)
    {
        base.PlayerTakeDamageState(10);
    }

    public override void PlayerDeath()
    {
        base.PlayerDeath();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            animator.SetBool(PlayerAniID.IS_Jumping, false);
            animator.SetBool(PlayerAniID.IS_DobuleJumping, false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacles") && !_invincible)
        {
            animator.SetTrigger(PlayerAniID.IS_TakeDamage);
            PlayerTakeDamageState(10);
        }
    }
}
