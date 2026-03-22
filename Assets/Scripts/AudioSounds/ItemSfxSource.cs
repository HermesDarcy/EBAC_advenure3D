using UnityEngine;
//using Itens;

   
public class ItemSfxSource : MonoBehaviour
{

    public SfxTypes sfxType;
    


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlaySfx();
        }
    }

    public void PlaySfx()
    {
        SfxPool.Instance.Play(sfxType);
    }
}