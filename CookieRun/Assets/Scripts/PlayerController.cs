using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//��ũ��Ʈ ����
//[System.Serializable]
//public class CookieData
//{
//    public int hp;
//}

//��ũ��Ʈ ����
//public class CookieResourceData
//{
//    public string animationPath;
//}

//��ũ��Ʈ ����

//[CreateAssetMenu(fileName = "Test", menuName = "Test/Test")]
//public class Testsss : ScriptableObject
//{
//    public CookieData data;
//    public CookieResourceData data2;
//}

//public class Cookie
//{
//    CookieData data;

//    public Init(CookieData data, CookieResourceData data2)
//    {
//        this.data = data;
//    }
//}

public class PlayerController : MonoBehaviour
{
    // �÷��̾� ü�� 1�ʸ��� 1�� ����
    protected int HP;
    IEnumerator playerHealthDecrease;
    WaitForSeconds waitForSeconds = new WaitForSeconds(1);

    // �÷��̾� ���� ����
    //IEnumerator InvicibleState;
    WaitForSeconds InvicibleWaitForSeconds = new WaitForSeconds(3);
    protected bool _hurt;
    protected bool _invicible;

    // �÷��̾��� �������¸� Alpha�� ���� �˷��ش�.
    //IEnumerator Alpha;
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
        //InvicibleState = Invicible();
        //Alpha = AlphaBlink();

        _spriteRenderer = GetComponent<SpriteRenderer>();
        //Debug.Log(Resources.Load<Ÿ��>("���");
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
            _hurt = true;
            _invicible = true;
            StartCoroutine(Invicible());
            StartCoroutine(AlphaBlink());
            Debug.Log("���� ����");
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
            Debug.Log("-1 ����");
        }
    }

    // �������� �ڷ�ƾ
    IEnumerator Invicible()
    {
        yield return InvicibleWaitForSeconds;
        _hurt = false;
        _invicible = false;
        Debug.Log("Invicible �ڷ�ƾ");
    }

    // �������¸� Sprite Render�� �˷��ִ� �ڷ�ƾ
    IEnumerator AlphaBlink()
    {
        while (_hurt)
        {
            yield return AlphaSeconds;
            _spriteRenderer.color = _halfAlpha;

            yield return AlphaSeconds;
            _spriteRenderer.color = _fullAlpha;
        }
    }
}
