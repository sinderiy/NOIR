using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {

    public string playGameLevel;

	public void Play()
    {
        Application.LoadLevel(playGameLevel);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
