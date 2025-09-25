using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("카드 게임")]
    public Card firstCard; //첫번째로 뒤집은 카드
    public Card secondCard; //두번째로 뒤집은 카드

    [Header("UI정보")]
    public GameObject sucessPanel; //성공 시 보여줄 패널
    public GameObject failPanel; //실패 시 보여줄 패널

    [Header("시간")]
    public Text timeTxt; //시간 표기

    [Header("점수")]
    public int score = 0; //스코어 담을 변수
    public Text scoreTxt; //스코어 표기

    [Header("스테이지별 시간 설정")]
    public float[] stageTimeLimits;

    public int stageLevel = 0; //스테이지 레벨
    public int cardCount = 0; //남아 있는 카드를 카운트할 변수
    public bool isStageLevel0 = true;
    public bool isStageLevel1 = false;
    public bool isHiddenStage = false;

    public float time;

    private void Awake()
    {
        //싱글톤
        if (Instance == null)
        {
            Instance = this;
        }
        Time.timeScale = 1; // 정지 화면 초기화
        score = 0; //현재 스코어 초기화
    }

    private void Start()
    {
        int selectStage = PlayerPrefs.GetInt("SelectStage", 0);

        stageLevel = selectStage;
        StageLevel();
    }

    void Update() // 시간 증가
    {
        time -= Time.deltaTime;
        timeTxt.text = time.ToString("N2");
        if (stageLevel <= 0)
        {
            if (time <= 0) //30초를 넘을 시 게임 종료
            {
                failPanel.SetActive(true);
                stageLevel = 0; //실패 시 스테이지 레벨 0으로 초기화
                isStageLevel1 = false;
                Time.timeScale = 0;
            }
            scoreTxt.text = score.ToString(); // 현재 스코어 표기
        }
        else if (stageLevel >= 1)
        {
            if (time <= 0)
            {
                failPanel.SetActive(true);
                stageLevel = 0; //실패 시 스테이지 레벨 0으로 초기화
                isStageLevel1 = false;
                Time.timeScale = 0;
            }
            scoreTxt.text = score.ToString(); // 현재 스코어 표기
        }
        
    }

    public void Matched()
    {
        //첫번째로 뒤집은 카드와 두번째로 뒤집은 카드의 인덱스 비교
        if (firstCard.idx == secondCard.idx)
        {
            firstCard.DestroyCard();
            secondCard.DestroyCard();
            cardCount -= 2; //잔여 카드 개수 감소
            score += 2; //스코어 증가

            if (cardCount == 0) // 남아 있는 카드가 0이면
            {
                if (stageLevel == 1)
                {
                    sucessPanel.SetActive(true);
                    Time.timeScale = 0;
                    return;
                }
                else if (stageLevel == -1)
                {
                    sucessPanel.SetActive(true);
                    Time.timeScale = 0;
                    return;
                }
                else if(stageLevel==0)
                {
                    Invoke("NextStage", 1f);
                }
            }
        }
        else // 틀리면 뒤집기
        {
            firstCard.CloseCard();
            secondCard.CloseCard();
        }
        //카드값 초기화
        firstCard = null;
        secondCard = null;
    }

    public void StageLevel()
    {
        time = GetStageTimeLimit(stageLevel); // 시간 설정
        // bool 플래그 설정
        if (stageLevel == 0)
        {
            isStageLevel0 = true;
            isStageLevel1 = false;
            isHiddenStage = false;
        }
        else if (stageLevel == 1)
        {
            isStageLevel0 = false;
            isStageLevel1 = true;
            isHiddenStage = false;
        }
        else if (stageLevel == -1)
        {
            isStageLevel0 = false;
            isStageLevel1 = false;
            isHiddenStage = true;
        }
    }

    public void NextStage()
    {
        stageLevel++; //성공 시 스테이지 레벨 증가
        StageManager.Instance.UnlockNextStage(stageLevel);
        StageLevel();
    }

    float GetStageTimeLimit(int stage)
    {
        if (stage == -1)
            return 30f;

        if (stage >= 0 && stage < stageTimeLimits.Length)
            return stageTimeLimits[stage];

        return 60f;
    }
}
