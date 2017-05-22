using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPaddle : Paddle
{
    public float speed = 15f;
	// Use this for initialization
	void Start () {
		
	}
	
    void FixedUpdate()
    {
        // input speed of keyboard from -1 to 1
        float inputSpeed = 0f;

        if (Input.GetKey(KeyCode.A))
        {
            inputSpeed = -1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            inputSpeed = 1;
        }
        else
        {
            inputSpeed = 0;
        }

        // moves player along the x axis
        transform.position += new Vector3(inputSpeed * speed * Time.deltaTime, 0f, 0f);

        if (transform.position.x > 2.8f)
        {
            transform.position = new Vector3(3f, transform.position.y, transform.position.z);
        }
        else if (transform.position.x < -2.8f)
        {
            transform.position = new Vector3(-3f, transform.position.y, transform.position.z);
        }
    }

	// Update is called once per frame
	/*void Update ()
    {
        float inputSpeed = 0f;
        if (transform.position.x > 2.8f)
        {
            transform.position = new Vector3(3f, transform.position.y, transform.position.z);
        }
        else if (transform.position.x < -2.8f)
        {
            transform.position = new Vector3(-3f, transform.position.y, transform.position.z);
        }

        if (Input.GetKey(KeyCode.A))
        {
            

            transform.position = new Vector3(transform.position.x - 0.2f, transform.position.y, transform.position.z);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.position = new Vector3(transform.position.x + 0.2f, transform.position.y, transform.position.z);
        }

        // moves player along the x axis
        transform.position += new Vector3(inputSpeed * speed * Time.deltaTime, 0f, 0f);
    }*/
}
