using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    public Image finalScoreImage;
    public Text finalScoreText;

    public void Restart()
    {
        FindObjectOfType<GameManager>().Reset();
    }

    public void BacktoMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
