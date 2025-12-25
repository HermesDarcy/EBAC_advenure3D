using UnityEngine;

public class MagneticPlayer : MonoBehaviour
{

    public bool activate = false;


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Magnetic"))
        {
            activate = true;
            other.gameObject.SetActive(false);
        }
        
        
        
        if (activate)
        {
            if (other.gameObject.CompareTag("CoinMag"))
            {
                other.gameObject.AddComponent<MagneticItem>();
            }
        }
    }



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
