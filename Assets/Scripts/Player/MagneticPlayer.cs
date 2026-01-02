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



}
