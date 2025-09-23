using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public GameObject front;
    public GameObject back;
    public Animator animator;
    public SpriteRenderer frontimage;

    public void OpenCard()
    {
        front.SetActive(true); //���� ���� ��쿡 ���ӿ�����Ʈ�� ����
        back.SetActive(false);//�������� ��쿡 ���ӿ�����Ʈ�� �����
        animator.SetBool("isopen", true); // isopen�ϰ�쿡 �ִϸ��̼��� �����Ѵ�.
    }
}
