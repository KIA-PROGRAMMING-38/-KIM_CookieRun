using Mono.Cecil.Cil;
using PlayerAnimationID;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    // 이동 방향
    private Vector2 leftMove = Vector2.left;

    void Update()
    {
        moveLeft();
    }

    public void moveLeft()
    {
        if(GameManager.Instance.GameOver == false)
        {
            transform.Translate(leftMove * Time.deltaTime * GameManager.Instance.speed);
        }
        else if(GameManager.Instance.GameOver == true)
        {
            transform.Translate(leftMove * Time.deltaTime * 0f);
        }
    }
}
