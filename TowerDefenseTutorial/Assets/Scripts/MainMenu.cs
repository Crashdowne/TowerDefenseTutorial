﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string levelToLoad = "MainLevel";

    public Fade sceneFader;

    public void Play ()
    {
        sceneFader.FadeTo(levelToLoad);
    }

    public void Quit ()
    {
        Application.Quit();
    }
	
}
