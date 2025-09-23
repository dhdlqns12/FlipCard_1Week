using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clicksound : MonoBehaviour
{
    AudioSource audiosource;

    private void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }

    public void ClickSound()
    {
        audiosource.Play();
    }
}
