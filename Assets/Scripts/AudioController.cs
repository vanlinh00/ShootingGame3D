using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// tim cach update cai audio controller nay  lam the nay thi rat mat cong
public class AudioController : Singleton<AudioController>
{
    [SerializeField] AudioClip _mainMenuGameClip;
    [SerializeField] AudioClip _akFireClip;

    [SerializeField] AudioClip _button_Blip;
    [SerializeField] AudioClip _btton_Select;
    [SerializeField] AudioClip _button_Tap;
    [SerializeField] AudioClip _countStartGameClip;

    private AudioSource _audioSoure;

    protected override void Awake()
    {
        base.Awake();
    }
    void Start()
    {
        _audioSoure = GetComponent<AudioSource>();
    }
    void Update()
    {

    }
    public void MainMenuGame()
    {
        _audioSoure.clip = _mainMenuGameClip;
        _audioSoure.Play();
    }
    public void OnGame()
    {
        _audioSoure.Stop();
    }
    public void AkFire()
    {
        _audioSoure.clip = _akFireClip;
        _audioSoure.Play();
    }
    public void ButtonClick()
    {
        _audioSoure.PlayOneShot(_button_Blip);
    }
    public void CountStartGame()
    {
        _audioSoure.clip = _countStartGameClip;
        _audioSoure.Play();
    }

}
