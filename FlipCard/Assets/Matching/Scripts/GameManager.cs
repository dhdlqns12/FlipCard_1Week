using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Text timeTxt; //시간 표기
    public GameObject end; //끝을 알리는 화면

    public Card firstCard; //첫번째로 뒤집은 카드
    public Card secondCard; //두번째로 뒤집은 카드

    int cardCount = 0; //남아 있는 카드를 카운트할 변수

    public float time;

    private void Awake()
    {
        //싱글톤
        if (Instance == null)
        {
            Instance = this;
        }
        Time.timeScale = 1;
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
    }

    //public void Matched()
    //{
    //    if (firstCard.idx == secondCard.idx) //첫번째로 뒤집은 카드와 두번째로 뒤집은 카드의 인덱스 비교
    //    {
    //        // 같으면 삭제
    //        firstCard.DestroyCard();
    //        secondCard.DestroyCard();
    //        cardCount -= 2;

    //        if (cardCount == 0) // 남아 있는 카드가 0이면
    //        {
    //            Time.timeScale = 0; //정지
    //            end.SetActive(true);
    //        }
    //    }
    //    else
    //    {
    //        // 틀리면 뒤집기
    //        firstCard.ClosedCard();
    //        secondCard.ClosedCard();
    //    }
    //    //카드값 초기화
    //    firstCard = null;
    //    secondCard = null;
    //}

}
