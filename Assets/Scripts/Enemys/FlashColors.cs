using DG.Tweening;
using UnityEngine;

public class FlashColors : MonoBehaviour
{
    public MeshRenderer mesh;
    public SkinnedMeshRenderer skinnedMesh;
    public Color color = Color.red;
    public string element = "_EmissionColor";
    private Color initColor ;
    [SerializeField]
    private float flashTime = .2f;
    private Tween tween;


    void Start()
    {
        //initColor = mesh.material.GetColor("_EmissionColor");
        skinnedMesh = GetComponent<SkinnedMeshRenderer>();
    }


    public void OnDamageFlash()
    {
        if(tween.IsActive() == false && mesh != null)
        {
            tween = mesh.material.DOColor(color, element, flashTime).SetLoops(2,LoopType.Yoyo);
        }
        else if (skinnedMesh != null && tween.IsActive() == false)
        {
            tween = skinnedMesh.material.DOColor(color, element, flashTime).SetLoops(2, LoopType.Yoyo);

        }

    }

    [NaughtyAttributes.Button]
    protected virtual void ColorFlassh()
    {
        tween = mesh.material.DOColor(color, element, flashTime).SetLoops(2, LoopType.Yoyo);
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
