using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionOnBtn : MonoBehaviour
{
    public GameObject optionPanel;

    //클릭 시 옵션창 활성화
    public void OnButtonClick()
    {
        optionPanel.SetActive(!optionPanel.activeSelf);
    }
}
