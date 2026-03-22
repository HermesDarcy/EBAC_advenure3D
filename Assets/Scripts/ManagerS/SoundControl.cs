
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundControl : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider slider;

    private bool ambienteAtivo = true;
    private bool sfxAtivo = true;

    public void ToggleAmbiente()
    {
        ambienteAtivo = !ambienteAtivo;
        float volume = ambienteAtivo ? 0f : -80f;
        mixer.SetFloat("V_Music", volume);
        Debug.Log("music");
    }

    public void ToggleSFX()
    {
        sfxAtivo = !sfxAtivo;
        float volume = sfxAtivo ? 0f : -80f;
        mixer.SetFloat("MyExposedParam", volume);
        Debug.Log("sfx");
    }


    public void ChangeVol()
    {
        mixer.SetFloat("MasterVol", slider.value);
        Debug.Log("master");
    }
}
