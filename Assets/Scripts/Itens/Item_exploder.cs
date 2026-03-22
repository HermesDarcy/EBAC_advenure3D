using Itens;
using Play.HD.Singleton;
using Unity.VisualScripting;
using UnityEngine;


public class Item_exploder : MonoBehaviour
{

        
    public itemType itemType;
    public int value = 1;
    public SfxTypes typeSfx;
    [SerializeField]
    private Collider collider;
    
    


    private void Awake()
    {
        collider = GetComponent<Collider>();
        collider.enabled = false;
    }

    private void Start()
    {
                       
        Invoke("BornThis", 1.5f);

    }


    private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                onColleted();
            }
        }

    private void onColleted()
    {
        //this.gameObject.SetActive(false);
        collider.enabled = false;
        ItemManager.Instance.Addtype(itemType, value);
        MyEffect();
        Invoke("HideThis", .2f);
    }

    protected virtual void MyEffect()
    {
        SfxPool.Instance.Play(typeSfx);
    }



    private void HideThis()
    {
        this.gameObject.SetActive(false);
    }

    private void BornThis()
    {
        collider.enabled = true;
        this.gameObject.tag = "CoinMag";
    }

        
}

