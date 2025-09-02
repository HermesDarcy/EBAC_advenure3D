using Play.HD.StateMachines;
using UnityEngine;



namespace BossEnemy
{

    public class BossFSM : MonoBehaviour
    {
        public enum states
        {
            Init,
            idle,
            attack,
            patrol,
            death
        }

        public states state;
        public StateMachine<states> bossStateMachine = new StateMachine<states>();



        // Start is called before the first frame update
        void Start()
        {
            bossStateMachine.Init();
            bossStateMachine.RegisterStates(states.Init, new BossStateInit());
            bossStateMachine.RegisterStates(states.idle, new BossStateidle());
            bossStateMachine.RegisterStates(states.attack, new BossStateAttack());
            bossStateMachine.RegisterStates(states.patrol, new BossStatePatrol());
            bossStateMachine.RegisterStates(states.death, new BossStateDeath());

            bossStateMachine.SwithState(state, this);
        }

        // Update is called once per frame
        void Update()
        {
            bossStateMachine.SwithState(state, this);
        }


        public void BossStateInit()
        {

        }


    }

    
}


