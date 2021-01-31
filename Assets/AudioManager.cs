using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    //List of sounds to access throughout game
    public Sound[] sounds;

    //Mixing Purposes
    public AudioSource sfx;
    //public AudioSource background;

    //Access across all scripts (AudioManager.instance.funcName())
    public static AudioManager instance;

    //Pitch Randomization..?

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        //Each Sound Clip gets appropraitly created
        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();

            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.playOnAwake = s.playOnAwake;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }
}
