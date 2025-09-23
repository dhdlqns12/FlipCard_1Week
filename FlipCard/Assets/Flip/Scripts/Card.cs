using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public int idx = 0;
    public GameObject front;
    public GameObject back;
    public Animator anim;

    //정수 변수상자로 변환
    // Start is called before the first frame update
    public SpriteRenderer frontImages;
    //스프라이트렌더러 프론트 변수 추가 
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    //카드 번호, 이미지
    public void Setting(int number)
    {
        idx = number;//idx 숫자
        frontImages.sprite = Resources.Load<Sprite>($"Images/{idx}");
        //frontsprite에 resources 에서 Images를 load
    }
    //카드 열었을떄
    public void OpenCard()
    {
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
        Invoke("CloseCardInvoke", 1.0f);
    }

    void CloseCardInvoke()
    {
        anim.SetBool("isOpen", false);
        front.SetActive(false);
        back.SetActive(true);
    }
}