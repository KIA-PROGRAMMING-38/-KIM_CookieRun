using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    private int obstaclesDamage = 10;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        // �÷��̾ �浹�� �����ϰ�, �浹 ���� �� �������� �ѱ��.
        collision.gameObject.GetComponent<PlayerController>().PlayerTakeDamageState(obstaclesDamage);
        Debug.Log("��ֹ� �浹 ó��");
    }
}
