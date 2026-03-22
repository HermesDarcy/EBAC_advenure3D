using UnityEngine;
using Play.HD.Singleton;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SfxPool : Singleton<SfxPool>
{
    public int PoolCount =  10;
    public AudioMixerGroup sfxGroup;
    private int _index = 0;
    private List<AudioSource> _sourceList;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CreatePoolSource();
    }

    private void CreatePoolSource()
    {
        _sourceList = new List<AudioSource>();
        for (int i = 0; i < PoolCount; i++)
        {
            CreatePoolItem();
        }
    }




    private void CreatePoolItem()
    {
        GameObject tmp = new GameObject("SFX_source");
        tmp.transform.parent = this.transform;
        AudioSource newSource = tmp.AddComponent<AudioSource>();
        newSource.outputAudioMixerGroup = sfxGroup;
        _sourceList.Add(newSource);
        
    }



    public void Play(SfxTypes type)
    {
        var sfx = SoundManager.Instance.GetSfx(type);
        _sourceList[_index].clip = sfx.clip;
        _sourceList[_index].Play();
        _index++;
        if (_index == PoolCount) _index = 0;
    }

}
