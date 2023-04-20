using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BraveCookie : MonoBehaviour
{
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            animator.SetBool("Cookie_Jump", false);
            animator.SetBool("Dobule_Jump", false);
        }
        
    }
}
