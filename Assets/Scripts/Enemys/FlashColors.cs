using DG.Tweening;
using UnityEngine;

public class FlashColors : MonoBehaviour
{
    public MeshRenderer mesh;
    public Color color = Color.red;
    private Color initColor ;
    [SerializeField]
    private float flashTime = .2f;
    private Tween tween;


    void Start()
    {
        initColor = mesh.material.GetColor("_EmissionColor");
    }


    public void OnDamageFlash()
    {
        if(tween.IsActive() == false)
        {
            tween = mesh.material.DOColor(color, "_EmissionColor",flashTime).SetLoops(2,LoopType.Yoyo);
        }
    }


    //Debug 
    /*
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            OnDamageFlash();

        }
    }
    */
}
