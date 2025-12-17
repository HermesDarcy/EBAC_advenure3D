using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Play.HD.Singleton;

namespace Itens
{


    public class itensBase : MonoBehaviour
    {

        public Collider Collider;
        public itemType itemType;
        public int value=1;


        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                onColleted();
            }
        }

        protected virtual void onColleted()
        {
            //this.gameObject.SetActive(false);
            Collider.enabled = false;
            ItemManager.Instance.Addtype(itemType, value);

            Invoke("HideThis", .5f);
        }


        protected virtual void MyEffect()
        {

        }



        private void HideThis()
        {
            this.gameObject.SetActive(false);
        }

    }
}

