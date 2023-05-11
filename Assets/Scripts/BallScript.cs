using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    //Configuration paramater
    [SerializeField] PaddleScript paddle1;
    [SerializeField] float xpush = 2f;
    [SerializeField] float ypush = 14f;
    [SerializeField] AudioClip[] soundEffects;
    [SerializeField] float randomNumber = 0.2f;
    // cached components
    AudioSource myAudios;
    Rigidbody2D myRigidBody2D;

    //State
    Vector2 ptobv;
    bool hasstarted = false;
    // Start is called before the first frame update
    void Start()
    {
        ptobv = transform.position - paddle1.transform.position;
        myAudios = GetComponent<AudioSource>();
        myRigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasstarted)
        {
            LockToPaddle();
            StartWithMouseClick();
        }
       
    }

    private void LockToPaddle()
    {
        Vector2 paddlepos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlepos + ptobv;
    }
    private void StartWithMouseClick()
    {
        if(Input.GetMouseButtonDown(0))
        {
            myRigidBody2D.velocity = new Vector2(xpush, ypush);
            hasstarted = true;
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocitychange = new Vector2(Random.Range(0f, randomNumber), Random.Range(0f, randomNumber));
      if(hasstarted)
        {
            AudioClip clips = soundEffects[Random.Range(0, soundEffects.Length)];
            myAudios.PlayOneShot(clips);
            myRigidBody2D.velocity += velocitychange;
        }
    }
}
