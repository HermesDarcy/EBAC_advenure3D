using UnityEngine;
using DG.Tweening;
using AnimationsHD;
using System.Collections;

public class DestrucItemBase : MonoBehaviour, IDamagem
{
    public float duration, intence;
    public int vibrato;
    public int myLife;
    public bool dropToEndLive = false;
    public int amountToDropItens =10;
    
    public int maxDropItens = 10;
    public GameObject prefabItem;
    public GameObject toHide;
    
    public Transform pointDropItens;
    private Collider collider;
    private Vector3 myPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myPos = transform.position;
        
        collider = GetComponent<Collider>();
        collider.enabled = true;
        if(dropToEndLive )
        {
            myLife = amountToDropItens;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    [NaughtyAttributes.Button]
    private void OnShake()
    {
        //transform.DOShakePosition(duration);//,intence,vibrato);
        transform.DOShakeScale(duration, Vector3.up * intence, vibrato,0,true, ShakeRandomnessMode.Harmonic);
        
        Invoke("ResetTween", duration + .1f);
    }


    private void ResetTween()
    {
        transform.position = myPos;
        DOTween.Clear(transform);
    }


    private void OnTriggerEnter(Collider other)
    {

    }

    public void Damage(int damage)
    {
        
        myLife -= damage;
        OnShake();
        
        if (dropToEndLive == false)
        {
            if (amountToDropItens > 0)
            {
                ToDropItens();
                amountToDropItens--;

            }
            


        }
        

        if (myLife < 1)
        {

            
            toHide.SetActive(false);
            collider.enabled = false;

            if(dropToEndLive)
            {
                StartCoroutine(CreateItensEnd());
            }

        }







    }


    public void Damage(int damage, Vector3 dir)
    {
        throw new System.NotImplementedException();
    }




    [NaughtyAttributes.Button]

    private void ToDropItens()
    {
        var temp = Instantiate(prefabItem, transform);
        temp.transform.position = pointDropItens.position;
        Rigidbody rb = temp.AddComponent<Rigidbody>();
        //Item_exploder tempAdd = tempCoin.AddComponent<Item_exploder>(); 
        rb.mass = 1.5f;
        rb.linearDamping = .3f; // no lugar de rb.drag
        rb.angularDamping = .1f;        //  no lugar de angularDrag = 1f;
    }



    IEnumerator CreateItensEnd()
    {

        yield return new WaitForEndOfFrame();
        for (int i = 0; i <= amountToDropItens; i++)
        {
            ToDropItens();
            yield return new WaitForSeconds(.1f);
            yield return new WaitForEndOfFrame();
        }

    }
}
