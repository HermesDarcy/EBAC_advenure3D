using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace Itens
{


    public class ItemsSetups : MonoBehaviour
    {
        private ItemSetup _currItemSetup;
        public Image image;
        public TextMeshProUGUI texto;

        public void LoadItem(ItemSetup setup)
        {
            _currItemSetup = setup;
            UpdateUI();
            
        }

        private void UpdateUI()
        {
            image.sprite = _currItemSetup.sprite;
            Color temp = _currItemSetup.color;
            temp.a = 0.8f;
            image.color = temp;

            

        }


        private void LateUpdate()
        {
            texto.text = _currItemSetup.amount.value.ToString();
        }



    }
}
