using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    // ��� �̵� �ӵ�
    [SerializeField] private float speed;

    // ��� �̵� ����
    private Vector2 leftMove = Vector2.left;
    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(leftMove * Time.deltaTime * speed);
    }
}
