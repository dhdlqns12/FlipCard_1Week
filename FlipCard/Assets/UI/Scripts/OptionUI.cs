using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionUI : MonoBehaviour
{
    public GameObject optionPanel;
    public AudioSource audioSource;
    public AudioClip clickSound;

    //클릭 시 옵션창 활성화
    public void OpenOption()
    {
        AudioManager.instance.BtnClickSound();
        optionPanel.SetActive(!optionPanel.activeSelf);
    }

    public void CloseOption()
    {
        AudioManager.instance.BtnClickSound();
        optionPanel.SetActive(false);
    }
}