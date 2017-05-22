using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPaddle : Paddle
{
    public GameObject Ball;

    public float speed = 2.5f;

    private bool offline;

    private Transform ballTransform;
    GameObject ballObject;

    // Use this for initialization
    void Start()
    {
        findBall();
    }

    void FixedUpdate()
    {
        // input speed of the AI from -1 to 1
        float inputSpeed = 0f;

        if(ballObject != null)
        {
            if (ballTransform.position.x > transform.position.x)
            {
                inputSpeed = 1f;
            }
            else if (ballTransform.position.x < transform.position.x)
            {
                inputSpeed = -1f;
            }

            // move player along the z axis
            Vector3 position = transform.position + new Vector3(inputSpeed * speed * Time.deltaTime, 0f, 0f);

            // If the ball speed along the z-axis is smaller than the ball speed, the player will lag.
            // We can prevent the lagging by clamping the z-position to the ball position.
            if (inputSpeed > 1f)
            {
                if (position.x > ballTransform.position.x)
                {
                    position.x = ballTransform.position.x;
                }
            }
            else if (inputSpeed < 1f)
            {
                if (position.x < ballTransform.position.x)
                {
                    position.x = ballTransform.position.x;
                }
            }

            transform.position = position;
        }
        else
        {

            findBall();
            transform.position = new Vector3(0, 0.5f, 7f);
        }
    }

    void findBall()
    {
        ballObject = GameObject.Find("Ball");
        if (ballObject == null)
        {
            //Debug.LogWarning("AI cannot find the Ball Object");
            //offline = true;
        }
        else
        {
            ballTransform = ballObject.transform;
        }
    }
     
}
