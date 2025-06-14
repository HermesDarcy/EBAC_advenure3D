using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Play.HD.Singleton;
using Play.HD.StateMachines;

public class GameManager : Singleton<GameManager>
{
    public enum GameStates
    {
        Intro,
        RunGame,
        InPause,
        Win,
        Lose,
        EndGame
    }
    public StateMachine<GameStates> posStateMachine =  new StateMachine<GameStates>();
        
    
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }


    public void Init()
    {
        posStateMachine.Init();
        posStateMachine.RegisterStates(GameStates.Intro, new ManagerIntro());
        posStateMachine.RegisterStates(GameStates.RunGame, new ManagerRunGame());
        posStateMachine.RegisterStates(GameStates.InPause, new ManagerPause());
        posStateMachine.RegisterStates(GameStates.Win, new ManagerWin());
        posStateMachine.RegisterStates(GameStates.Lose, new ManagerLose());
        posStateMachine.RegisterStates(GameStates.EndGame, new ManagerEndGame());
        
        posStateMachine.SwithState(GameStates.Intro);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
