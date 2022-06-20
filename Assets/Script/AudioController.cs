using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioController instance;
    [SerializeField] AudioClip _mainMenuGameClip;
    [SerializeField] AudioClip _akFireClip;

    [SerializeField] AudioClip _button_Blip;
    [SerializeField] AudioClip _btton_Select;
    [SerializeField] AudioClip _button_Tap;
    [SerializeField] AudioClip _countStartGameClip;

    private AudioSource _audioSoure;
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
    void Start()
    {
        instance = this;
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
