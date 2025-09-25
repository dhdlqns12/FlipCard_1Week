using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryButton : MonoBehaviour
{
    public AudioClip buttonClickSfx;

    public void Retry()
    {
        StartCoroutine(RetrySound());
    }

    public IEnumerator RetrySound()
    {
        AudioManager.instance.PlaySfx(buttonClickSfx);
        yield return new WaitForSeconds(0.15f);
        Debug.Log("씬 이동 직전");
        SceneManager.LoadScene("StartTitle 1");
        Debug.Log("씬 이동 직후");
    }

    public void SelectStage(int stageNum)
    {
        PlayerPrefs.SetInt("SelectStage", stageNum);
        if (stageNum >= 0)
        {
            SceneManager.LoadScene("Main_cmp");
        }
        else
        {
            SceneManager.LoadScene("HiddenStagePlayScene");
        }
        
    }
}
