using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftMovement : MonoBehaviour
{
    public float speed;
    private BoxCollider2D _boxCollider2D;
    private float groundWidth;
    private float obstacleWidth;

    private void Start()
    {

        if (gameObject.CompareTag("Ground"))
        {
            _boxCollider2D = GetComponent<BoxCollider2D>();
            groundWidth = _boxCollider2D.size.x;
        }
        else if (gameObject.CompareTag("Obstacle"))
        {
            obstacleWidth = GameObject.FindGameObjectWithTag("Column").GetComponent<BoxCollider2D>().size.x;
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.gameOver==false)
        transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
        
        
        if (gameObject.CompareTag("Ground"))
        {
            if (transform.position.x <= -groundWidth)
            {
                transform.position = new Vector2(transform.position.x + 2 * groundWidth, transform.position.y);
            }
        }else if (gameObject.CompareTag("Obstacle"))
        {
            if (transform.position.x<GameManager.bottomLeft.x-obstacleWidth)
            {
             Destroy(gameObject);   
            }
        }

       
    }
}
