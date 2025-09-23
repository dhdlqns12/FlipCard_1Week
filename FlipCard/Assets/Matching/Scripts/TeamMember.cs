using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[System.Serializable]
public class TeamMember //팀원의 정보를 담고있는 객체(클래스)
{
    public string name; //이름
    public Sprite profileImg; //프사
    public int cardIndex; //카드 인덱스

    public TeamMember(string memberName, Sprite image, int index)
    {
        name = memberName;
        profileImg = image;
        cardIndex = index;
    }
}
