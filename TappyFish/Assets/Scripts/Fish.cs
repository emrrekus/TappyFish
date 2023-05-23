using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float speed;
    public Score _Score;

    private int angle;
    private int maxAngle = 20;
    private int minAngle = -60;
    private bool touchedGround;

    public Sprite fishDied;
    public GameManager _GameManager;
    private SpriteRenderer sp;
    private Animator anim;

    public ObstacleSpawner _ObstacleSpawner;

    [SerializeField] private AudioSource Swim, Hit, Point;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        sp = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        FishSwim();
    }

    private void FixedUpdate()
    {
        FishRotation();
    }

    void FishSwim()
    {
        if (Input.GetMouseButtonDown(0) && GameManager.gameOver == false)
        {
            Swim.Play();
            if (GameManager.gameStarted == false)
            {
                rb.gravityScale = 1f;
                rb.velocity = Vector2.zero;
                rb.velocity = new Vector2(rb.velocity.x, speed);
                _ObstacleSpawner.InstantiateObstacle();
                _GameManager.GameHasStarted();
            }
            else
            {
                rb.velocity = Vector2.zero;
                rb.velocity = new Vector2(rb.velocity.x, speed);
            }
        }
    }

    void FishRotation()
    {
        if (rb.velocity.y > 0)
        {
            if (angle <= maxAngle)
            {
                angle = angle + 4;
            }
        }
        else if (rb.velocity.y < -1.2)
        {
            if (angle > minAngle)
            {
                angle = angle - 2;
            }
        }

        if (touchedGround == false)
        {
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle"))
        {
            _Score.Scored();
            Point.Play();
        }
        else if (other.CompareTag("Column") && GameManager.gameOver==false)
        {
            _GameManager.GameOver();
            FishDiesEffect();
        }
    }

    void FishDiesEffect()
    {
        Hit.Play();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            if (GameManager.gameOver == false)
            {
                _GameManager.GameOver();
                GameOver();
                FishDiesEffect();
            }
            
        }
    }

    void GameOver()
    {
        touchedGround = true;
        transform.rotation = Quaternion.Euler(0, 0, -90);
        sp.sprite = fishDied;
        anim.enabled = false;
    }
}