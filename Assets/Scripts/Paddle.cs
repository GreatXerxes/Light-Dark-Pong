using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    Rigidbody myBody;

    // Use this for initialization
    void Start ()
    {
        myBody = transform.GetComponent<Rigidbody>();
        myBody.freezeRotation = true;
    }

}
