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

    private void OnsceneLoaded(Scene scene, LoadSceneMode mode)
    {
        PlayBGM(scene.buildIndex);
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

    //카드 열 때 사운드
    public void OpenCardSFX()
    {
        audioSource?.PlayOneShot(flipSound);

    }

    //버튼 클릭 시 효과음 나고 행동하기
    public IEnumerator PlaySoundThenAction(AudioClip sound, System.Action onCompleteAction = null)
    {
        audioSource.PlayOneShot(sound);
        yield return new WaitForSeconds(sound.length);
        onCompleteAction?.Invoke();
    }
}