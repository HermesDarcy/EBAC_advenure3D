using System.Collections.Generic;
using UnityEngine;

public class GumTypes : MonoBehaviour
{
    public List<GameObject> guns;
    public Transform localGum;
    public string nameGum;
    public KeyCode gum1, gum2, gum3;
    public int shootType = 1;
    public int maxShoot = 5;
    public int currentShoot = 0;

    private void keysUpdate()
    {
        
        if (Input.GetKeyDown(gum1))
        {
            shootType = 1;
            


        }
        else if (Input.GetKeyDown(gum2))
        {
            shootType = 2;
           
        }
        else if (Input.GetKeyDown(gum3))
        {
            shootType = 3;
            
        }
    }











    public void CreateGum(int gum)
    {
        GumBase tempGumbase = null;
        GameObject tempGum = Instantiate(guns[gum],localGum);
               
        tempGumbase= tempGum.GetComponent<GumBase>();
        if (tempGumbase != null )
        {
            tempGumbase.localGum.transform.position = localGum.position;
        }
        else
        {
            Debug.LogError("GumBase não encontrado no objeto instanciado!");
        }
        nameGum = tempGum.name;
        tempGum.transform.parent = transform;
    }

    public void DestroyGum()
    {
        GameObject temp = GameObject.Find(nameGum);
        Destroy(temp);
    }


    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.K))
        {
            CreateGum(0);
        }

        if (Input.GetKeyUp(KeyCode.M))
        {
            DestroyGum();
        }





    }


}
