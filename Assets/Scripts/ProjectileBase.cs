using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBase : MonoBehaviour
{
    public float timedestroy = 2f;
    public float speed = 5f;


    // Start is called before the first frame update
    void Awake()
    {
        Destroy(gameObject, timedestroy);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }


}
