using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Multiball : MonoBehaviour
{
    bool goingUP;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * 8);

        if(transform.position.y <= 0.5)
        {
            transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);
            goingUP = true;
        }
        else if (transform.position.y >= 0.9)
        {
            goingUP = false;
        }

        if(goingUP)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.1f * Time.deltaTime, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.1f * Time.deltaTime, transform.position.z);
        }


    }
}
