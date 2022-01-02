using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;


public class audio : MonoBehaviour
{
 
    public sound[] sounds;
    void Awake()
    {
        foreach (sound s in sounds)
        {
            s.source=gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = SaveManager.instance.Volume*s.volume; 
            s.source.pitch = s.pitch;
            s.source.mute = !SaveManager.instance.mute;
        }
    }


    public void Play(string name)
    {
      sound s= Array.Find(sounds,sound=>sound.name==name);
        s.source.Play();
    }
   
}
