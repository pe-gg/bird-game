using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public AudioClip clip; //reference to an audio clip
    public string name; //reference name for an audio clip

    [HideInInspector] //hide public element on unity inspector
    public AudioSource source; //reference to an audio source
}