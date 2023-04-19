using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    protected int HP;
    IEnumerator playerHealthDecrease;
    WaitForSeconds waitForSeconds = new WaitForSeconds(1);

    // BraveCookie에서 코루틴을 Start에서 실행하기 때문에, 같이 Start 함수에 작성하면 로직이 꼬이게 된다.
    // 그래서 그런 버그를 방지하기 위해 Awake 함수에 작성한다.
    private void Awake()
    {
        playerHealthDecrease = PlayerHealthDecrease();
    }
    public virtual void PlayerHP()
    {
        HP = 100;
        StartCoroutine(playerHealthDecrease);
    }
    // 코루틴
    // 1초마다 플레이어 체력을 1씩 감소시킨다.
    IEnumerator PlayerHealthDecrease()
    {
        while(HP > 0)
        {
            yield return waitForSeconds;
            HP -= 1;
        }
    }
}
