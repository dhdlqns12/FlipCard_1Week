using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Text timeTxt; //시간 표기
    public GameObject end; //끝을 알리는 화면

    [Header("카드 게임")]
    public Card firstCard; //첫번째로 뒤집은 카드
    public Card secondCard; //두번째로 뒤집은 카드
    public int matched = 0;
    public int totalPair;

    [Header("팀원 정보")]
    public List<TeamMember> teamMembers = new List<TeamMember>(); // 팀원 정보

    [Header("UI정보")]
    public GameObject sucessPanel; //성공 시 보여줄 패널
    public GameObject failPanel; //실패 시 보여줄 패널
    public GameObject teamDisplayPanel; //팀원들을 보여줄 패널
    public Transform teamMemberContainer; //팀원 UI들이 들어갈 부모 오브젝트
    public GameObject teamMemberUIPrefab; //팀원UI프리팹

    [Header("시간")]
    public Text timeTxt; //시간 표기

    [Header("점수")]
    public int score = 0; //스코어 담을 변수
    public int bestScore = 0; //베스트 스코어 담을 변수
    public Text scoreTxt; //스코어 표기
    public Text bestScoreTxt; //베스트 스코어 표기


    public int cardCount = 0; //남아 있는 카드를 카운트할 변수

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
