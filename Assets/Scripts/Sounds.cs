using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sounds
{
    public string name;
    public AudioClip clip;
    public bool Loop, PlayOnAwake;
    private AudioSource source;

    public void SetSource(AudioSource _source)
    {
        source = _source;
        source.clip = clip;
        source.playOnAwake = PlayOnAwake;
        source.loop = Loop;
    }
    public void Play()
    {
        source.Play();
    }
    public void Mute()
    {
        source.mute = true;
    }
    public void UnMute()
    {
        source.mute = false;
    }
    public void Pause()
    {
        source.Pause();
    }
    public void Stop()
    {
        source.Stop();
    }

}
