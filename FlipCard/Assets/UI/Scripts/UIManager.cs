using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UIType
{
    Option,
    Title,
    Stage,
    Back,
    BackGround,
    Menu
}

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [Header("UIµÓ∑œ")]
    public List<UIType> uiTypes;
    public List<GameObject> uiObjects;

    private Dictionary<UIType, GameObject> uiDiction = new Dictionary<UIType, GameObject>();

    [Header("UI Root")]
    public Transform uiRoot;

    [Header("æ¿ Ω√¿€ Ω√ ƒ” UI")]
    public UIType[] initialActiveUI;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        if(uiRoot == null)
        {
            uiRoot = this.transform;
        }

        for(int i = 0; i<Mathf.Min(uiTypes.Count,uiObjects.Count);i++)
        {
            GameObject uiInstance = Instantiate(uiObjects[i], uiRoot);
            uiDiction[uiTypes[i]] = uiObjects[i];
            uiObjects[i].SetActive(false);
        }

        foreach (UIType ui in initialActiveUI)
        {
            if(uiDiction.ContainsKey(ui))
            {
                uiDiction[ui].SetActive(true);
            }
        }
    }

    public void ShowUI(UIType uiType)
    {
        foreach(var key in uiDiction)
        {
            key.Value.SetActive(false);
        }

        if (uiDiction.ContainsKey(uiType))
            uiDiction[uiType].SetActive(true);
    }

    public void HideUI(UIType uiType)
    {
        if (uiDiction.ContainsKey(uiType))
            uiDiction[uiType].SetActive(false);
    }

    public void ToggleUI(UIType uiType)
    {
        if (uiDiction.ContainsKey(uiType))
        {
            uiDiction[uiType].SetActive(!uiDiction[uiType].activeSelf);
        }
    }

    public GameObject GetUI(UIType uiType)
    {
        if(uiDiction.ContainsKey(uiType))
        {
            return uiDiction[uiType];           
        }
        return null;
    }
}
