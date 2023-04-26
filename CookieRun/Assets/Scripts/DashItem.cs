using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DashItem : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.Instance.DashItemCooltime();
        collision.gameObject.GetComponent<PlayerController>().PlayerInvinvibleState();
        gameObject.SetActive(false);
    }

}

