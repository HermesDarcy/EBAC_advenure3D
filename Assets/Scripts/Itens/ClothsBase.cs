using Itens;
using UnityEngine;

namespace Cloths
{

    public class ClothsBase : MonoBehaviour
    {

        public RoupasType type;

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
            Invoke("HideThis",.1f);
        }





        private void HideThis()
        {
            this.gameObject.SetActive(false);
        }

    }
}
