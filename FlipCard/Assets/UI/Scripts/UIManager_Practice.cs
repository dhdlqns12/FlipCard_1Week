using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasePanel : MonoBehaviour //추상 클래스로 모든 UI패널의 베이스 클래스
{
    [SerializeField]
    private string panelName;

    public string PanelName => panelName;

    public virtual void ShowPanel() //가상 함수 Panel이 활성화 될 때 호출 하위 클래스에 오버라이드 하여 필요한 Init작업 수행
    {

    }

    public virtual void HidePanel() //가상 함수 Panel이 비 활성화 될 때 호출 하위 클래스에 오버라이드 하여 필요한 Init작업 수행
    {

    }
}

public class UIManager_Practice : MonoBehaviour
{
    [Header("패널 컨테이너")]
    public Transform usePanel;
    public Transform unUsePanel;

    [Header("애니메이션  설정")]
    public float animationDuration = 0.3f;
    public AnimationCurve animationCurve = AnimationCurve.EaseInOut(0, 0, 1, 1); //AinmationCurve 0초에 0으로 시작해서 1초에 1로끝남

    [Header("패널")]
    public List<BasePanel> allPanels = new List<BasePanel>();

    private BasePanel currentActivePanel;
    private Dictionary<string, BasePanel> panelDictionary;

    private void Awake()
    {
        
    }

    private void InitializePanels()
    {
        panelDictionary = new Dictionary<string, BasePanel>();

        foreach(var panel in allPanels)
        {
            panelDictionary[panel.PanelName] = panel;

        }
    }

    public void ShowPanel(string panelName, bool useAnimation=true)
    {
        if(!panelDictionary.ContainsKey(panelName))
        {
            Debug.LogError("패널 없음");
            return;
        }

        var targetPanel = panelDictionary[panelName];

        if(currentActivePanel!=null&&currentActivePanel!=targetPanel)
        { 
           
        }
    }

    public bool IsPanelActive(string panelName)
    {
        return currentActivePanel != null && currentActivePanel.PanelName == panelName;
    }
}
