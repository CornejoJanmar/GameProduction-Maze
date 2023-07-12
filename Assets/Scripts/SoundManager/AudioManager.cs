using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour //New Sound Manager
{
    public Sounds[] sounds; //Basically All of the Audio Files listed in this project

    public Sounds[] FootStepWood; //I made one specifically for the player footstep

    public static AudioManager instance; //Singleton

    void Awake()
    {
        if(instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }


        DontDestroyOnLoad(gameObject); //So that the music won't cut off in every scene

        foreach (Sounds s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume; //Don't forget to set values on inspector
            s.source.pitch = s.pitch; //and this
            s.source.loop = s.loop; //and this (depends on the situation
        }

        foreach (Sounds s in FootStepWood)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    public void Play(string name)
    {
        Sounds s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
            Debug.LogWarning($"Sound: {name} Not Found!");
            return;
        s.source.Play();
    }

    //to play sound file in any script, just use like
    // Audiomanager Audio;
    // Audio.Play("FootstepWood01");
    //or FindObjectType<AudioManager>().Play("Breath");
}
