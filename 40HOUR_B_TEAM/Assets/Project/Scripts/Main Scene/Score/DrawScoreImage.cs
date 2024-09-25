using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DrawScoreImage : MonoBehaviour
{
    [SerializeField]
    private ScoreImages[] playerNum = new ScoreImages[] { };

    [System.Serializable]
    public class ScoreImages
    {
        public Image[] addScoreImages;
    }

    void Start()
    {
        //すべてのスコア加算画像を非表示
        for(int i = 0; i < playerNum.Length - 1; i++)
        {
            for(int j = 0; j < playerNum[i].addScoreImages.Length - 1; j++)
            {
                playerNum[i].addScoreImages[j].enabled = false;
            }
        }
    }

    public void SetActiveImage(int playerNumber, int addScore, bool isActive)
    {
        playerNum[playerNumber].addScoreImages[addScore].enabled = isActive;
    }
}
