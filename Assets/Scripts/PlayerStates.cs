using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStates : MonoBehaviour
{
    
}


public class StatePlayerAttack : StateBase
{
    public override void OnStateStay()
    {
        base.OnStateStay();


    }
}

public class StateWalk : StateBase
{

}

public class StatePlayerJump : StateBase
{
    
    public override void OnStateStay()
    {
        base.OnStateStay();
        Debug.Log("pulo");
    }
}

public class StateWalkTras : StateBase
{

}


