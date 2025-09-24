using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public GameObject objectToActivate;
    public GameObject objectToActivate2;

    [Header("AudioUI")]
    public Slider bgmSlider; //bgm(배경음악) 슬라이더
    public Slider sfxSlider; //sfx(효과음) 슬라이더



    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

    }
    private void OnsceneLoaded(Scene scene, LoadSceneMode mode)
    {
        CheckCurrentScene();
    }

    private void Start()
    {
        //씬 로드 이벤트 구독
        SceneManager.sceneLoaded += OnsceneLoaded;
        
        //현재 씬 체크
        CheckCurrentScene();

        if (bgmSlider != null)
        {
            bgmSlider.value = PlayerPrefs.GetFloat("BGMVolume", 1f);
            bgmSlider.onValueChanged.AddListener(AudioManager.instance.SetBGMVolume);
            AudioManager.instance.SetBGMVolume(bgmSlider.value);
        }

        if (sfxSlider != null)
        {
            sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume", 1f);
            sfxSlider.onValueChanged.AddListener(AudioManager.instance.SetSFXVolume);
            AudioManager.instance.SetSFXVolume(sfxSlider.value);
        }
    }

    private void OnDestroy()
    {
        // 이벤트 구독 해제
        SceneManager.sceneLoaded -= OnsceneLoaded;
    }

    public void SelectStage(int stageNum)
    {
        PlayerPrefs.SetInt("SelectStage", stageNum);
        SceneManager.LoadScene("Main_cmp");
    }

    public void StageToStart()
    {
        SceneManager.LoadScene("StartTitle");
    }

    public void Retry()
    {
        SceneManager.LoadScene("StartTitle 1");
    }

    public void CheckCurrentScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.name == "StageScene")
        {
            objectToActivate.SetActive(true);
        }
        else
        {
            objectToActivate.SetActive(false);
        }

        if(currentScene.name == "StartTitle 1")
        {
            objectToActivate2.SetActive(true);
        }
        else
        {
            objectToActivate2.SetActive(false);
        }
    }
}
