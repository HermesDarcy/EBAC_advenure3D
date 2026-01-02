using UnityEngine;
using Itens;
using Cloths;

namespace Cloths
{
    public class Cloth_Strong : ClothsBase
    {
        public float changeMulti = .2f;
        public float durationForce = 5f;

        protected override void onColleted()
        {
            Debug.Log("colleted star");
            GameObject ply = GameObject.Find("Player"); // nome na hierarquia
            if (ply != null)
            {
                Debug.Log("colleted speed");
                PlayerMove plyM = ply.GetComponent<PlayerMove>();
                RoupasManager.Instance.TrocaRoupa(type, durationForce);
                plyM.StrongForce(changeMulti, durationForce);

            }
            base.onColleted();
        }
    }
}
