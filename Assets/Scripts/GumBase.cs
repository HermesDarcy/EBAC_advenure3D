using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GumBase : MonoBehaviour
{
    public GameObject gum;
    public KeyCode keyGum;
    public float timetoProjectils = 0.5f;
    public GameObject localGum;
    public Vector3 pos;
    private float nextTime;


    private void Start()
    {
        nextTime = Time.time + timetoProjectils;
    }


    void Update()
    {
        
        if (Input.GetKeyDown(keyGum) && Time.time > nextTime)
        {
            shoot();
            nextTime = Time.time + timetoProjectils;
        }
        pos = localGum.transform.position;

    }


    


    private void shoot()
    {
        GameObject projectil = Instantiate(gum, localGum.transform.position, localGum.transform.rotation);
        
        
    }


}
