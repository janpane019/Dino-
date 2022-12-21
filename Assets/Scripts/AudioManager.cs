using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public Sounds[] sounds;
    public void Awake()
    {
        foreach (Sounds sound in sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;
            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
            sound.source.loop = sound.loop;
        }
    }
    private void Start()
    {
        Play("ambient");
    }

    public void Play(string name)
    {
        Debug.Log(name + " Played");
        Sounds sound = Array.Find(sounds, s => s.name == name);
        sound.source.Play();
    }
    public void Stop(string name)
    {
        Debug.Log(name + " Stopped");
        Sounds sound = Array.Find(sounds, s => s.name == name);
        sound.source.Pause();
    }
}
