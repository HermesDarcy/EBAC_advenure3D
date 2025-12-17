using Itens;
using UnityEngine;

public class Item_life : itensBase
{
    [SerializeField]
    private int value;

    protected override void onColleted()
    {
        base.onColleted();
        ItemManager.Instance.Addtype(itemType.lifes,value);
        
    }
}
