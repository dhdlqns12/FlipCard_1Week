using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.SceneManagement;
using UnityEngine;

public class Board_1 : MonoBehaviour
{
    public GameObject cardPrefab;
    public Transform board;
    public Animator animator;
    void Start()
    {
        
    }

    void Update()
    {
        if (GameManager.Instance.isStageLevel0)
        {
            Stage0();
            GameManager.Instance.isStageLevel0 = false; //반복 실행 막기 위한 장치
        }
        else if (GameManager.Instance.isStageLevel1)
        {
            Invoke("Stage1", 1f);
            GameManager.Instance.timeTxt.gameObject.SetActive(false); //다음 스테이지 실행 예열할 동안 시간 지나는 것 막기
            GameManager.Instance.isStageLevel1 = false;
        }
        else if (GameManager.Instance.isHiddenStage)
        {
            HiddenStage();
            GameManager.Instance.isHiddenStage = false;
        }
    }
    
    public void HiddenStage()
    {
        int[] arr = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4 };
        arr = arr.OrderBy(x => Random.Range(0f, 4f)).ToArray();

        for (int i = 0; i < 10; i++)
        {
            int row = i / 5;
            int col = i % 5;

            float x = col - 2;
            float y = (row + 2.5f) * 1.5f;

            Vector3 pos = new Vector3(x, y, 0);
            GameObject card = Instantiate(cardPrefab, board);
            card.transform.localPosition = pos;
            card.name = $"HiddenCard_{i}";
            card.GetComponent<Card>().HiddenSetting(arr[i]);
            animator.Play("carddrop",0,0f); //play를 사용해서 이 스크립트를 실행할 때 "carddrop을 실행한다.
        }
        GameManager.Instance.cardCount = arr.Length;
    }

    public void Stage0()
    {
        int[] arr = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4 };
        arr = arr.OrderBy(x => Random.Range(0f, 4f)).ToArray();

        for (int i = 0; i < 10; i++)
        {
            int row = i / 5;
            int col = i % 5;

            float x = col - 2;
            float y = row + 4.5f;

            Vector3 pos = new Vector3(x, y, 0);
            GameObject card = Instantiate(cardPrefab, board);
            card.transform.localPosition = pos;
            card.name = $"Card_{i}";
            card.GetComponent<Card>().Setting(arr[i]);
        }
        GameManager.Instance.cardCount = arr.Length;

    }

    public void Stage1()
    {
        GameManager.Instance.timeTxt.gameObject.SetActive(true); //함수 실행과 동시에 시간 카운트다운
        int[] arr = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8, 9, 9 };
        arr = arr.OrderBy(x => Random.Range(0f, 9f)).ToArray();

        for (int i = 0; i < 20; i++)
        {
            int row = i / 5;
            int col = i % 5;

            float x = col - 2;
            float y = (row + 3.25f);

            Vector3 pos = new Vector3(x, y, 0);
            GameObject card = Instantiate(cardPrefab, board);
            card.transform.localPosition = pos;
            card.name = $"Card_{i}";
            card.GetComponent<Card>().Setting(arr[i]);
            animator.Play("carddrop",0,0f); //play를 사용해서 이 스크립트를 실행할 때 "carddrop을 실행한다.
        }
        GameManager.Instance.cardCount = arr.Length;
        
    }

}
