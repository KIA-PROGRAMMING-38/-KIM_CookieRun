using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using static System.Collections.Specialized.BitVector32;

public class Pattern : MonoBehaviour
{
    private IObjectPool<Pattern> _patternPool;

    // ��� ������ �����´�.
    Jelly[] jelly;

    private void Awake()
    {
        // Pattern�̶�� �� ������Ʈ �ȿ� jelly���� �ֱ� ������
        // Children�� ����Ѵ�.
        jelly = GetComponentsInChildren<Jelly>();
    }

    private void OnEnable()
    {
        // ��� �������� �� �־��ְ�, true ó���Ѵ�.
        foreach ( var jellyEnable in jelly)
        {
            jellyEnable.gameObject.SetActive(true);
        }
    }

    public void SetManagedPool(IObjectPool<Pattern> pool)
    {
        _patternPool = pool;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Range"))
        {
            DestroyPattern();
        }
    }
    public void DestroyPattern()
    {
        _patternPool.Release(this);

    }

}
