using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Enemy1 :  MonoBehaviour
{
    public float speed;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void patrol()
    {
        transform.position = new Vector3(transform.position.x * speed * Time.deltaTime, transform.position.y, transform.position.z);
    }


}
