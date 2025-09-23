using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject end; //끝을 알리는 화면

    public Card firstCard; //첫번째로 뒤집은 카드
    public Card secondCard; //두번째로 뒤집은 카드

    public Text timeTxt; //시간 표기
    public Text scoreTxt; //스코어 표기
    public Text bestScoreTxt; //베스트 스코어 표기

    public int score = 0; //스코어 담을 변수
    public int bestScore = 0; //베스트 스코어 담을 변수
    int cardCount = 0; //남아 있는 카드를 카운트할 변수

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
        cardCount = 20; //카드 카운트 초기화
    }

    void Update() // 시간 증가
    {
        time += Time.deltaTime;
        timeTxt.text = time.ToString("N2");
        if (time >= 30) //30초를 넘을 시 게임 종료
        {
            Time.timeScale = 0;
            end.SetActive(true);
        }
        scoreTxt.text = score.ToString(); // 현재 스코어 표기
    }

    public void Matched()
    {
        if (firstCard.idx == secondCard.idx) //첫번째로 뒤집은 카드와 두번째로 뒤집은 카드의 인덱스 비교
        {
            // 같으면 삭제
            firstCard.DestroyCard();
            secondCard.DestroyCard();
            cardCount -= 2; //잔여 카드 개수 감소
            score += 2; //스코어 증가

            if (cardCount == 0) // 남아 있는 카드가 0이면
            {
                Time.timeScale = 0; //정지
                end.SetActive(true); //end 화면 띄우기


                if (score > bestScore)
                {
                    //현재 스코어가 베스트 스코어 보다 크면 베스트 스코어에 넣기
                    int oldBestScore = bestScore;
                    bestScore = score;
                    bestScoreTxt.text = score.ToString();
                }
                else
                {
                    bestScoreTxt.text = bestScore.ToString(); //베스트 스코어를 베스트 스코어에 표기
                }
            }
        }
        else
        {
            // 틀리면 뒤집기
            firstCard.CloseCard();
            secondCard.CloseCard();
        }
        //카드값 초기화
        firstCard = null;
        secondCard = null;
    }
}
