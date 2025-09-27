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


    public void ValueLife(int max, int lf)
    {
        
        if (lf < 0) lf = 0;
        if (tween != null) tween.Kill();
        tween = imageLife.DOFillAmount( (float) lf / max, .5f).SetEase(ease);
        
        Debug.Log(" life" + lf.ToString());
        


    }




}
