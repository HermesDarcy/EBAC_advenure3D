using UnityEngine;

public class BossCamera : MonoBehaviour
{
    
    public GameObject bossCamera;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bossCamera.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            bossCamera.gameObject.SetActive(true);
            //Debug.Log(" trigger camera");
        }
    }



}
