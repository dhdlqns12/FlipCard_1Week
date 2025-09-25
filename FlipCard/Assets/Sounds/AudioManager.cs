using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [Header("Audio")]
    public AudioSource audioSourceBgm;
    public AudioSource audioSourceSfx;
    public AudioMixer audioMixer; //Audio Mixer 참조
    public Slider bgmSlider;      //배경음악(BGM) 슬라이더
    public Slider sfxSlider;      //효과음(SFX) 슬라이더


    [Header("AudioClip")]
    public AudioClip[] bgmclips; //bgm 클립 배열
    public AudioClip clickSound; //클릭 사운드
    public AudioClip flipSound; //카드 사운드

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

    void Start()
    {
        //저장된 볼륨값을 불러오기, 없을 경우 기본값 0.75 적용
        bgmSlider.value = PlayerPrefs.GetFloat("BGMVolume", 1f);
        sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume", 1f);
        //초기화된 슬라이더 값으로 볼륨 설정

        SetBGMVolume(bgmSlider.value);
        SetSFXVolume(sfxSlider.value);
    }

    private void Update()
    {
        //초기화된 슬라이더 값으로 볼륨 설정
        if (bgmSlider != null && sfxSlider != null)
        {
            SetBGMVolume(bgmSlider.value);
            SetSFXVolume(sfxSlider.value);
        }
    }

    private void OnsceneLoaded(Scene scene, LoadSceneMode mode)
    {
        ConnectSlider();
        PlayBGM(scene.buildIndex);
    }

    public void PlayBGM(int index)
    {
        if (bgmclips.Length > 0 && index < bgmclips.Length)
        {
            if (audioSourceBgm.clip == bgmclips[index] && audioSourceBgm.isPlaying)
                return;

            audioSourceBgm.clip = bgmclips[index];
            audioSourceBgm.loop = true;
            audioSourceBgm.Play();
        }
    }

    public void SetBGMVolume(float volume)
    {
        if (volume == 0)
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

    //카드 열 때 사운드
    public void OpenCardSFX()
    {
        audioSourceSfx.PlayOneShot(flipSound);
    }

    public void PlaySfx(AudioClip clip)
    {
        if (clip != null && audioSourceSfx != null)
        {
            audioSourceSfx.PlayOneShot(clip);
            Debug.Log("버튼 클릭음 재생");
        }
    }

    public void ConnectSlider()
    {
        GameObject bgmSliderObj = GameObject.Find("BGMSlider");
        if (bgmSliderObj != null)
        {
            bgmSlider = bgmSliderObj.GetComponent<Slider>();
            bgmSlider.value = PlayerPrefs.GetFloat("BGMVolume", 1f);
            bgmSlider.onValueChanged.RemoveAllListeners();
            bgmSlider.onValueChanged.AddListener(SetBGMVolume);

        }

        GameObject sfxSliderObj = GameObject.Find("SFXSlider");
        if (sfxSliderObj != null)
        {
            sfxSlider = sfxSliderObj.GetComponent<Slider>();
            sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume", 1f);
            sfxSlider.onValueChanged.RemoveAllListeners();
            sfxSlider.onValueChanged.AddListener(SetSFXVolume);

        }
    }
}