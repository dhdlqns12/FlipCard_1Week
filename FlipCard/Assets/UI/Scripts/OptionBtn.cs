using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionBtn : MonoBehaviour
{
    public GameObject optionCanvas;

    public void OpenOption()
    {
        optionCanvas.SetActive(true);
    }

    public void CloseOption()
    {
        optionCanvas.SetActive(false);
    }
}
