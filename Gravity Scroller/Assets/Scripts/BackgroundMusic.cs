using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    private PlayerPrefs mute;
    void Start()
    {
        BackgroundMusic[] objs = FindObjectsOfType<BackgroundMusic>();

        if (objs.Length > 1)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        int mute = PlayerPrefs.GetInt("Mute");
        if (mute == 0)
            Sound(false);
        else
            Sound(true);
    }
    public void Sound(bool isMute)
    {
        var audioSource = FindObjectsOfType<AudioSource>();
        for (int i = 0; i < audioSource.Length; i++)
        {
            audioSource[i].mute = isMute;
        }
    }
}
