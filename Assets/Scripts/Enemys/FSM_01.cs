using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Play.HD.StateMachines;

public class FSM_01 : MonoBehaviour
{
    public enum states
    {
        Init,
        Attack,
        Patrol,
        Jump,
        Win,
        Lose
    }
    
    public states state;   
    public StateMachine<states> posStateMachine =  new StateMachine<states>();
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        posStateMachine.Init();
        posStateMachine.RegisterStates(states.Init, new StateBase());
        posStateMachine.RegisterStates(states.Attack, new StateAttack());
        posStateMachine.RegisterStates(states.Patrol, new StatePatrol());
        posStateMachine.RegisterStates(states.Jump, new StateJump());
        posStateMachine.RegisterStates(states.Win, new StateBase());
        posStateMachine.RegisterStates(states.Lose, new StateBase());


        posStateMachine.SwithState(state);
    }

    // Update is called once per frame
    void Update()
    {
        posStateMachine.SwithState(state);
    }






}
