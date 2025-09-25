using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryButton : MonoBehaviour
{
    public void Retry()
    {
        SceneManager.LoadScene("StartTitle 1");
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
