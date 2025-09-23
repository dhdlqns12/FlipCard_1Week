using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionCloseBtn : MonoBehaviour
{
    public GameObject optionPanel;

    public void OnCloseButtonClick()
    {
        optionPanel.SetActive(false);
    }

}
