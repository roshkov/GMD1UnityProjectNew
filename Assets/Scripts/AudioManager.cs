using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{


    public Sound[] sounds;
    public string LevelSoundsTag;
    public AudioMixerGroup Mixer;
   
    void Start () {
         foreach (Sound s in sounds) {
             if (s.name.Contains(LevelSoundsTag)) {
                    Play (s.name);
             }
         }
    }

    void Awake()
    {
        foreach (Sound s in sounds) {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            // s.source.outputAudioMixerGroup = s.outputAudioMixerGroup;
            s.source.outputAudioMixerGroup = Mixer; 

        }
    }

    public void Play (string name) {
        //find sound in sounds, where sound.name==name
        Sound s = Array.Find(sounds, sound => sound.name == name); 
        if (s == null) {
            Debug.LogWarning("Sound '" + name + "' not found");
            return;
        }
        s.source.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
