using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ProjectileBase : MonoBehaviour
{
    public float timedestroy = 2f;
    public float speed = 35f;
    public int toDamage = 1;
    public string targetTag;


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

        if (collision.gameObject.CompareTag(targetTag))
        {
            //Debug.Log("toque");
            var damageable = collision.transform.GetComponent<IDamagem>();
            if (damageable != null)
            {
                Vector3 dir = transform.position - collision.transform.position;
                dir.Normalize();
                dir.y = 0;
                damageable.Damage(toDamage, dir);
                Destroy(gameObject);
            }
        }
        
        
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("toque trigger ");
        


    }


    


}
