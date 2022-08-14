using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MusicType
{
    CountDown = 0,
    MainMenu = 1,
}
public class MusicManager : Singleton<MusicManager>
{
    public AudioSource audioFx;
    private void OnValidate()
    {
        if (audioFx == null)
        {
            audioFx = gameObject.AddComponent<AudioSource>();

        }
    }
    public void OnPlayMusic(MusicType musicType)
    {
        var audio = Resources.Load<AudioClip>($"Audio/Musics/{musicType.ToString()}");
        SmoothSound(audioFx, 0.5f, musicType);
    }
    public void SmoothSound(AudioSource audioSource, float fadeTime, MusicType musicType)
    {
        StartCoroutine(FadeSoundOn(audioSource, fadeTime, musicType));
    }
    IEnumerator FadeSoundOn(AudioSource audioSource, float fadeTime, MusicType musicType)
    {
        yield return FadeSoundOff(audioSource, fadeTime);

        var audio = Resources.Load<AudioClip>($"Audio/Musics/{musicType.ToString()}");

        // audioFx.loop = true;
        audioFx.clip = audio;
        audioFx.Play();

        var t = 0f;
        while (t < fadeTime)
        {
            yield return new WaitForEndOfFrame();
            t += Time.deltaTime;
            if (audioSource != null) audioSource.volume = t;
        }
    }

    IEnumerator FadeSoundOff(AudioSource audioSource, float fadeTime)
    {
        var t = fadeTime;
        while (t > 0)
        {
            yield return new WaitForEndOfFrame();
            t -= Time.deltaTime;
            if (audioSource != null) audioSource.volume = t;
        }
    }
}
