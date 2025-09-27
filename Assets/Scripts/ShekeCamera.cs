using Cinemachine;
using System.Collections;
using UnityEngine;
using Play.HD.Singleton;

public class ShekeCamera : Singleton<ShekeCamera>
{

    public CinemachineBrain cineBrain;
    //public CinemachineVirtualCamera vCam;
    //public CinemachineStateDrivenCamera drivenCam;


    void Start()
    {
        cineBrain = Camera.main.GetComponent<CinemachineBrain>();
    }



    
    public void OnShakeCam(float intencity=10f, float freq=10f, float times=2f)
        
    {

        ICinemachineCamera cameraToShake = null;

        // 1. Pega a câmera "principal" que está ativa
        ICinemachineCamera activeCamera = cineBrain.ActiveVirtualCamera;

        
        // 2. VERIFICA SE É O GERENTE (StateDrivenCamera)
        var stateDrivenCam = activeCamera as CinemachineStateDrivenCamera;
        if (stateDrivenCam != null)
        {
            // Se for o gerente, pegamos o "ator" em cena (a câmera-filha ativa)
            cameraToShake = stateDrivenCam.LiveChild as ICinemachineCamera;
            //Debug.Log("Shake aplicado na câmera-filha: " + cameraToShake?.Name);
        }
        else
        {
            // Se não for o gerente, significa que a câmera ativa já é a câmera final
            cameraToShake = activeCamera;
            //Debug.Log("Shake aplicado diretamente na câmera: " + cameraToShake?.Name);
        }


        var activeCam = cameraToShake as CinemachineVirtualCamera;



        if ( activeCam != null )
        {
            //.Log("achou a camera");
            StartCoroutine(TimeShake(activeCam,  intencity, freq, times));

        }

        //Debug.Log("ativou");

    }


    IEnumerator TimeShake(CinemachineVirtualCamera vCam ,float intencity = 10f, float freq = 10f, float times = 2f)
    {
        yield return new WaitForEndOfFrame();   
        var shakeCam = vCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        if (shakeCam != null)
        {
            shakeCam.m_AmplitudeGain = intencity;
            shakeCam.m_FrequencyGain = freq;
            yield return new WaitForSeconds(times);
            shakeCam.m_AmplitudeGain = 0f;
            shakeCam.m_FrequencyGain = 0f;
            Debug.Log("ativou o shake");
        }

    }





}
