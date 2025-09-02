using UnityEngine;

public class BossSwith : MonoBehaviour
{
    public GameObject boss;
    


    private void Awake()
    {
        boss.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            boss.SetActive(true);
        }
    }
}
