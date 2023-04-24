using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItem : MonoBehaviour
{
    [SerializeField] private int _healthUP;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameObject.SetActive(false);
        collision.gameObject.GetComponent<PlayerController>().PlayerIncreaseHP(_healthUP);
    }
}
