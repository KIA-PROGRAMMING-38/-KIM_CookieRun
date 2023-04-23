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
        // 플레이어에 충돌을 감지하고, 충돌 했을 시 데미지를 넘긴다.
        collision.gameObject.GetComponent<PlayerController>().PlayerTakeDamageState(obstaclesDamage);
        Debug.Log("장애물 충돌 처리");
    }
}
