using UnityEngine;

public class SourcePlayer : MonoBehaviour
{

    public MusicTypes types;
    [SerializeField]
    private MusicSetups music;
    private AudioSource source;
    
    void Start()
    {
        source = GetComponent<AudioSource>();
        PlayClip();
    }

    [NaughtyAttributes.Button]
    private void PlayClip()
    {
        music = SoundManager.Instance.GetMusicType(types);
        source.clip = music.clip;
        source.Play();
    }


}
