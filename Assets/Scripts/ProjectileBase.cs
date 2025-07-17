using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBase : MonoBehaviour
{
    public float timedestroy = 2f;
    public float speed = 35f;
    public int toDamage = 1;
    


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
        Debug.Log("toque");
        var damageable = collision.transform.GetComponent<IDamagem>();
        if (damageable != null)
        { 
            damageable.Damage(toDamage);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("toque trigger ");
        


    }

}
