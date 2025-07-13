using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class UI_updates : MonoBehaviour
{
    public List<UIShoot> listUIshoots;
    public ShootTypes shootTypes;
    


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







}
