using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AnimationsHD;

namespace Enemy_Alien
{
    public class EnemyBase : MonoBehaviour, IDamagem
    {
        public int startLife = 10;
        public int myLife;
        public IDamagem damage;
        public float timeBorn = .5f;
        public Ease easeBorn = Ease.OutBack;
        public AnimationBase animBase;
        public FlashColors flashColors;
        public AnimeTypes animeTypes = AnimeTypes.idle;
        public Collider Collider;
        public ParticleSystem particlesOnAttack, particleBalls;
        [SerializeField]
        private Transform playerpos;
        public bool faceToPlayer;
        private void Awake()
        {
            Init();
        }

        protected virtual void Init()
        {
            ResetLife();
            OnBorn();
            particlesOnAttack.Stop() ;
            animeTypes = AnimeTypes.patrol;
            playAnimeTrigger(animeTypes);
            
        }




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
            if(Collider != null ) { Collider.enabled = false; }
            

        }


        protected virtual void OnDamage(int damage)
        {
            myLife -= damage;
            flashColors.OnDamageFlash();
            particleBalls.Play();
            if (myLife < 1)
            {
                animeTypes = AnimeTypes.death;
                playAnimeTrigger(AnimeTypes.death);
                Kill();
            }
        }
        void Start()
        {
            playerpos = GameObject.FindAnyObjectByType<PlayerMove>().transform;
        }



        public virtual void Update()
        {
            OnFace();
        }



        #region Animations

        private void OnBorn()
        {
            transform.DOScale(0, timeBorn).SetEase(easeBorn).From();
        }



        public void playAnimeTrigger(AnimeTypes typeTrigger)
        {
            animBase.AnimeByTrigger(typeTrigger);
        }


        #endregion



        public void Damage(int d)
        {
            OnDamage(d);
        }


        public void Damage(int d, Vector3 dir)
        {
            OnDamage(d);
            transform.DOMove(transform.position - dir,.2f);
        }


        public void ListenerKeys()
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                OnDamage(2);

            }

            if (Input.GetKeyDown(KeyCode.L))
            {
                Init();
            }

            if (Input.GetKeyDown(KeyCode.J))
            {
                playAnimeTrigger(AnimeTypes.attack);
                particlesOnAttack.Play();
            }
        }


        public void OnFace()
        {
            if(faceToPlayer)
            {
                //transform.LookAt(playerpos);
                transform.DOLookAt(playerpos.position, .2f, AxisConstraint.Y);
            }
            


        }




    }
}


