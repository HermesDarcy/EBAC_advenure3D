using DG.Tweening;
using System.Collections;
using UnityEngine;

public class FXGunner : FlashColors
{
    public GameObject particles;
    public float inTime = 0.2f;


    private void Start()
    {
        particles.SetActive(false);
    }

    public void FXFlassh()
    {
        
        ColorFlassh();
        //StopAllCoroutines();
        StartCoroutine(OnOffParticles());
        
    }


    IEnumerator OnOffParticles()
    {
        particles.SetActive(false);
        particles.SetActive(true);
        yield return new WaitForSeconds(inTime);
        yield return new WaitForEndOfFrame();
        particles.SetActive(false);
    }



}
