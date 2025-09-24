using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameBtn : MonoBehaviour
{
    public AudioClip clickSound;
    public AudioSource audioSource;

    public void OnClickStart()
    {
        StartCoroutine(PlaySoundLoad());
    }

    private IEnumerator PlaySoundLoad()
    {
        audioSource.PlayOneShot(clickSound);
        yield return new WaitForSeconds(clickSound.length);
        SceneManager.LoadScene("StageScene");
    }
}
