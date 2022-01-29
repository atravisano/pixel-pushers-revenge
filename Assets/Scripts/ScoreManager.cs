using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private int _score = 0;
    [SerializeField]
    private Text _scoreText;

    // Start is called before the first frame update
    void Start()
    {
        UpdateScoreText();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddScore(int score)
    {
        _score += score;
    }

    public void RemoveScore(int score)
    {
        _score -= score;
    }

    public void UpdateScoreText()
    {
        _scoreText.text = _score.ToString();
    }
}
