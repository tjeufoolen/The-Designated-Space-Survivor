using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    /**
     * Code based of;
     * https://www.youtube.com/watch?v=6OT43pvUyfY
     */

    [SerializeField] private Sound[] sounds = null;

    public static AudioManager instance;

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

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    void Start()
    {
        Play("MainTheme");    
    }

    public void Play(string name)
    {
        Sound s = getSoundByName(name);
        if (s != null)
        {
            s.source.Play();
        }
    }

    public void SetSoundVolume(string name, float volume)
    {
        Sound s = getSoundByName(name);
        if (s != null) s.source.volume = volume;
    }

    public float GetSoundVolume(string name)
    {
        Sound s = getSoundByName(name);
        if (s == null) return -1;
        return s.source.volume;
    }

    private Sound getSoundByName(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning($"Sound: {name} not found!");
            return null;
        }
        return s;
    }
}
