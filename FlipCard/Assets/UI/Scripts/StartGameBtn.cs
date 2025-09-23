using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameBtn : MonoBehaviour
{
    public void StartGame()
    {
        //클릭 시 Main 씬으로 이동
        SceneManager.LoadScene("Main");
    }
}
