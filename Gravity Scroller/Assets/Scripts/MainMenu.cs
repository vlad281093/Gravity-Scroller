using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Text bestScoreText;
    public bool Show = true;
    public Button MuteButton;
    public Sprite MusicON;
    public Sprite MusicOFF;
    
    void Start()
    {
        int hightScore = PlayerPrefs.HasKey(ScoreManager.HighScore) ? PlayerPrefs.GetInt(ScoreManager.HighScore) : 0;
        bestScoreText.text = "Best score: " + hightScore;

        int mute = PlayerPrefs.GetInt("Mute");
        if (mute == 0) {
            MuteButton.image.overrideSprite = MusicON;
            FindObjectOfType<BackgroundMusic>().Sound(false);
        }
        else {
            MuteButton.image.overrideSprite = MusicOFF;
            FindObjectOfType<BackgroundMusic>().Sound(true);
        }
    }

    public void ChangeButton()
    {
        int mute = PlayerPrefs.GetInt("Mute");

        if (mute == 0) {
            MuteButton.image.overrideSprite = MusicOFF;
            FindObjectOfType<BackgroundMusic>().Sound(true);
            PlayerPrefs.SetInt("Mute", 1);
        }
        else {
            MuteButton.image.overrideSprite = MusicON;
            FindObjectOfType<BackgroundMusic>().Sound(false);
            PlayerPrefs.SetInt("Mute", 0);
        }
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("GamePlay");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
