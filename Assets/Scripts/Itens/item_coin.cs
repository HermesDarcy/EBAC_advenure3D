using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Play.HD.Singleton;
using Itens;

public class item_coin : itensBase
{

    [SerializeField]
    public int coins;

    protected override void onColleted()
    {
        base.onColleted();
        ItemManager.Instance.Addtype(itemType.coin, coins);
        
    }

    
}
