using UnityEngine;

public class BossSwith : MonoBehaviour
{
    public GameObject boss;
    public PlayerMove player;
    private bool firstChange = true;


    private void Awake()
    {
        boss.SetActive(false);
    }

    private void Start()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player") && firstChange)
        {
            boss.SetActive(true);
            player.PausePlayer();
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            
            firstChange = false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        
        Gizmos.DrawWireSphere(transform.position, 9.2f);
    }

}
