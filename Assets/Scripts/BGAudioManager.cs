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

    private void Start()
    {
        bgAudio = GetComponent<AudioSource>();
        
    }
    public void SetBuildingBackground()
    {
      currentAudio = buildingAudio;
      bgAudio.clip = currentAudio;
      bgAudio.Play();
    }
}
