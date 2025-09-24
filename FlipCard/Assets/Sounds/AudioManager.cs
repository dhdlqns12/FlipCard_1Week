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
    public AudioMixer Mixer; //Audio Mixer 참조
    public AudioClip[] bgmclips; //bgm 클립 배열


    [Header("Option UI")]
    public GameObject optionUIPrefab; //옵션 프리팹
    private GameObject optionUIInstance;
    public Slider bgmSlider; //bgm(배경음악) 슬라이더
    public Slider sfxSlider; //sfx(효과음) 슬라이더

    private const float muteVol = -80f; //완전 뮤트 dB값

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
        SetupOptionUI();
    }

    private void SetupOptionUI()
    {
        if (optionUIPrefab == null) return;

        //기존 UI 인스턴스가 있으면 제거
        if (optionUIInstance != null)
        {
            Destroy(optionUIInstance);
        }

        //옵션 캔버스 찾기
        Canvas canvas = FindObjectOfType<Canvas>();
        if (canvas == null) return;

        //옵션 UI 인스턴스화
        optionUIInstance = Instantiate(optionUIPrefab, canvas.transform);
        optionUIInstance.SetActive(false);

        //옵션 프리팹 내부에 슬라이더와 닫기 버튼 찾기 & 연결
        bgmSlider = optionUIInstance.transform.Find("Option/BGMSlider")?.GetComponent<Slider>();
        sfxSlider = optionUIInstance.transform.Find("Option/SFXSlider")?.GetComponent<Slider>();
        Button closeButton = optionUIInstance.transform.Find("Option/CloseButton")?.GetComponent<Button>();

        //슬라이더 연결 및 값 적용
        if (bgmSlider != null)
        {
            bgmSlider.onValueChanged.RemoveAllListeners();
            bgmSlider.onValueChanged.AddListener(SetBGMVolume);
            ApplySavedVolumes(bgmSlider, "BGMVolume", SetBGMVolume);
        }

        if (sfxSlider != null)
        {
            sfxSlider.onValueChanged.RemoveAllListeners();
            sfxSlider.onValueChanged.AddListener(SetSFXVolume);
            ApplySavedVolumes(sfxSlider, "SFXVolume", SetBGMVolume);
        }

        //닫기 버튼 연결
        if (closeButton != null)
        {
            closeButton.onClick.RemoveAllListeners();
            closeButton.onClick.AddListener(ToggleOptionUI);
        }
    }

        //저장된 볼륨 적용
    private void ApplySavedVolumes(Slider slider, string playerPrefsKey, System.Action<float> setVolumeAction)
    {
        float volume = PlayerPrefs.GetFloat(playerPrefsKey, 1f);
        slider.value = volume;
        setVolumeAction(volume);
    }

    public void ToggleOptionUI()
    {
        if (optionUIInstance != null)
        {
            optionUIInstance.SetActive(!optionUIInstance.activeSelf);
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
        float dB = (volume > 0) ? Mathf.Log10(volume) * 20f : muteVol;
        Mixer.SetFloat("BGM", dB);
        PlayerPrefs.SetFloat("BGMVolume", volume);
    }

    public void SetSFXVolume(float volume)
    {
        float dB = (volume > 0) ? Mathf.Log10(volume) * 20f : muteVol;
        Mixer.SetFloat("SFX", dB);
        PlayerPrefs.SetFloat("SFXVolume", volume);
    }

    public void RegisterSlider(Slider bgm, Slider sfx)
    {
        bgmSlider = bgm;
        sfxSlider = sfx;

        ApplySavedVolumes();

        if (bgmSlider != null)
        {
            bgmSlider.onValueChanged.RemoveAllListeners();
            bgmSlider.onValueChanged.AddListener(SetBGMVolume);
        }

        if (sfxSlider != null)
        {
            sfxSlider.onValueChanged.RemoveAllListeners();
            sfxSlider.onValueChanged.AddListener(SetSFXVolume);
        }
    }

    private void ApplySavedVolumes()
    {
        if (bgmSlider != null)
        {
            float bgmVolume = PlayerPrefs.GetFloat("BGMVolume", 1f);
            bgmSlider.value = bgmVolume;
            SetBGMVolume(bgmVolume);
        }

        if (sfxSlider != null)
        {
            float sfxVolume = PlayerPrefs.GetFloat("SFXVolume", 1f);
            sfxSlider.value = sfxVolume;
            SetSFXVolume(sfxVolume);
        }
    }
}