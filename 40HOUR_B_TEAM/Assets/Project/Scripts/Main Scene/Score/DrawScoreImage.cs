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
        for(int i = 0; i < playerNum.Length; i++)
        {
            for(int j = 0; j < playerNum[i].addScoreImages.Length; j++)
            {
                playerNum[i].addScoreImages[j].enabled = false;
            }
        }
    }

    public void SetActiveImage(int playerNumber, List<int>addScores, bool isActive)
    {
        playerNum[playerNumber].addScoreImages[addScores[playerNumber] - 1].enabled = isActive;
    }
}
