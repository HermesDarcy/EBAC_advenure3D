using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using Play.HD.Singleton;

public class CheckPointManager : Singleton<CheckPointManager>
{
    public List<CheckPointBase> checkPoints;
    public int lastPoint;


    public void CheckPointRegister(int cp)
    {
        if(cp > lastPoint)
        {
            lastPoint = cp;
        }
        
    }


    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }





}
