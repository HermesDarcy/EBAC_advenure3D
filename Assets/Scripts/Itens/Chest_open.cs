using UnityEngine;
using DG.Tweening;


public class Chest_open : MonoBehaviour
{
    public Animator animator;
    public Collider collider;
    public GameObject particles;
    public KeyCode key = KeyCode.B;
    public GameObject itemExplode;
    public Transform image;
    public Transform createPoint;
    public bool imageTrue = false;
    public bool emptyChest = false;


    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        image.transform.localScale = Vector3.zero;
    }

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && imageTrue==false)
        {
            image.DOScale(0.44f, 1f);
            imageTrue = true;
            
            if (Input.GetKeyDown(key) )
            {
                openChest();
            }

        }

    }


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && emptyChest == false)
        {
            
           
            if (Input.GetKeyDown(key))
            {
                openChest();
                HideImage();
                emptyChest = true;
                collider.enabled = false;
                Invoke("CriateCoins",0.7f);
            }

        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            HideImage();

        }
    }

    [NaughtyAttributes.Button]
    public void openChest()
    {
        animator.SetTrigger("open");
        particles.gameObject.SetActive(true);
    }

    private void HideImage()
    {
        image.DOScale(0, 1f);
        imageTrue = false;
    }

    [NaughtyAttributes.Button]
    private void CriateCoins()
    {

        for (int i = 0; i < 10; i++)
        {

            GameObject tempCoin = Instantiate(itemExplode, transform);
            
            tempCoin.transform.position = createPoint.transform.position;
            Rigidbody rb = tempCoin.AddComponent<Rigidbody>();
            //Item_exploder tempAdd = tempCoin.AddComponent<Item_exploder>(); 
            rb.mass = .3f;
            rb.linearDamping = .3f; // no lugar de rb.drag
            rb.angularDamping = .7f;        //  no lugar de angularDrag = 1f;
            
            
            
            //rb.AddForce(Vector3.up * 25f, ForceMode.Impulse);
            rb.AddExplosionForce(Random.Range(2f, 5f), tempCoin.transform.position, 45f, 1.5f, ForceMode.Impulse);
        }
            
            /*
         Rigidbody2D rb = GetComponent<Rigidbody2D>();
        Vector2 direcaoAleatoria = new Vector2(Random.Range(-1f, 1f), Random.Range(0.5f, 1f));
        rb.AddForce(direcaoAleatoria * forcaDaExplosao, ForceMode2D.Impulse);

         
         */

    }



}
