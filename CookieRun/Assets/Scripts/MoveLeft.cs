using PlayerAnimationID;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    // �̵� ����
    private Vector2 leftMove = Vector2.left;

    void Update()
    {
        transform.Translate(leftMove * Time.deltaTime * GameManager.Instance.speed);
    }
}
