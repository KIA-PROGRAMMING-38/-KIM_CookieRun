using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackGround : MonoBehaviour
{
    
    private Vector2 startPosition;
    private float repeatWidth;
    void Start()
    {
        // 시작 지점 저장
        startPosition = transform.position;

        // 반복될 지점에 크기를 저장한다.
        // 정확히 절반이 되는 지점에서 다시 원점으로 돌아간다.
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
