﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public Transform platformGenerator;
    private Vector3 platformStartPoint;

    public PlayerController thePlayer;
    private Vector3 playerStartPoint;

    private PlatformDestroyer[] platformList;

    private ScoreManager theScoreManager;

    private GameObject Music;
    public DeathMenu theDeathScreen;
	// Use this for initialization
	void Start ()
    {
        platformStartPoint = platformGenerator.position;
        playerStartPoint = thePlayer.transform.position;

        theScoreManager = FindObjectOfType<ScoreManager>();
        Music = GameObject.Find("SoundController");
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}
    public void RestartGame()
    {
        theScoreManager.scoreIncreasing = false;
        thePlayer.gameObject.SetActive(false);

        theDeathScreen.gameObject.SetActive(true);
        Music.gameObject.SetActive(false);

        //  StartCoroutine("RestartGameCo");
    }
    public void Reset()
    {
        theDeathScreen.gameObject.SetActive(false);
        Music.gameObject.SetActive(true);
        platformList = FindObjectsOfType<PlatformDestroyer>();
        for (int i = 0; i < platformList.Length; i++)
        {
            platformList[i].gameObject.SetActive(false);
        }
        thePlayer.transform.position = playerStartPoint;
        platformGenerator.position = platformStartPoint;
        thePlayer.gameObject.SetActive(true);

        theScoreManager.scoreCount = 0;
        theScoreManager.scoreIncreasing = true;
    }


    /*public IEnumerator RestartGameCo()
    {
        theScoreManager.scoreIncreasing = false;
        thePlayer.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        platformList = FindObjectsOfType<PlatformDestroyer>();
        for (int i = 0; i < platformList.Length; i++)
        {
            platformList[i].gameObject.SetActive(false);
        }
        thePlayer.transform.position = playerStartPoint;
        platformGenerator.position = platformStartPoint;
        thePlayer.gameObject.SetActive(true);
        theScoreManager.scoreCount = 0;
        theScoreManager.scoreIncreasing = true;
    }*/
}
