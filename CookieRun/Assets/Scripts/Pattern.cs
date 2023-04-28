using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using static System.Collections.Specialized.BitVector32;

public class Pattern : MonoBehaviour
{
    private IObjectPool<Pattern> _patternPool;

    // 모든 젤리를 가져온다.
    Jelly[] jelly;

    private void Awake()
    {
        // Pattern이라는 빈 오브젝트 안에 jelly들이 있기 때문에
        // Children을 사용한다.
        jelly = GetComponentsInChildren<Jelly>();
    }

    private void OnEnable()
    {
        // 모든 젤리들을 다 넣어주고, true 처리한다.
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
