using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board_1 : MonoBehaviour
{
    public GameObject cardPrefab;
    public Transform board;

    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            int row = i / 5;
            int col = i % 5;

            float x = col - 2;
            float y = row * 1.5f;

            Vector3 pos = new Vector3(x, y, 0);
            GameObject card = Instantiate(cardPrefab, board);
            card.transform.localPosition = pos;
            card.name = $"Card_{i}";
        }
    }
}
