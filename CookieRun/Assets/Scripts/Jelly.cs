using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jelly : MonoBehaviour
{
    private GameManager gameManager;
    [SerializeField] private int _jellyScore;

    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameManager.UpdateScore(_jellyScore);
        gameObject.SetActive(false);
    }
}
