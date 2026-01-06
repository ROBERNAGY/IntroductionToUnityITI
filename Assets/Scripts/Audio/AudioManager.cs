using System;
using UnityEditor.SceneManagement;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (Sound sound in sounds)
        {
            sound.audioSource = gameObject.AddComponent<AudioSource>();
            sound.audioSource.clip = sound.clip;
            sound.audioSource.volume = sound.volume;
            sound.audioSource.loop = sound.loop;
            sound.audioSource.playOnAwake = sound.onAwake;
            if(sound.audioSource.loop)
            {
                sound.audioSource.Play();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Play(string _name)
    {
        Sound s = Array.Find(sounds,x=> x.name.StartsWith(_name));
        
        s.audioSource.Play();
    }
}
