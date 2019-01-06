using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ScoreManager : MonoBehaviour
{
    public Image scoreImage;
    public Image highScoreImage;
    public Text scoreText;
    public Text highScoreText;

    public float scoreCount;
    public static int hightScoreCount;

    public int pointsPerSecond;

    public bool scoreIncreasing;
    public static string HighScore = "HighScore";

    void Start()
    {
        scoreIncreasing = true;
        if (PlayerPrefs.HasKey(HighScore))
        {
            hightScoreCount = PlayerPrefs.GetInt(HighScore);
        }
    }

    void Update()
    {
        if (scoreIncreasing)
        {
            scoreCount += pointsPerSecond * Time.deltaTime;
        }
        scoreText.text = "Score: " + (int)scoreCount;
        highScoreText.text = "Hight Score: " + hightScoreCount;
    }

    public void SaveScore()
    {
        if (scoreCount > hightScoreCount)
        {
            hightScoreCount = (int)scoreCount;
            PlayerPrefs.SetInt(HighScore, hightScoreCount);
        }
    }

    public void AddScore(int pointsToAdd)
    {
        scoreCount += pointsToAdd;
    }
}
