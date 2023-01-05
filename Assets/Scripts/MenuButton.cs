using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour
{
    public static float Volume { get; set; } = 0.5f;
    public Slider Slider;

    private void Start()
    {
        if (Slider)
        {
            Slider.value = Volume;
        }
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ExitToMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    
    public void GameExit()
    {
        Debug.Log("Exit");
        Application.Quit();
    }

    public void VolumeChanged()
    {
        Debug.Log(Slider.value);
        Volume = Slider.value;
    }
}
