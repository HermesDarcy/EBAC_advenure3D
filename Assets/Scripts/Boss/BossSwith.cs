using UnityEngine;

public class BossSwith : MonoBehaviour
{
    public GameObject boss;
    public PlayerMove player;
    public Color gizmoColor;
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
        Gizmos.color = gizmoColor;
        
        Gizmos.DrawWireSphere(transform.position, 9.2f);
        //Gizmos.DrawSphere(transform.position, 9.2f);
    }

}
