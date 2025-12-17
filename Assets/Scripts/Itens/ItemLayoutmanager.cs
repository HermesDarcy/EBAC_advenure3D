using System.Collections.Generic;
using UnityEngine;



namespace Itens
{
    public class ItemLayoutmanager : MonoBehaviour
    {
        public List<ItemsSetups> setupsItens;
        public ItemsSetups prefabItem;
        public Transform itensLayout;



        private void Start()
        {
            CreateItnsLayout();
        }


        private void CreateItnsLayout()
        {
            foreach(var it in ItemManager.Instance.itemSetups)
            {
                var item  = Instantiate(prefabItem, itensLayout);
                item.LoadItem(it);
                setupsItens.Add(item);
            }
        }


    }
}
