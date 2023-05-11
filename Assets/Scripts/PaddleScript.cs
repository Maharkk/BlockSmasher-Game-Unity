using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PaddleScript : MonoBehaviour
{
    [SerializeField] float min = 1f;
    [SerializeField] float max = 15f;
    [SerializeField] float units = 16f;

    BallScript ball;
    GameStats play;
    // Start is called before the first frame update
    void Start()
    {
        ball = FindObjectOfType<BallScript>();
        play = FindObjectOfType<GameStats>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 paddlePosition = new Vector2(transform.position.x , transform.position.y);
        paddlePosition.x = Mathf.Clamp(GetXpos(), min ,max);
        transform.position = paddlePosition;
    }
    private float GetXpos()
    {
        if (play.isAutoplay() == true )
        {
           return ball.transform.position.x;
        }
        else
        {
            return Input.mousePosition.x / Screen.width * units;
        }
    }
}
