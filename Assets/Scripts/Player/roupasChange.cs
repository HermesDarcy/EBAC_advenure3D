using UnityEngine;

public class roupasChange : MonoBehaviour
{
    public SkinnedMeshRenderer mesh;
    public Texture2D texture;
    public string nameID= "_EmissionMap";

    [NaughtyAttributes.Button]
    public void ChangeTexture(Texture2D text2d)
    {
        mesh.materials[0].SetTexture(nameID, text2d);
    }



}
