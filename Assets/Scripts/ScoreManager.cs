using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    private static int _score = 0;
    [SerializeField]
    private TextMeshProUGUI _scoreText;
    
    [SerializeField]
    private Image _healthBar;

    [SerializeField]
    private static Sprite _fullHealth;
    [SerializeField]
    private Sprite _halfHealth;
    [SerializeField]
    private Sprite _lowHealth;
    [SerializeField]
    private Sprite _noHealth;
    private static Sprite _currentHealth = _fullHealth;


    void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        UpdateScoreText();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScoreText();
        _healthBar.overrideSprite = _currentHealth;
    }

    public int GetScore() => _score;
    public int SetScore(int score) => _score = score;

    public void AddScore(int score)
    {
        _score += score;
    }

    public void RemoveScore(int score)
    {
        int decrementBy = Math.Max(score, 0);
        if (decrementBy > _score)
        {
            return;
        }

        _score -= decrementBy;
    }

    public void UpdateScoreText()
    {
        _scoreText.text = _score.ToString();
    }

    public void ResetScore()
    {
        _score = 0;
    }

    public void UpdatePlayerHealth(int health)
    {
        switch (health)
        {
            case 3:
              _currentHealth = _fullHealth;
              break;
            
            case 2:
              _currentHealth = _halfHealth;
              break;
            
            case 1:
              _currentHealth = _lowHealth;
              break;
            
            case 0:
              _currentHealth = _noHealth;
              break;
        }
    }

    public void RestoreHealth()
    {
        _currentHealth = _fullHealth;
    }
}
