using UnityEngine;

public class Force_Shield : MonoBehaviour
{

    public GameObject shield;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ShieldOff();
    }

    public void ShieldOn()
    {
        shield.SetActive(true);
    }

    public void ShieldOff()
    {
        shield.SetActive(false);
    }

}
