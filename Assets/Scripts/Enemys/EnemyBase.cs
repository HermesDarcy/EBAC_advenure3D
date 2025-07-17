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
        public AnimeTypes AnimeTypes = AnimeTypes.idle;
        public Collider Collider;
        public ParticleSystem particlesOnAttack, particleBalls;
        private void Awake()
        {
            Init();
        }

        protected virtual void Init()
        {
            ResetLife();
            OnBorn();
            particlesOnAttack.Stop() ;
            playAnimeTrigger(AnimeTypes.idle);
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
                playAnimeTrigger(AnimeTypes.death);
                Kill();
            }
        }
        void Start()
        {

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




        void Update()
        {



            if (Input.GetKeyDown(KeyCode.K))
            {
                OnDamage(2);

            }

            if (Input.GetKeyDown(KeyCode.L))
            {
                Init();
            }

            if(Input.GetKeyDown(KeyCode.J))
            {
                playAnimeTrigger(AnimeTypes.attack);
                particlesOnAttack.Play();
            }

            
        }


       

    }
}


