using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyController : MonoBehaviour
{
    private JellyCVS _jellyData;

    private SpriteRenderer _spriteRenderer;
    private CircleCollider2D _circleCollider;

    private Vector2 _initialPosition;

    private void Awake()
    {
        _initialPosition = transform.localPosition;
    }

    private void OnEnable()
    {
        transform.localPosition = _initialPosition;
    }

    public void Activate(JellyKind jellyKind)
    {
        _jellyData = DataManager.Jellies[(int)jellyKind];
        BindData();
    }

    private void BindData()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _circleCollider = GetComponent<CircleCollider2D>();

        string spriteName = $"jelly_{_jellyData.SpriteName}";

        _spriteRenderer.sprite = DataManager.LoadSprite(spriteName);

        ResizeCollider();
    }

    private void ResizeCollider()
    {
        float spriteRadius = _spriteRenderer.bounds.extents.x;
        _circleCollider.radius = spriteRadius;
    }

    private static string PLAYER_TAG = "Player";
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(PLAYER_TAG))
        {
            GameManager.Instance.UpdateScore(_jellyData.Score);
            gameObject.SetActive(false);
        }
    }
}