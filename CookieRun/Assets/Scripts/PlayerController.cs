using Mono.Cecil.Cil;
using PlayerAnimationID;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator animator;

    // �÷��̾� ü�� 1�ʸ��� 1�� ����
    public int HP { get; private set; }
    IEnumerator playerHealthDecrease;
    WaitForSeconds waitForSeconds = new WaitForSeconds(1);

    // �÷��̾� ���� ����
    IEnumerator InvincibleState;
    WaitForSeconds InvicibleWaitForSeconds = new WaitForSeconds(3);
    protected bool _hurt;
    protected bool _invincible;

    // �÷��̾��� �������¸� Alpha�� ���� �˷��ش�.
    IEnumerator Alpha;
    WaitForSeconds AlphaSeconds = new WaitForSeconds(0.1f);
    protected SpriteRenderer _spriteRenderer;
    protected Color _halfAlpha = new Color(1, 1, 1, 0.5f);
    protected Color _fullAlpha = new Color(1, 1, 1, 1);

    // BraveCookie���� �ڷ�ƾ�� Start���� �����ϱ� ������, ���� Start �Լ��� �ۼ��ϸ� ������ ���̰� �ȴ�.
    // �׷��� �׷� ���׸� �����ϱ� ���� Awake �Լ��� �ۼ��Ѵ�.
    // ��� ���� BraveCookie���� Awake�� ������Ʈ�� ���� �޴´ٸ� routine is null �̶�� ������ �߻��Ѵ�.
    // BraveCookie�� Awake���� ������ ������ playerHealthDecrease�� ������ ���ļ� ������ �߻��Ѵ�.
    private void Awake()
    {
        playerHealthDecrease = PlayerHealthDecrease();
        InvincibleState = Invincible();
        Alpha = AlphaBlink();

        _spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

    }
    public virtual void PlayerHP(int Health)
    {
        HP = Health;
        StartCoroutine(playerHealthDecrease);
    }

    public virtual void PlayerTakeDamageState(int damage)
    {
        if (!_hurt)
        {
            HP -= damage;
            if (HP <= 0)
            {
                PlayerDeath(2);
            }
            _hurt = true;
            _invincible = true;
            StartCoroutine(InvincibleState);
            StartCoroutine(Alpha);
        }
    }
    // �÷��̾ ��ֹ��� �浹���� ���� ���¿��� �����.
    public void PlayerDeath(int number)
    {
        if(HP <= 0)
        {
            // �÷��̾ �״� ��Ȳ�� �ٸ��� ������ �־��� ��Ȳ�� �ٸ��� �����.
            if(number == 1)
            {
                animator.SetTrigger(PlayerAniID.IS_PlayerDeath);
            }
            else if (number == 2)
            {
                animator.SetTrigger(PlayerAniID.IS_PlayCrashDeath);
            }
           
        }
    }
    // �ڷ�ƾ
    // 1�ʸ��� �÷��̾� ü���� 1�� ���ҽ�Ų��.
    IEnumerator PlayerHealthDecrease()
    {
        while (HP > 0)
        {
            yield return waitForSeconds;
            HP -= 1;
            if (HP <= 0)
            {
                PlayerDeath(1);
            }
            Debug.Log("-1 ����");
        }
    }

    // �������� �ڷ�ƾ
    // �ڷ�ƾ ������ while(true)�� �ȿ� ���д�.
    // �׷��� �Ǹ� StopCoroutine�Լ��� yield return null���� ����Ǿ
    // ���� �ڷ�ƾ ȣ�� �� �� while�� ���п� �ٽ� ó�� �� ���� ���ư� �� �ִ�.
    IEnumerator Invincible()
    {
        while(true)
        {
            // ����
            yield return InvicibleWaitForSeconds;
            _hurt = false;
            _invincible = false;

            // StopCoroutine�� ���� �����ӿ��� ����ȴ�. �׷��Ƿ� �ؿ� yield return null������ ����ȴ�.
            // ���� yield return null���� ���ٸ� ���� �������� yield return InvicibleWaitForSeconds������ ����ȴ�.
            // �׷��� �Ǹ� ���� �ڷ�ƾ ������ �� _hurt = false���� ���� ���� ����Ǵ� ��Ȳ�� �߻��Ѵ�.
            // �׷��Ƿ� yield return null���� ����ؼ� StopCoroutine���� ���� �� ������ ������ִ� ���̴�.
            StopCoroutine(InvincibleState);

            yield return null;
        }
    }
    // �������¸� Sprite Render�� �˷��ִ� �ڷ�ƾ
    IEnumerator AlphaBlink()
    {
        while(true)
        {
            // ����
            while (_hurt)
            {
                yield return AlphaSeconds;
                _spriteRenderer.color = _halfAlpha;

                yield return AlphaSeconds;
                _spriteRenderer.color = _fullAlpha;
            }
            
            // �ڷ�ƾ�� �����Ѵ�.
            StopCoroutine(Alpha);

            yield return null;
        }
    }
}
