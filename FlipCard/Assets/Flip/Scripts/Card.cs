using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Card : MonoBehaviour
{
    public int idx = 0;
    public GameObject front;
    public GameObject back;
    public Animator anim;
    bool isopen = false;
    float speed;

    //정수 변수상자로 변환
    // Start is called before the first frame update
    public SpriteRenderer frontImages;
    //스프라이트렌더러 프론트 변수 추가 
    void Start()
    {
        speed = 1.0f - (GameManager.Instance.stageLevel * 0.1f); //스테이지 증가할 때마다 스피드의 값이 적어짐
    }

    // Update is called once per frame
    void Update()
    {
        if (isopen && transform.eulerAngles.y >= 90.0f) //isopen이 트루이고 트랜지션에 y회전값이 90도 이거나 이상일 때
        {
            front.SetActive(true); //front setactive 실행하고
            back.SetActive(false); //back을 없앤ek
        }
    }
    //카드 번호, 이미지
    public void Setting(int number)
    {
        idx = number;//idx 숫자
        frontImages.sprite = Resources.Load<Sprite>($"team{idx}");
        //frontsprite에 resources 에서 Images를 load
    }

    public void HiddenSetting(int number)
    {
        idx = number;//idx 숫자
        frontImages.sprite = Resources.Load<Sprite>($"hiddenTeam{idx}");
        //frontsprite에 resources 에서 Images를 load
    }
    
    //카드 열었을떄
    public void OpenCard()
    {
        anim.SetBool("isOpen", true); //함수 실행시 애니메이션 실행
        isopen = true; // isopen값이 트루가 된다. 애니메이션 관련 bool값


        //firstcard가 빈 상황      null==빈 상태
        if (GameManager.Instance.firstCard == null)
        {
            // firstCard에 정보를 넘겨줌
            GameManager.Instance.firstCard = this;
        }
        else
        {
            //secondCard에 정보를 넘겨줌
            GameManager.Instance.secondCard = this;
            // Mached 함수를 호출
            GameManager.Instance.Matched();
        }
    }

    public void HiddenOpenCard()
    {
        //AudioManager.instance.OpenCardSFX(); //히든 스테이지에서 카드 클릭시 여기서 오류가 떠서 새로 함수를 만듦
        anim.SetBool("isOpen", true);
        front.SetActive(true);
        back.SetActive(false);


        //firstcard가 빈 상황      null==빈 상태
        if (GameManager.Instance.firstCard == null)
        {
            // firstCard에 정보를 넘겨줌
            GameManager.Instance.firstCard = this;
        }
        else
        {
            //secondCard에 정보를 넘겨줌
            GameManager.Instance.secondCard = this;
            // Mached 함수를 호출
            GameManager.Instance.Matched();
        }
    }

    //키드 제거 상황
    public void DestroyCard()
    {
        Invoke("DestroyCardInvoke", 1.0f);
    }

    void DestroyCardInvoke()
    {
        Destroy(gameObject);
    }

    public void CloseCard()
    {
        Debug.Log(speed);
        Invoke("CloseCardInvoke", speed); //보여주는 시간
    }

    void CloseCardInvoke()
    {
        isopen = false;
        
        anim.SetBool("isOpen", false);
        front.SetActive(false);
        back.SetActive(true);
    }
}