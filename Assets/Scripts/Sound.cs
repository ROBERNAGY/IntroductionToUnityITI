using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;
    public float volume;
    public bool loop;
    public bool onAwake;
    public AudioClip clip;
    public AudioSource audioSource;
}
