using PlayerAnimationID;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{

    // 이동 방향
    private Vector2 leftMove = Vector2.left;

    // 이동 속도 증가
    private float speedUP = 0.2f;

    IEnumerator DashItemCooltime;
    WaitForSeconds waitForSeconds = new WaitForSeconds(3);

    private void Awake()
    {
        DashItemCooltime = DashItemDuration();
    }

    void Start()
    {

    }

    void Update()
    {
        transform.Translate(leftMove * Time.deltaTime * GameManager.Instance.speed);

        if (GameManager.Instance._dashSpeed)
        {
            StartCoroutine(DashItemDuration());
        }
    }

    IEnumerator DashItemDuration()
    {
        while (GameManager.Instance._dashSpeed)
        {
            transform.Translate(leftMove * Time.timeScale * speedUP);
            yield return waitForSeconds;
            GameManager.Instance._dashSpeed = false;

            StopCoroutine(DashItemCooltime);
            yield return null;
        }
    }
}
