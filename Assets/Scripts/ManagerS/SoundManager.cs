using System.Collections.Generic;

using UnityEngine;
using Play.HD.Singleton;

public class SoundManager : Singleton<SoundManager>
{
    public List<MusicSetups> setupMusic;
    public List<SfxSetups> setupSfx;
    public AudioSource musicSource, sfxSource;

    public MusicSetups msntype;

    [NaughtyAttributes.Button]
    private void playm()
    {
        PlayMusictype(msntype.type);
    }



    public void PlayMusictype(MusicTypes type)
    {
        var tmp = GetMusicType(type);
        musicSource.clip = tmp.clip;
        musicSource.Play();
    }

    public void PlaySFXtype(SfxTypes type)
    {
        var tmp = GetSfx(type);
        sfxSource.clip = tmp.clip;
        sfxSource.Play();
    }


    public MusicSetups GetMusicType(MusicTypes type)
    {
        return setupMusic.Find(i => i.type == type);
    }

    public SfxSetups GetSfx(SfxTypes type)
    {
        return setupSfx.Find(i => i.type == type);  
    
    }


}




public enum MusicTypes
{
    None,
    type1,
    type2,
    type3
}

public enum SfxTypes
{
    None,
    coin,
    type1,
    type2,
    type3,
    gunner,
    impact
}


[System.Serializable]
public class MusicSetups
{
    public MusicTypes type;
    public AudioClip clip;
}



[System.Serializable]

public class SfxSetups
{
    public SfxTypes type;
    public AudioClip clip;
}
