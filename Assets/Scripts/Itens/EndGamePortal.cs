using UnityEngine;
using System.Collections.Generic;
using DG.Tweening;

public class EndGamePortal : MonoBehaviour
{

    public List<GameObject> toHideObjs;
    public int nextLevel = 1;
    public bool ativate = false;


    private void Awake()
    {
        //toHideObjs.ForEach(obj => obj.transform.localScale = Vector3.one*2f);
        toHideObjs.ForEach(x => x.SetActive(false));
    }



    private void OnTriggerEnter(Collider other)
    {
        PlayerMove p = other.transform.GetComponent<PlayerMove>();
        if (p != null && ativate==false)
        {
            NoHideObjs();
            ativate = true;
            SaveManager.Instance.LastLevel(nextLevel);
            SaveManager.Instance.SaveStatusPlayer();
            Invoke("ToMenu", 2f);
        }
    }

    private void NoHideObjs()
    {
        for (int i = 0; i < toHideObjs.Count; i++)
        {
            toHideObjs[i].SetActive(true);
            toHideObjs[i].transform.DOScale(0, .3f).SetEase(Ease.InElastic).From();
        }
    }


    private void ToMenu()
    {
        ManagerScene.Instance.MenuScene();
    }




}
