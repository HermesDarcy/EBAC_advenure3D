using Itens;
using UnityEngine;

namespace Cloths
{

    public class ClothsBase : MonoBehaviour
    {

        public RoupasType type;
        //public SfxTypes typeSfx;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                onColleted();
            }
        }

        protected virtual void onColleted()
        {
            //Debug.Log("colleted especial");
            //MyEffect();
            Invoke("HideThis",.1f);
        }
        /*
        protected virtual void MyEffect()
        {
            SfxPool.Instance.Play(typeSfx);
        }
        */


        private void HideThis()
        {
            this.gameObject.SetActive(false);
        }

    }
}
