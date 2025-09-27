using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using Play.HD.Singleton;
using System.Collections;
using UnityEditor.Rendering.Analytics;

public class PostProcessingManager : Singleton<PostProcessingManager>
{

    public PostProcessVolume ppVolume;
    public Vignette vignette;
    public ColorGrading colorGrading;
    public float timeFlash;




    private void Start()
    {
        Vignette tmp;
        if (ppVolume.profile.TryGetSettings<Vignette>(out tmp))
        {
            vignette = tmp;


        }

        ColorGrading tmp2;
        if (ppVolume.profile.TryGetSettings<ColorGrading>(out tmp2))
        {
            colorGrading = tmp2;


        }

    }


    [NaughtyAttributes.Button]
    public void flashVignette()
    {
        StartCoroutine(flashColors());

    }


    IEnumerator flashColors()
    {
       

        ColorParameter cp = new ColorParameter();
        //cp.value = Color.red;
        //vignette.color.Override(cp);

        float time = 0;
        while(time < timeFlash)
        {
            cp.value = Color.Lerp(vignette.color, Color.red, time / timeFlash);
            vignette.color.Override(cp);
            time += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        time = 0;
        while (time < timeFlash*2)
        {
            cp.value = Color.Lerp(Color.red, Color.white, time / timeFlash*2);
            vignette.color.Override(cp);
            time += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }


    }

    // Color Grading
    public void DownSaturation()
    {
       colorGrading.saturation.value -= 18f ;

        
    }

    public void resetSaturation()
    {
        colorGrading.saturation.value = 0;
    }




}
