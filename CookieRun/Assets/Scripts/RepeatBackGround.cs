using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackGround : MonoBehaviour
{
    
    private Vector2 startPosition;
    private float repeatWidth;
    void Start()
    {
        // ���� ���� ����
        startPosition = transform.position;

        // �ݺ��� ������ ũ�⸦ �����Ѵ�.
        // ��Ȯ�� ������ �Ǵ� �������� �ٽ� �������� ���ư���.
        repeatWidth = GetComponent<BoxCollider2D>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        repeatPosition();
    }
    private void repeatPosition()
    {
        if(transform.position.x < startPosition.x - repeatWidth)
        {
            transform.position = startPosition;
        }
    }
}
