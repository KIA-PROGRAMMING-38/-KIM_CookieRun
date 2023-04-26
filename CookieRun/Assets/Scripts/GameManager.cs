using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;
using Unity.VisualScripting;
public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    // 젤리 점수
    [SerializeField] private List<GameObject> _jelly;
    [SerializeField] private TextMeshProUGUI _scoreText;

    // 이동 속도
    public float speed = 10f;

    // 오브젝트 풀링
    // [field: SerializeField] public JellyPooler JellyPooler { get; private set; }
    private int _score;

    // Dash시간
    WaitForSeconds waitForSeconds = new WaitForSeconds(3);

    private void Awake()
    {
        var objs = FindObjectsOfType<GameManager>();

        if (objs.Length != 1)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        _score = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateScore(int scoreToAdd)
    {
        _score += scoreToAdd;
        _scoreText.text = "" + _score;
    }

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                var obj = FindObjectOfType<GameManager>();
                if (obj != null)
                {
                    instance = obj;
                }
                else
                {
                    var newObj = new GameObject().AddComponent<GameManager>();
                    instance = newObj;
                }
            }
            return instance;
        }
    }

    public void DashItemCooltime()
    {
        StartCoroutine(DashItemDuration());
    }

    IEnumerator DashItemDuration()
    {
        speed = 20;
        Debug.Log(speed);
        yield return waitForSeconds;
        speed = 10;
        Debug.Log(speed);

        StopCoroutine(DashItemDuration());
        yield return null;
    }
}
