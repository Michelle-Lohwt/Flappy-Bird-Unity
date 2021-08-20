using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public float velocity;
    private Rigidbody2D RB;

    public bool StartGame;
    public GameManager gamemanager;

    public AudioSource Hit, Wing, Point;

    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (StartGame == true)
        {
            //The flappy bird starts to drop
            RB.simulated = true;
            if (Input.GetMouseButtonDown(0))
            {
                Wing.Play();
                //jump
                RB.velocity = Vector2.up * velocity;
            }
        }
        else
        {
            //The flappy bird won't drop
            RB.simulated = false;
        }
    }

    // Hit the floor or hit the spawner
    void OnCollisionEnter2D(Collision2D collision)
    {
        Hit.Play();
        gamemanager.GameOver();
        StartGame = false;
    }

    // Scoring
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "score")
        {
            Point.Play();
            gamemanager.AddScore();
        }
    }
}
