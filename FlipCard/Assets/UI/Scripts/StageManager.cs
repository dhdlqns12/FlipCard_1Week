using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public static StageManager Instance;

    [Header("스테이지 오브젝트")]
    public GameObject[] stageObjects;      // 1~4 스테이지 GameObject

    [Header("스테이지 해금 상태")]
    public int highestStage = 1;           // 현재 해금된 최고 스테이지

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            // DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        highestStage = SaveSystem.LoadHighestStage();
        UpdateStageUI();
    }

    // UI 갱신 - GameObject 활성/비활성
    public void UpdateStageUI()
    {
        for (int i = 0; i < stageObjects.Length; i++)
        {
            if (stageObjects[i] != null)
                stageObjects[i].SetActive(i < highestStage);
        }
    }

    // 스테이지 클리어 시 다음 스테이지 해금
    public void UnlockNextStage(int clearedStage)
    {
        if (clearedStage >= highestStage)  //클리어 스테이지 해금 
        {
            highestStage = clearedStage + 1;  // 최종 스테이지는 클리어한 스테이지 보다 +1 임
            if (highestStage > stageObjects.Length)
                highestStage = stageObjects.Length;

            UpdateStageUI();
            SaveSystem.SaveHighestStage(highestStage);
        }
    }
}



