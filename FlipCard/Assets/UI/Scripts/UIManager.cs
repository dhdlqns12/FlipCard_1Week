using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public GameObject optionWindow;

    public AudioClip buttonClickSfx;
    public AudioClip CardFlipSfx;

    public void GameStart()
    {
        AudioManager.instance.PlaySfx(buttonClickSfx);
        SceneManager.LoadScene("StageScene");
    }

    public void OpenOption()
    {
        optionWindow.SetActive(true);
        AudioManager.instance.PlaySfx(buttonClickSfx);
        AudioManager.instance.ConnectSlider();
    }

    public void CloseOption()
    {
        optionWindow.SetActive(false);
        AudioManager.instance.PlaySfx(buttonClickSfx);
    }

    public void SelectStage(int num)
    {
        PlayerPrefs.SetInt("SelectStage", num);
        SceneManager.LoadScene("Main_cmp");
        AudioManager.instance.PlaySfx(buttonClickSfx);
    }

    public void StageToStart()
    {
        SceneManager.LoadScene("StartTitle 1");
        AudioManager.instance.PlaySfx(buttonClickSfx);
    }

    public void QuitGame()
    {
        AudioManager.instance.PlaySfx(buttonClickSfx);
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    public void RetryBtn()
    {
        SceneManager.LoadScene("StartTitle 1");
        AudioManager.instance.PlaySfx(buttonClickSfx);
    }

    public void StageToHiddenStage()
    {
        AudioManager.instance.PlaySfx(buttonClickSfx);
    }
}
