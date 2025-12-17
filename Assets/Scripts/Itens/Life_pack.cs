using Itens;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Life_pack : MonoBehaviour
{
    public KeyCode key;
    public PlayerMove playerMove;
    public itemType type;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(key))
        {
            int k = ItemManager.Instance.itemSetups.Find(i => i.itemtype == type).amount.value;



            if (playerMove.lives!=playerMove.initLives && k >0)
            {
                playerMove.ResetLifes();
                ItemManager.Instance.MinusType(type);
                
            }
        }
    }
}
