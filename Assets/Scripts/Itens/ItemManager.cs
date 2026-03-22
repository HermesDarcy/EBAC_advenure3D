using UnityEngine;
using Play.HD.Singleton;

using System.Collections.Generic;

namespace Itens
{
    public enum itemType
    {
        coin,
        lifes,
        gems,
        lifePack,
        checkPoint,
        item
    }

    


    public class ItemManager : Singleton<ItemManager>
    {

        public List<ItemSetup> itemSetups = new List<ItemSetup>();
       
        
        private void Start()
        {
            Invoke(nameof(ResetItens),.2f);
        }


        


        
        public void ResetItens()
        {
            foreach (var i in itemSetups)
            {
                i.amount.value = 0;
            }
            Addtype(itemType.coin, (int)SaveManager.Instance.savePlayer.coins);
            Addtype(itemType.gems, (int)SaveManager.Instance.savePlayer.gems);
            Addtype(itemType.lifes, (int)SaveManager.Instance.savePlayer.lives);



        }

        public void Addtype( itemType type, int value =1)
        {
            if (value < 0) return;
            itemSetups.Find(i => i.itemtype == type).amount.value += value;
            Debug.Log(type);
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
