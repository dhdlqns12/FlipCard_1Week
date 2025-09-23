using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnChange : MonoBehaviour
{
    //마우스 올렸을 때 이미지
    public Sprite hover_img;

    //마우스 올리지 않았을 때 이미지
    public Sprite no_hover_img;

    //현재 오브젝트에 붙어있는 image 컴포넌트를 저장할 변수
    Image thisImg; 

    // Start is called before the first frame update
    void Start()
    {
        //이 스크립트가 붙은 UI 오브젝트에서 Image 컴포넌트를 가져옴
        thisImg = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //마우스를 버튼 위에 올렸을 때 실행할 함수
    public void ChangButtonUI_In()
    {
        //버튼의 이미지를 hover_img로 교체
        thisImg.sprite = hover_img;
    }

    //마우스를 버튼에 대지 않았을 때 실행할 함수
    public void ChangButtonUI_out()
    {
        //버튼의 이미지를 no_hover_img로 교체
        thisImg.sprite = no_hover_img;
    }
}
