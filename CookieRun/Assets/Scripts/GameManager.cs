using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;
using Unity.VisualScripting;
public class GameManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> _jelly;
    [SerializeField] private TextMeshProUGUI _scoreText;
    private int _score;
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
}
