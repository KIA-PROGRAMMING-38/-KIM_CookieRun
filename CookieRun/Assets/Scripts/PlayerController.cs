using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    protected int HP;
    IEnumerator playerHealthDecrease;
    WaitForSeconds waitForSeconds = new WaitForSeconds(1);

    // BraveCookie���� �ڷ�ƾ�� Start���� �����ϱ� ������, ���� Start �Լ��� �ۼ��ϸ� ������ ���̰� �ȴ�.
    // �׷��� �׷� ���׸� �����ϱ� ���� Awake �Լ��� �ۼ��Ѵ�.
    private void Awake()
    {
        playerHealthDecrease = PlayerHealthDecrease();
    }
    public virtual void PlayerHP()
    {
        HP = 100;
        StartCoroutine(playerHealthDecrease);
    }
    // �ڷ�ƾ
    // 1�ʸ��� �÷��̾� ü���� 1�� ���ҽ�Ų��.
    IEnumerator PlayerHealthDecrease()
    {
        while(HP > 0)
        {
            yield return waitForSeconds;
            HP -= 1;
        }
    }
}
