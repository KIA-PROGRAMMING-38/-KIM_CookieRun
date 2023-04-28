using Mono.Cecil.Cil;
using PlayerAnimationID;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator animator;
    ParticleSystem DashPartice;

    // �÷��̾� ü�� 1�ʸ��� 1�� ����
    public int HP { get; private set; }
    IEnumerator playerHealthDecrease;
    WaitForSeconds waitForSeconds = new WaitForSeconds(1);

    // �÷��̾� ���� ����
    IEnumerator InvincibleState;
    WaitForSeconds InvicibleWaitForSeconds = new WaitForSeconds(3);
    protected bool hurt;

    // �÷��̾��� �������¸� Alpha�� ���� �˷��ش�.
    IEnumerator Alpha;
    WaitForSeconds AlphaSeconds = new WaitForSeconds(0.1f);
    protected SpriteRenderer _spriteRenderer;
    protected Color _halfAlpha = new Color(1, 1, 1, 0.5f);
    protected Color _fullAlpha = new Color(1, 1, 1, 1);

    // �÷��̾� ü�� ����
    private int _maxHP = 100;
    private int _minHP = 0;

    // �ڼ� ����
    [SerializeField] private MagnetSensor magnetSensor;

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
        DashPartice = GetComponentInChildren<ParticleSystem>();

    }
  
    public virtual void PlayerHP(int Health)
    {
        HP = Health;
        StartCoroutine(playerHealthDecrease);
    }
    public virtual void PlayerTakeDamageState(int damage)
    {
        if (!hurt)
        {
            animator.SetTrigger(PlayerAniID.IS_TakeDamage);

            // �÷��̾ �浹�� �������� ������ � �����̵�, �޸��� ���·� ���ƿ;��Ѵ�.
            animator.SetBool(PlayerAniID.IS_Jumping, false);
            animator.SetBool(PlayerAniID.IS_DobuleJumping, false);
            animator.SetBool(PlayerAniID.IS_Slide, false);
            HP -= damage;
            if (HP <= 0)
            {
                GameManager.Instance.GameOver = true;
                PlayerDeathAnimation(2);
            }
            hurt = true;
            StartCoroutine(InvincibleState);
            StartCoroutine(Alpha);
        }
    }

    // �÷��̾� ���� ����
    public virtual void PlayerInvinvibleState()
    {
        hurt = true;
        animator.SetBool(PlayerAniID.IS_PlayDashRun, true);
        if (hurt)
        {
            StartCoroutine(DashRunCooltime());
        }

    }
    // �÷��̾ ��ֹ��� �浹���� ���� ���¿��� �����.
    public void PlayerDeathAnimation(int number)
    {
        if (HP <= 0)
        {
            // �÷��̾ �״� ��Ȳ�� �ٸ��� ������ �־��� ��Ȳ�� �ٸ��� �����.
            if (number == 1)
            {
                animator.SetTrigger(PlayerAniID.IS_PlayerDeath);
            }
            else if (number == 2)
            {
                animator.SetTrigger(PlayerAniID.IS_PlayCrashDeath);
            }

        }
    }

    // ü�� ����
    public void PlayerIncreaseHP(int healthUP)
    {
        HP += healthUP;
        HP = Mathf.Clamp(HP, _minHP, _maxHP);
    }

    // �ڼ� ������ 
    public void ActiveMagnet()
    {
        magnetSensor.gameObject.SetActive(true);
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
                PlayerDeathAnimation(1);
                GameManager.Instance.GameOver = true;
            }
        }
    }

    // �������� �ڷ�ƾ
    // �ڷ�ƾ ������ while(true)�� �ȿ� ���д�.
    // �׷��� �Ǹ� StopCoroutine�Լ��� yield return null���� ����Ǿ
    // ���� �ڷ�ƾ ȣ�� �� �� while�� ���п� �ٽ� ó�� �� ���� ���ư� �� �ִ�.
    IEnumerator Invincible()
    {
        while (true)
        {
            // ����
            yield return InvicibleWaitForSeconds;
            hurt = false;

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
        while (true)
        {
            // ����
            while (hurt)
            {
                yield return AlphaSeconds;
                _spriteRenderer.color = _halfAlpha;

                yield return AlphaSeconds;
                _spriteRenderer.color = _fullAlpha;
            }

            // �ڷ�ƾ�� �����Ѵ�.
            StopCoroutine(Alpha);

            // StopCoroutine�� ���� �����ӿ��� �����Ѵ�.
            // ���� ������ yield return null�̴�. �̷��� ����������ν�
            // ���� �ڷ�ƾ ������ ��, while�� ������ �ٽ� ���� ��Ų��.
            yield return null;
        }
    }

    IEnumerator DashRunCooltime()
    {
        yield return InvicibleWaitForSeconds;
        DashPartice.Stop();
        animator.SetBool(PlayerAniID.IS_PlayDashRun, false);
        hurt = false;

        StopCoroutine(DashRunCooltime());

        yield return null;
    }
}
