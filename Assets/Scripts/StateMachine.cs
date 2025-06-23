using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

namespace Play.HD.StateMachines
{


    public class StateMachine<T> where T : System.Enum
    {

        public Dictionary<T, StateBase> dictStates;

        public StateBase currentState;



        public void Init()
        {
            dictStates = new Dictionary<T, StateBase>();
        }




        public void RegisterStates(T typeEnum, StateBase state)
        {
            dictStates.Add(typeEnum, state);

        }

        public void SwithState(T typeS)
        {
            //Debug.Log(typeS);
            if (currentState != null)
            {
                currentState.OnStateExit();
            }
            currentState = dictStates[typeS];
            currentState.OnStateEnter();

        }


        private void Update()
        {
            if (currentState != null)
            {
                currentState.OnStateStay();
            }





        }

    }
}



/*
public class StateMachine : MonoBehaviour
{
       
    
    public enum states
    {
        none,
        idle,
        run
    }

    public states typeStates;
    public Dictionary<states, StateBase> dictStates; 
    
    public StateBase currentState;


    private void Awake()
    {
        dictStates = new Dictionary<states, StateBase>
        {
            { states.none, new StateBase() },
            {states.idle, new StateBase() },
            {states.run, new StateBase() }
        };
        
        SwithState(states.idle);
        
    }

    public void SwithState(states typeS)
    {
        Debug.Log(typeS);
        if (currentState != null) 
        {
            currentState.OnstateExit();
        }
        currentState = dictStates[typeS];
        currentState.OnstateEnter();

    }


    private void Update()
    {
        if (currentState != null)
        {
            currentState.OnstateStay();
        }





    }

#if UNITY_EDITOR
    #region Debug
    public void onStartGame()
    {
        Debug.Log(" start");
        SwithState(states.none);
    }

    public void onStateX()
    {
        Debug.Log(" Idle");
        SwithState(states.idle);
    }

    public void onStateY()
    {
        Debug.Log(" Exit");
        SwithState(states.run);
    }
    #endregion
#endif
}


*/