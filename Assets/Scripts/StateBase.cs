using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateBase 
{
    
    public virtual void OnstateEnter(object obj = null)
    {
        //Debug.Log(" state enter");
    }


    public virtual void OnstateStay()
    {
        //Debug.Log(" state stay");
    }

    public virtual void OnstateExit()
    {
        //Debug.Log(" state exit");
    }

    


}
