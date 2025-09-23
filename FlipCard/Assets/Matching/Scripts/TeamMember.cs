using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[System.Serializable]
public class TeamMember 
{
    public string name;
    public Sprite profileImg;
    public int cardIndex;

    public TeamMember(string memberName, Sprite image, int index)
    {
        name = memberName;
        profileImg = image;
        cardIndex = index;
    }
}
