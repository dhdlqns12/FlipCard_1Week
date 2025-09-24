using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject objectToActivate;

    public void OnClickStart(string sceneName)
    {
        if(objectToActivate != null)
        {
            objectToActivate.SetActive(true);
        }

        // AudioManager의 코루틴을 실행하여 사운드 재생 후 씬을 로드
        StartCoroutine(AudioManager.instance.PlaySoundThenAction(
            AudioManager.instance.clickSound,
            () => {
                SceneManager.LoadScene(sceneName);
            }
        ));
    }

    public void OnClickQuit()
    {
        StartCoroutine(AudioManager.instance.PlaySoundThenAction(
            AudioManager.instance.clickSound,
            () => {
                Application.Quit();
#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
#endif
            }
        ));
    }
}
