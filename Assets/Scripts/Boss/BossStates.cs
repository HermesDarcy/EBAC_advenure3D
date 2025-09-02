
using UnityEngine;
using Play.HD.StateMachines;
using AnimationsHD;



namespace BossEnemy
{

    public class BossStates : StateBase
    {
        protected BossBase boss;

        public override void OnStateEnter(object[] obj )
        {
            base.OnStateEnter(obj);
            boss = (BossBase)obj[0];
        }



    }

    
    public class BossStateInit : BossStates
    {
        public override void OnStateEnter(params object[] obj)
        {
            base.OnStateEnter(obj);
            boss.StartGame();
            Debug.Log("Init " +  boss);
        }
    }

    public class BossStateAttack: BossStates
    {
        public override void OnStateEnter(params object[] obj)
        {
            base.OnStateEnter(obj);
            boss.BossOnAttack();
            
            Debug.Log("attack " + boss);
        }
    }


    public class BossStateidle : BossStates
    {
        public override void OnStateEnter(params object[] obj)
        {
            base.OnStateEnter(obj);
            boss.faceToPlayer = false;
            boss.animeTypes = AnimeTypes.idle;
            boss.playAnimeTrigger(AnimeTypes.idle);
            Debug.Log("idle " + boss);
        }
    }

    public class BossStatePatrol: BossStates
    {

        public override void OnStateEnter(params object[] obj)
        {
            base.OnStateEnter(obj);
            boss.faceToPlayer = false;
            boss.onMove = true;
            boss.animeTypes = AnimeTypes.patrol;
            
            Debug.Log("patrol " + boss);
        }
    }

    public class BossStateDeath: BossStates
    {
        public override void OnStateEnter(params object[] obj)
        {
            base.OnStateEnter(obj);
            boss.faceToPlayer = false;
            boss.onMove = false;
            boss.animeTypes = AnimeTypes.death;
            boss.playAnimeTrigger(AnimeTypes.death);
            Debug.Log("death " + boss);
        }
    }



}
