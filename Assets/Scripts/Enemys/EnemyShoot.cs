using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

namespace Enemy_Alien
{
    public class EnemyShoot : GumBase
    {
        public float distanciaDeVisao = 15f;
        private Transform playerPos;
        public LayerMask camadaDeAlvo;

        public void FindPlayer()
        {
            playerPos = GameObject.FindAnyObjectByType<PlayerMove>().transform;
        }

        private void Awake()
        {
            FindPlayer();
            //nextTime = Time.time + timetoProjectils;
        }


        public override void Update()
        {
            if(Time.time > nextTime )
            {
                //Debug.Log("fire enemy");
                ShootActions();
                //shoot();
                nextTime = Time.time + timetoProjectils;
            }
        }


        protected override void shoot()
        {

            
            

           
                // 3. Verifica se o objeto atingido � o player
                
                    GameObject ball = Instantiate(projectil, localGum.transform);
                    ball.GetComponent<ProjectileBase>().targetTag = targetTag;

                    ball.transform.localPosition = Vector3.zero;
                    ball.transform.position = localGum.transform.position;
                    //ball.transform.localEulerAngles = Vector3.zero + Vector3.up * (i % 2 == 0 ? angle : -angle) * mult;
                    ball.transform.parent = null;

                

                
                
            


            
                

                

        }

        private void ShootActions()
        {

            Vector3 direcaoParaOPlayer = playerPos.position - transform.position;

            // 2. Dispara um raycast
            RaycastHit hit;
            if (Physics.Raycast(transform.position, direcaoParaOPlayer, out hit, distanciaDeVisao))
            {
                // 3. Verifica se o objeto atingido � o player
                if (hit.collider.CompareTag("Player"))
                {
                    //Debug.Log("Player detectado!");
                    // Adicione a l�gica do inimigo aqui (ex: come�ar a perseguir o player)
                    shoot();

                }

                // Opcional: Desenha uma linha para depura��o na Scene View
                //Debug.DrawLine(transform.position, hit.point, Color.red);
            }

            


        }






    }


}



