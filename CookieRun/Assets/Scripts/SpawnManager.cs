using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private float _spwanInterval = 1f;
    [SerializeField] private float _initialDelay = 1f;
    WaitForSeconds _initialDelayWaitForSeconds;
    WaitForSeconds _spwanIntervalWaitForSeconds;

    [SerializeField]private Transform _spwanPosition;

    private IObjectPool<Pattern> _pool;

    [SerializeField] private GameObject[] _patternPrefabs;
    private int index;

    private void Awake()
    {
        _pool = new ObjectPool<Pattern>(CreateParttern, OnGetPattern, OnReleasePattern,
            OnDestroyPattern, maxSize: 5);
    }

    private void Start()
    {
        _initialDelayWaitForSeconds = new WaitForSeconds(_initialDelay);
        _spwanIntervalWaitForSeconds = new WaitForSeconds(_spwanInterval);

        StartCoroutine(SpawnPatternRoutine());
    }

    // 게임이 종료 되는 순간까지 Pattern을 생성해야한다.
    public Pattern SpwanPattern()
    {
        Pattern pattern = _pool.Get();
        pattern.transform.position = _spwanPosition.position;
        return pattern;
    }

    private Pattern CreateParttern()
    {
        index = Random.Range(0, _patternPrefabs.Length);
        Pattern pattern = Instantiate(_patternPrefabs[index]).GetComponent<Pattern>();
        pattern.SetManagedPool(_pool);
        return pattern;
    }

    void OnGetPattern(Pattern pattern)
    {
        pattern.gameObject.SetActive(true);
    }

    void OnReleasePattern(Pattern pattern)
    {
        pattern.gameObject.SetActive(false);
    }

    void OnDestroyPattern(Pattern pattern)
    {
        Destroy(pattern.gameObject);
    }
    private IEnumerator SpawnPatternRoutine()
    {
        yield return _initialDelayWaitForSeconds;

        while (true)
        {
            SpwanPattern();
            yield return _spwanIntervalWaitForSeconds;
        }
    }
}
