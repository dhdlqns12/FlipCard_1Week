using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitGameBtn : MonoBehaviour
{
    public AudioClip clickSound;
    public AudioSource audioSource;

    public void GameExit()
    {
        StartCoroutine(PlaySoundLoad());
    }

    private IEnumerator PlaySoundLoad()
    {
        audioSource.PlayOneShot(clickSound);
        yield return new WaitForSeconds(clickSound.length);
        Application.Quit();
    }
}
