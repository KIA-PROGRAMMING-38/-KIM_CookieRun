using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jelly : MonoBehaviour
{
    [SerializeField] private int _jellyScore;

    private void Start()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.Instance.UpdateScore(_jellyScore);
        gameObject.SetActive(false);
    }
}
