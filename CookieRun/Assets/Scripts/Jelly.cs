using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Jelly : MonoBehaviour
{
    ObjectPool<Jelly> _pool;
    [SerializeField] private int _jellyScore;
    [SerializeField] private GameObject _player;
    [SerializeField] private float MagnetSpeed = 10f;
    private bool _isFollowing;

    // 자력
    private Vector2 _magnetism;


    private void OnDisable()
    {
        _isFollowing = false;
    }

    // 오브젝트 풀링
    // public void SetPool(ObjectPool<Jelly> pool) => _pool = pool;

    //public void Reset()
    //{
    //    _isFollowing = false;
    //    transform.position = Vector3.zero;
    //    _lookDirection = Vector2.zero;
    //}

    private void Update()
    {
        if (_isFollowing)
        {
            _magnetism = (_player.transform.position - transform.position).normalized;
            transform.Translate(_magnetism * MagnetSpeed * Time.deltaTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            // Player와 충돌했을 때
            GameManager.Instance.UpdateScore(_jellyScore);
            gameObject.SetActive(false);
        }

        if (collision.CompareTag("MagnetRange"))
        {
            _isFollowing = true;
        }

    }
}
