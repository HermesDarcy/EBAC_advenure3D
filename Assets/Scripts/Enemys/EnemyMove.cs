using UnityEngine;
using AnimationsHD;


namespace Enemy_Alien
{
    public class EnemyMove : EnemyBase
    { 
     
        public Transform[] wayPoints;
        public float speed =2f, minDist=1f;
        public bool onDebug = false;
        private int nPoint;



        public override void Update()
        {
            
            if (onDebug) ListenerKeys();

            OnFace();
            
            if(animeTypes != AnimeTypes.death)
            {

                transform.position = Vector3.MoveTowards(transform.position, wayPoints[nPoint].position, Time.deltaTime * speed);
                if (Vector3.Distance(transform.position, wayPoints[nPoint].position) < minDist)
                {
                    nPoint++;
                    if (nPoint >= wayPoints.Length)
                    {
                        nPoint = 0;
                    }
                }
                transform.LookAt(wayPoints[nPoint].position);
            }

            

        }


    }

}
