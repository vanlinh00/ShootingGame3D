using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SoundType
{
    AKFire = 0,
    ButtonBlip = 1,
    Awm = 3,
}
public class SoundManager : Singleton<SoundManager>
{
    public AudioSource audioFx;
    private void OnValidate()
    {
        if (audioFx == null)
        {
            audioFx = gameObject.AddComponent<AudioSource>();
        }
    }
    public void OnPlayAudio(SoundType soundType)
    {
        var audio = Resources.Load<AudioClip>($"Audio/Sound/{soundType.ToString()}");
        audioFx.clip = audio;
        audioFx.Play();
    }

}
