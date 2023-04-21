using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    // 배경 이동 속도
    [SerializeField] private float speed;

    // 배경 이동 방향
    private Vector2 leftMove = Vector2.left;
    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(leftMove * Time.deltaTime * speed);
    }
}
