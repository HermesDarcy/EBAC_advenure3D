using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GumBase : MonoBehaviour
{
    public GameObject projectil;
    public GameObject localGum;
    public KeyCode keyGum;
    public float timetoProjectils = 0.2f;
    private Vector3 pos;
    private float nextTime;


    private void Start()
    {
        nextTime = Time.time + timetoProjectils;
    }


    void Update()
    {
        keysUpdate();


        pos = localGum.transform.position;

    }


    protected virtual void keysUpdate()
    {
        if (Input.GetKeyDown(keyGum) && Time.time > nextTime)
        {
            pos = localGum.transform.position;
            shoot();
            nextTime = Time.time + timetoProjectils;
            Debug.Log("key X");
        }
    }

    


    protected virtual void shoot()
    {
        GameObject ball = Instantiate(projectil, pos, localGum.transform.rotation);
        
        
    }


}
