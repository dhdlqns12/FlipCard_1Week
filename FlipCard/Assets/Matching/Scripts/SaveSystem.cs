using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    public static void SaveHighestStage(int highestStage)
    //스테이지 해금 상태를 저장(최고 해금 스테이지로 번호를 저장)
    {
        PlayerPrefs.SetInt("HighestStage", highestStage);
        //가장 높은 최고 스테에지로 저장 stage=키 스테이지 값 기록.
        PlayerPrefs.Save();
        //plyerprefs 저장 기록
    }
    public static int LoadHighestStage()
    {
        return PlayerPrefs.GetInt("HighestStage", 1);
        //HighestStage로 저장된 값 불러오고,게임을 처음 시작하면 기본 최고 스테이지는 1
    }
}
