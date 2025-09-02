using UnityEngine;
using Play.HD.StateMachines;
using AnimationsHD;
using DG.Tweening;

using NUnit.Framework;
using System.Collections;



namespace BossEnemy
{

    public class BossBase : MonoBehaviour, IDamagem
    {
        [Header("Inicial params")]
        public int startLife = 10;
        public int myLife;
        public float timeBorn = .5f;
        public float speed, minDist;
        public int numShoots = 1;
        public float timeShoots = .5f;
        [HideInInspector]
        public bool timeFire;

        [Header("links")]
        public AnimationBase animBase;
        public FlashColors flashColors;
        public IDamagem damage;
        public Collider Collider;
        public ParticleSystem particlesOnAttack, particleBalls;
        public Ease easeBorn = Ease.OutBack;
        public Transform localGun;
        public GameObject projectil;
       
        
        [HideInInspector]
        public Transform playerpos;

        [Header("actions")]
        public bool faceToPlayer;
        public bool onMove = false;
        public bool onAttack = false;
        public bool onFire = false;
        public Transform[] wayPoints;
        [HideInInspector]
        public AnimeTypes animeTypes = AnimeTypes.idle;
        public states state;
        public StateMachine<states> bossStateMachine; // = new StateMachine<states>();

        private int nextPoint;
        


        public enum states
        {
            Init,
            idle,
            attack,
            patrol,
            death
        }



        private void Awake()
        {
            Init();
        }


        

        private void Init()
        {
            bossStateMachine= new StateMachine<states>();
            bossStateMachine.Init();
            bossStateMachine.RegisterStates(states.Init, new BossStateInit());
            bossStateMachine.RegisterStates(states.idle, new BossStateidle());
            bossStateMachine.RegisterStates(states.attack, new BossStateAttack());
            bossStateMachine.RegisterStates(states.patrol, new BossStatePatrol());
            bossStateMachine.RegisterStates(states.death, new BossStateDeath());

            bossStateMachine.SwithState(state, this);
        }
       

        
        public virtual void StartGame()
        {
            ResetLife();
            
            particlesOnAttack.Stop();
            animeTypes = AnimeTypes.idle;
            playAnimeTrigger(animeTypes);
            state = states.idle;
            bossStateMachine.SwithState(state, this);
            FindPlayer();
            OnBorn();

        }

        public void FindPlayer()
        {
            playerpos = GameObject.FindAnyObjectByType<PlayerMove>().transform;
        }


        #region Life_Damage

        protected virtual void ResetLife()
        {
            myLife = startLife;
        }

        

        protected virtual void Kill()
        {
            OnKill();
        }

        protected virtual void OnKill()
        {
            Destroy(gameObject, 4f);
            if (Collider != null) { Collider.enabled = false; }


        }


        protected virtual void OnDamage(int damage)
        {
            myLife -= damage;
            flashColors.OnDamageFlash();
            particleBalls.Play();
            if (myLife < 1)
            {
                animeTypes = AnimeTypes.death;
                state = states.death;
                playAnimeTrigger(AnimeTypes.death);
                Kill();
            }
        }

        public void Damage(int d)
        {
            OnDamage(d);
        }


        public void Damage(int d, Vector3 dir)
        {
            OnDamage(d);
            transform.DOMove(transform.position - dir, .2f);
        }



        #endregion



        #region Animations

        public void OnBorn()
        {
            transform.localScale = Vector3.zero;
            transform.DOScale(1, timeBorn).SetEase(easeBorn);
        }



        public void playAnimeTrigger(AnimeTypes typeTrigger)
        {
            animBase.AnimeByTrigger(typeTrigger);
        }


        #endregion


        #region actions



        public void FaceTooPlayer()
        {
            if (faceToPlayer)
            {
                //transform.LookAt(playerpos);
                transform.DOLookAt(playerpos.position, .2f, AxisConstraint.Y);
            }
        }


        public virtual void BossOnMove()
        {
            faceToPlayer = false;

            if (Vector3.Distance(transform.position, wayPoints[nextPoint].position) < minDist)
            {
                int z = Random.Range(0, wayPoints.Length);
                while (z == nextPoint)
                {
                    z = Random.Range(0, wayPoints.Length);
                }
                nextPoint = z;
                transform.DOLookAt(wayPoints[nextPoint].position, .2f, AxisConstraint.Y);
                if(onFire)
                {
                    StartCoroutine(inShoot());
                }
            }
            
            if(!timeFire)
            {
                transform.DOLookAt(wayPoints[nextPoint].position, .2f, AxisConstraint.Y);
                transform.position = Vector3.MoveTowards(transform.position, wayPoints[nextPoint].position, Time.deltaTime * speed);
            }
            
        }


        public void BossOnAttack() // boss attack 
        {
            
            
            animeTypes = AnimeTypes.attack;
            state = states.attack;
            playAnimeTrigger(AnimeTypes.attack);
            shoot();


        }


        public void shoot()
        {

            StartCoroutine(inShoot(numShoots));

            /*
            transform.DOLookAt(playerpos.position, .02f, AxisConstraint.Y);
            GameObject ball = Instantiate(projectil, localGun);
            ball.GetComponent<ProjectileBase>().targetTag = "Player";

            ball.transform.localPosition = Vector3.zero;
            ball.transform.position = localGun.transform.position;
            //ball.transform.localEulerAngles = Vector3.zero + Vector3.up * (i % 2 == 0 ? angle : -angle) * mult;
            ball.transform.parent = null;
            */



        }

        IEnumerator inShoot(int shoots =1)
        {
            timeFire = true;

            for (int i = 0; i < shoots; i++)
            {
                transform.DOLookAt(playerpos.position, .2f, AxisConstraint.Y);
                yield return new WaitForSeconds(.3f);
                GameObject ball = Instantiate(projectil, localGun);
                ball.GetComponent<ProjectileBase>().targetTag = "Player";

                ball.transform.localPosition = Vector3.zero;
                ball.transform.position = localGun.transform.position;
                //ball.transform.localEulerAngles = Vector3.zero + Vector3.up * (i % 2 == 0 ? angle : -angle) * mult;
                ball.transform.parent = null;
                yield return new WaitForSeconds(timeShoots);
            }
                timeFire = false;
        }






        #endregion


    }

}
