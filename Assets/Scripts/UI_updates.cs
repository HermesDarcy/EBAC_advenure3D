using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public class UI_updates : MonoBehaviour
{
    public List<UIShoot> listUIshoots;
    public ShootTypes shootTypes;
    public Image imageLife;
    public Ease ease;
    private Tween tween;
    public Force_Shield forceShield;

    void Start()
    {
        foreach (var item in listUIshoots)
        {
            item.TypeBall(1);
            item.ValueUpdate(1f);
        }
    }


    void Update()
    {
        foreach (var item in listUIshoots)
        { 
            item.TypeBall(shootTypes.shootType);
            item.ValueUpdate(shootTypes.maxShoot,shootTypes.currentShoot);
        }  
    }


    public void ValueLife(float max, float lf)
    {
        max = (int)max;
        lf = (int)lf;

        if (lf < 0) lf = 0;
        if (tween != null) tween.Kill();
        tween = imageLife.DOFillAmount( (float) lf / max, .5f).SetEase(ease);
        
        Debug.Log(" life" + lf.ToString());
        


    }


    public void shieldOn()
    {
        imageLife.color = Color.blue;
        forceShield.ShieldOn();
    }

    public void shieldOff()
    {
        imageLife.color = Color.white;
        forceShield.ShieldOff();
    }

    public void blinkImage()
    {
        StartCoroutine(ToBlink());
    }

    IEnumerator ToBlink()
    {
        float t = .3f;
        imageLife.DOColor(Color.white, t);

        for (int i=0; i<=9;i++)
        {
            forceShield.ShieldOn();
            imageLife.DOColor(Color.blue, t);
            yield return new WaitForSeconds(t);
            
            forceShield.ShieldOff();
            imageLife.DOColor(Color.white, t);
            yield return new WaitForSeconds(t);
        }
        
        

    }



}
