using Itens;
using UnityEngine;

namespace Cloths
{
    public class ClothSpeed : ClothsBase
    {

        public float speed =3f, duration = 3f;
        //public RoupasType type;

        protected override void onColleted()
        {
            Debug.Log("colleted star");
            GameObject ply = GameObject.Find("Player"); // nome na hierarquia
            if (ply != null )
            {
                Debug.Log("colleted speed");
                PlayerMove plyM = ply.GetComponent<PlayerMove>();
                RoupasManager.Instance.TrocaRoupa(type,duration);
                plyM.NewSpeed(speed,duration);
            }
            base.onColleted();
        }


        


    }
}
