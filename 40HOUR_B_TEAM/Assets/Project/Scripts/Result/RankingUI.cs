using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class RankingUI : MonoBehaviour
{
    [SerializeField]
    private Image[] images;

    private RectTransform rectTransform;

    void Start()
    {
        for (int i = 0; i < images.Length; i++)
        {
            images[i].enabled = false;
        }

        rectTransform = GetComponent<RectTransform>();
    }

    public void RankingUIEnabled(int rank)
    {
        images[rank - 1].enabled = true;
    }

    public void RankingUIPosition(int count)
    {
        if (count == 1)
        {
            Vector2 pos = Vector2.zero;
            pos.x = -600;
            pos.y = -230;
            rectTransform.anchoredPosition = pos;

        }
        else if (count == 2)
        {
            Vector3 pos = Vector3.zero;
            pos.x = -200;
            pos.y = -230;
            rectTransform.anchoredPosition = pos;
        }
        else if (count == 3)
        {
            Vector3 pos = Vector3.zero;
            pos.x = 200;
            pos.y = -230;
            rectTransform.anchoredPosition = pos;
        }
        else
        {
            Vector3 pos = Vector3.zero;
            pos.x = 600;
            pos.y = -230;
            rectTransform.anchoredPosition = pos;
        }
    }
}
