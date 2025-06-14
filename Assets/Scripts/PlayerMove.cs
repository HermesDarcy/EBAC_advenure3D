using Play.HD.StateMachines;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float forceJump;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        moves();
    }


    private void moves()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * forceJump, ForceMode.Impulse);
            Debug.Log("Pulo Player");
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Debug.Log("walk Player");
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Debug.Log("left rotate  Player");

        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Debug.Log("right rotate Player");
        }
    }

}
