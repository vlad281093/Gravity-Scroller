using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform platformGenerator_down;
    public Transform platformGenerator_up;
    private Vector3 platformStartPoint_down;
    private Vector3 platformStartPoint_up;

    public PlayerController thePlayer;
    private Vector3 playerStartPoint;
    private PlatformDestroyer[] platformList;

    private ScoreManager theScoreManager;
    public DeathMenu theDeathScreen;

    void Start()
    {
        platformStartPoint_down = platformGenerator_down.position;
        platformStartPoint_up = platformGenerator_up.position;
        playerStartPoint = thePlayer.transform.position;
        theScoreManager = FindObjectOfType<ScoreManager>();
    }

    public void RestartGame()
    {
        theScoreManager.scoreIncreasing = false;
        theDeathScreen.finalScoreText.text = "Final score: " + Mathf.Round(theScoreManager.scoreCount);
        theScoreManager.scoreImage.gameObject.SetActive(false);
        theScoreManager.highScoreImage.gameObject.SetActive(false);
        theDeathScreen.finalScoreImage.gameObject.SetActive(true);

        thePlayer.gameObject.SetActive(false);

        theDeathScreen.gameObject.SetActive(true);

        platformList = FindObjectsOfType<PlatformDestroyer>();
        for (int i = 0; i < platformList.Length; i++)
        {
            platformList[i].gameObject.SetActive(false);
        }
    }

    public void Reset()
    {
        theDeathScreen.gameObject.SetActive(false);
        platformList = FindObjectsOfType<PlatformDestroyer>();

        for (int i = 0; i < platformList.Length; i++)
        {
            platformList[i].gameObject.SetActive(false);
        }

        thePlayer.transform.position = playerStartPoint;

        thePlayer.gameObject.SetActive(true);

        platformGenerator_down.position = platformStartPoint_down;
        platformGenerator_up.position = platformStartPoint_up;

        theScoreManager.scoreCount = 0;
        theScoreManager.scoreIncreasing = true;
        theScoreManager.scoreImage.gameObject.SetActive(true);
        theScoreManager.highScoreImage.gameObject.SetActive(true);
    }
}
