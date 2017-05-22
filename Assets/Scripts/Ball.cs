using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour {

    Rigidbody myBody;

    Vector3 force;

    // Use this for initialization
    void Start ()
    {
        myBody = transform.GetComponent<Rigidbody>();
        //force = new Vector3(Random.Range(-10, 10), 0, Random.Range(-15, 15));
        force = new Vector3(setupForce() * Random.Range(5, 10), 0, setupForce()* Random.Range(5, 10));

        //myBody.velocity = force;
        myBody.AddForce(force, ForceMode.Impulse);


    }
	
	// Update is called once per frame
	/*void FixedUpdate () {
        if(transform.position.y > 1f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - (0.25f * Time.deltaTime), transform.position.z);
        }
        else if (transform.position.y < 0.5f)
        {
            transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);
        }
        
	}*/

    void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(collision.gameObject.name);

        GameManager manager = GameObject.Find("GameManager").GetComponent<GameManager>();

        Vector3 vel = myBody.velocity;
        //Finding out the horizontal direction of the ball after hitting a wall
        Vector2 horizontalvector = new Vector2(vel.x, vel.z);
        //Normalizing the vector so only the direction remains without the speed
        horizontalvector = horizontalvector.normalized;
        //Adding the force of the original vector to the horizontal direction 
        horizontalvector = vel.magnitude * horizontalvector;
        //Now since the horizontal vector has the same force of the original velocity
        //All that remains is to give the ball the new velocity.
        //horizontalvector.x in x axis
        //horizontalvector.y in z axis
        myBody.velocity = new Vector3(horizontalvector.x, 0, horizontalvector.y);





        if (collision.gameObject.name == "Player Paddle")
        {
            GetComponent<Renderer>().material.color = Color.black;
        }
        else if (collision.gameObject.name == "Enemy Paddle")
        {
            //GetComponent<Renderer>().material.color = Color.white;
            GetComponent<Renderer>().material.color = Color.blue;
        }
        else if (collision.gameObject.name == "Wall")
        {
            
        }
        else if (collision.gameObject.name == "MultiBall")
        {
            manager.powerupMultiball(collision.gameObject);
        }

        /*if(collision.gameObject.name == "AI Goal")
        {
            if (name == "Ball")
            {
                Debug.Log("Adding Score: AI Goal");
                manager.applyScore(1, false);
            }
            else
            {
                Debug.Log("Multiball hit the AI Goal");
                GameObject obj = GameObject.Find(name);//Destroy(this) wasn't working
                Destroy(obj);
                manager.applyScore(1, true);
            }
            
        }
        else if (collision.gameObject.name == "Player Goal")
        {
            if(name == "Ball")
            {
                Debug.Log("Adding Score: Player Goal");
                manager.applyScore(2, false);
            }
            else
            {
                Debug.Log("Multiball hit player goal");
                GameObject obj = GameObject.Find(name);//Destroy(this) wasn't working
                Destroy(obj);
                manager.applyScore(2, true);
                
            }
        }*/
    }

    int setupForce()
    {
        int rand = Random.Range(1, 3);
        if(rand == 1)
        {
            return -1;
        }
        else
        {
            return 1;
        }
    }

}
