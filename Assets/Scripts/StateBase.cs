using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateBase 
{
    
    public virtual void OnStateEnter(object obj = null)
    {
        //Debug.Log(" state enter");
    }


    public virtual void OnStateStay()
    {
        Debug.Log(" state stay");
    }

    public virtual void OnStateExit()
    {
        //Debug.Log(" state exit");
    }

    


}
