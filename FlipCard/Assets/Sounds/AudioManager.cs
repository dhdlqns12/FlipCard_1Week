using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    AudioSource audioSource;
    public AudioClip clip;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    //옵션 창에서 볼륨 조절
    public AudioMixer Mixer;
    public Slider audioSlider;

    private const float muteSound = -40f;
    private const float muteVol = -80f;

    public void AudioControl()
    {
        float sound = audioSlider.value;

        if (sound <= muteSound)
        {
            Mixer.SetFloat("BGM", muteVol);
        }
        else
        {
            Mixer.SetFloat("BGM", sound);
        }
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        audioSource.clip = this.clip;
        audioSource.Play();
        AudioControl();
    }
}


// 배경 음악(BGM) 볼륨 조절 슬라이더 + 효과음(SFX) 볼륨 조절 슬라이더
// 씬이 바뀌면 배경 음악도 바뀌게
// 씬이 넘어가도 옵션 설정 그대로, 옵션 UI도 그대로 불러오기
// 답변)
// 옵션ui를 새 캔버스에 따로 빼서 프리팹화
// 옵션 프리팹이랑 PlayerPrefs와 연동하기