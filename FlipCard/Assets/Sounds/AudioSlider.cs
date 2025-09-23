using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioSlider : MonoBehaviour
{
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
}
