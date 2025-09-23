using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionOnBtn : MonoBehaviour
{
    public GameObject optionPanel;

    public void OnButtonClick()
    {
        optionPanel.SetActive(!optionPanel.activeSelf);
    }
}
