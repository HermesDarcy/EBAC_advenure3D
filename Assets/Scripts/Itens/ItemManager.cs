using UnityEngine;
using Play.HD.Singleton;
using UnityEditor.UIElements;
using NUnit.Framework;
using System.Collections.Generic;

namespace Itens
{
    public enum itemType
    {
        coin,
        lifes,
        gems,
        item
    }

    


    public class ItemManager : Singleton<ItemManager>
    {

        public List<ItemSetup> itemSetups = new List<ItemSetup>();
       
        
        private void Start()
        {
            ResetItens();
        }


        
        public void ResetItens()
        {
            foreach (var i in itemSetups)
            {
                i.amount.value = 0;
            }

        }

        public void Addtype( itemType type, int value =1)
        {
            if (value < 0) return;
            itemSetups.Find(i => i.itemtype == type).amount.value += value;
        }


        
        public void MinusType(itemType type, int value = -1)
        {
            if (value > 0) return;
            itemSetups.Find(i => i.itemtype == type).amount.value += value;
        }

        /*
        [NaughtyAttributes.Button]
        private void addcois()
        {
            Addtype(itemType.coin, 1);
        }

        [NaughtyAttributes.Button]
        private void delCoins()
        {
            MinusType(itemType.coin, -1);
        }
        */




    }


    [System.Serializable]
    public class ItemSetup
    {
        public itemType itemtype;
        public SOint amount;
        public Sprite sprite;
        public Color color;

    
    }



}
