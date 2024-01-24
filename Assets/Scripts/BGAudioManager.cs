using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class BGAudioManager : MonoBehaviour
{
#nullable enable
    public AudioClip buildingAudio;
    public AudioClip levelAudio;
#nullable enable
    private AudioClip currentAudio;

    private AudioSource bgAudio;

    private void Awake()
    {
        bgAudio = GetComponent<AudioSource>();
        WaveManager.WaveCoimplete += ChangeMusic;
    }
    private void Start()
    {
        

        ChangeMusic();
        
    }
    public void SetBuildingBackground()
    {
      currentAudio = buildingAudio;
     
    }
    public void SetLevelAudio()
    {
        currentAudio = levelAudio;
    }
    public void ChangeMusic()
    {
        if(LevelManager.state == SpawnState.Building)
        {
            SetBuildingBackground();
        }
        else
        {
            SetLevelAudio();
        }
        bgAudio.clip = currentAudio;
        bgAudio.Play();
    }
}
