using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionCloseBtn : MonoBehaviour
{
    public GameObject optionPanel;

    //클릭 시 옵션 패널창 닫기
    public void OnCloseButtonClick()
    {
        optionPanel.SetActive(false);
    }

}
