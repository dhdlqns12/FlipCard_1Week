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

    public void HiddenButton()
    {
        SceneManager.LoadScene("HiddenStageScene");
    }
}
