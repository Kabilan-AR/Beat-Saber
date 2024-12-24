using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public AudioSource[] music;
    private AudioSource currentSong;
    public GameObject Menu;
    public float GameTime=0;
    public TMP_Text scoreText;
    private int score;
    private bool menuValue;

    public static int songNumber;// Add a custom value to all objects in Game Manager
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        menuValue = true;
       
    }

    // Update is called once per frame
    void Update()
    {
        GameTime += Time.deltaTime;
        //if(menuValue)
        //{
        //    currentSong = music[songNumber];
        //}
    }
     public void onPlay()
    {

    }
    public void songSelected(int songNumber)
    {
        currentSong.Play();
    }

    public void ScoreCount()
    {
        score += 100;
        scoreText.text = score.ToString();
    }
    public void ReduceScoreCount()
    {
        score -=100 ;
        scoreText.text = score.ToString();
    }
}
