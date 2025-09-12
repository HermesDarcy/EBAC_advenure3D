using UnityEngine;

public class CheckPointBase : MonoBehaviour
{

    public int checkPointNum;
    public GameObject rays, ligth, lines;
    public ParticleSystem stars;
    [SerializeField]
    private bool onCheck = true; 

    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lines.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player") && onCheck == true)
        {
            other.gameObject.GetComponent<PlayerMove>().checkPoint = checkPointNum;
            CheckPointManager.Instance.CheckPointRegister(checkPointNum);
            other.gameObject.GetComponent<PlayerMove>().checkPointPos = transform;
            rays.gameObject.SetActive(false);
            ligth.gameObject.SetActive(false);
            lines.gameObject.SetActive(true);
            var ps =  stars.emission ;
            ps.enabled = false;
            onCheck = false;

        }

        if (other.gameObject.CompareTag("Player") && onCheck == false)
        {
            lines.gameObject.SetActive(false);
            lines.gameObject.SetActive(true);
           

        }


    }






}
