using DG.Tweening;
using UnityEngine;

public class MagneticItem : MonoBehaviour
{

    public float doTime = 2f;
    public float minDistance = 1f;
    public bool activate = false;
    private Transform playerPos;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        Invoke("OnActive", doTime*2f);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerPos != null)
        {
            transform.DOMove(playerPos.position, doTime);
            
        }
    }

    private void OnActive()
    {
        activate = true;
        

    }



}
