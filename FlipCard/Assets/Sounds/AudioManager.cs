using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Runtime.CompilerServices;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioMixer audioMixer; //Audio Mixer 참조
    public AudioClip[] bgmclips; //bgm 클립 배열
    public Slider bgmSlider; //bgm(배경음악) 슬라이더
    public Slider sfxSlider; //sfx(효과음) 슬라이더

    private const float muteVol = -80f; //뮤트 dB값

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            PlayBGM(SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnsceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnsceneLoaded;
    }

    private void OnsceneLoaded(Scene scene, LoadSceneMode mode)
    {
        PlayBGM(scene.buildIndex);
    }


    private void Start()
    {
        if(bgmSlider != null)
        {
            bgmSlider.onValueChanged.AddListener(SetBGMVolume);
            bgmSlider.value = PlayerPrefs.GetFloat("BGMVolume", 1f);
            SetBGMVolume(bgmSlider.value);
        }

        if(sfxSlider != null)
        {
            sfxSlider.onValueChanged.AddListener(SetSFXVolume);
            sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume", 1f);
            SetSFXVolume(sfxSlider.value);
        }
    }

    public void PlayBGM(int index)
    {
        if (bgmclips.Length > 0 && index < bgmclips.Length)
        {
            audioSource.clip = bgmclips[index];
            audioSource.loop = true;
            audioSource.Play();
        }
    }

    public void SetBGMVolume(float volume)
    {
        if(volume == 0)
        {
            audioMixer.SetFloat("BGMVolume", -80f);
        }
        else
        {
            audioMixer.SetFloat("BGMVolume", Mathf.Log10(volume) * 20);
        }

        PlayerPrefs.SetFloat("BGMVolume", volume);
    }

    public void SetSFXVolume(float volume)
    {
        if (volume == 0)
        {
            audioMixer.SetFloat("SFXVolume", -80f);
        }
        else
        {
            audioMixer.SetFloat("SFXVolume", Mathf.Log10(volume) * 20);
        }

        PlayerPrefs.SetFloat("SFXVolume", volume);
    }

    //public void OpenCardSFX()
    //{
    //    if(sfxAudioSource)

    //}
}