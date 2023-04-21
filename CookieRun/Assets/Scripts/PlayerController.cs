using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//스크립트 생성
//[System.Serializable]
//public class CookieData
//{
//    public int hp;
//}

//스크립트 생성
//public class CookieResourceData
//{
//    public string animationPath;
//}

//스크립트 생성

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
    // 플레이어 체력 1초마다 1씩 감소
    protected int HP;
    IEnumerator playerHealthDecrease;
    WaitForSeconds waitForSeconds = new WaitForSeconds(1);

    // 플레이어 무적 상태
    //IEnumerator InvicibleState;
    WaitForSeconds InvicibleWaitForSeconds = new WaitForSeconds(3);
    protected bool _hurt;
    protected bool _invicible;

    // 플레이어의 무적상태를 Alpha를 통해 알려준다.
    //IEnumerator Alpha;
    WaitForSeconds AlphaSeconds = new WaitForSeconds(0.1f);
    protected SpriteRenderer _spriteRenderer;
    protected Color _halfAlpha = new Color(1, 1, 1, 0.5f);
    protected Color _fullAlpha = new Color(1, 1, 1, 1);

    // BraveCookie에서 코루틴을 Start에서 실행하기 때문에, 같이 Start 함수에 작성하면 로직이 꼬이게 된다.
    // 그래서 그런 버그를 방지하기 위해 Awake 함수에 작성한다.
    // 상속 받은 BraveCookie에서 Awake에 컴포넌트를 참조 받는다면 routine is null 이라는 오류가 발생한다.
    // BraveCookie는 Awake에서 참조를 받으면 playerHealthDecrease와 로직이 겹쳐서 에러가 발생한다.
    private void Awake()
    {
        playerHealthDecrease = PlayerHealthDecrease();
        //InvicibleState = Invicible();
        //Alpha = AlphaBlink();

        _spriteRenderer = GetComponent<SpriteRenderer>();
        //Debug.Log(Resources.Load<타입>("경로");
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
            Debug.Log("무적 상태");
        }
    }
    // 코루틴
    // 1초마다 플레이어 체력을 1씩 감소시킨다.
    IEnumerator PlayerHealthDecrease()
    {
        while (HP > 0)
        {
            yield return waitForSeconds;
            HP -= 1;
            Debug.Log("-1 감소");
        }
    }

    // 무적상태 코루틴
    IEnumerator Invicible()
    {
        yield return InvicibleWaitForSeconds;
        _hurt = false;
        _invicible = false;
        Debug.Log("Invicible 코루틴");
    }

    // 무적상태를 Sprite Render로 알려주는 코루틴
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
