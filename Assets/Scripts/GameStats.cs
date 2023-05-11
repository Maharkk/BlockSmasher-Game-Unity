using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms.Impl;

public class GameStats : MonoBehaviour
{
    [Range(0.1f, 10f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerBloack = 50;
    [SerializeField] int CurrentScore = 0;
    [SerializeField] TextMeshProUGUI scoretext;
    [SerializeField] bool Autoplay ;
    private void Awake()
    {
        int noOfload = FindObjectsOfType<GameStats>().Length;
        if (noOfload > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    private void Start()
    {
        PrintScore();
    }
    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void AddScore()
    {
        CurrentScore += pointsPerBloack;
        PrintScore();
    }
    public void PrintScore()
    {
        scoretext.text = CurrentScore.ToString();
    }
    public void gameReset()
    {
        Destroy(gameObject);
    }
    public bool isAutoplay()
    {
        return Autoplay;
    }
}
