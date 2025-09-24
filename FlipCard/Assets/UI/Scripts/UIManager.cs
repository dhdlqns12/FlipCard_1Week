using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;



    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

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

    public void QuitOption()
    {
        this.transform.parent.gameObject.SetActive(false);
    }
}
