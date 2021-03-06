﻿using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;

    //Base of Sound Class.
    public AudioClip clip;
    public AudioMixer output;

    [Range(0f, 1f)]
    public float volume;
    [Range(.1f, 3f)]
    public float pitch;
    [HideInInspector]
    public AudioSource source;

    public bool playOnAwake;
    public bool loop;

}

