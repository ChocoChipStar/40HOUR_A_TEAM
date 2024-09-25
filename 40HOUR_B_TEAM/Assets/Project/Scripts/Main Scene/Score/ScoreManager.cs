using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI[] currentScoreText = new TextMeshProUGUI[4];

    [SerializeField]
    private RoundCounter roundCounter = null;

    [SerializeField]
    private DrawScoreImage drawScoreImage = null;

    [SerializeField]
    private InputButtonManager inputButtonManager = null;

    [SerializeField]
    private HatGenerator hatGenerator = null;

    private int[] playerScores = new int[4];

    private List<int> addScores = new List<int>();

    private const int NormalHatScore = 1;
    private const int EaglesHatScore = 2;
    private const int KingHatScore = 3;

    private const string FixedName = "(Clone)";

    private void Start()
    {
        for(int i = 0; i < PlayerData.PlayerMax; i++)
        {
            addScores.Add(i);
        }
    }

    private void Update()
    {
        if(Keyboard.current.cKey.wasPressedThisFrame)
        {
            ConvertButtonNumToScore();
        }

        if(Keyboard.current.hKey.wasPressedThisFrame)
        {
            for (int i = 0; i < PlayerData.PlayerMax; i++)
            {
                playerScores[i] = Addscore(i, playerScores[i], addScores[i]);
                SetScoreText(i, playerScores[i]);
            }
        }
    }

    private int Addscore(int playerNum, int currentScore, int addValue)
    {
        drawScoreImage.SetActiveImage(playerNum, inputButtonManager.InputButtonNum[playerNum], true);
        return currentScore + addValue;
    }

    private void SetScoreText(int playerNum, int currentScore)
    {
        currentScoreText[playerNum].text = currentScore.ToString();
    }    

    /// <summary>
    /// プレイヤーが選択したボタンがスコア何点のぼうしかを確認し、変数に記録します。
    /// </summary>
    public void ConvertButtonNumToScore()
    {
        for(int i = 0; i < PlayerData.PlayerMax; i++)
        {
            if (hatGenerator.locatedHat[inputButtonManager.InputButtonNum[i] - 1].gameObject.name == HatData.EaglesHatName + FixedName)
            {
                addScores[i] = EaglesHatScore;
                continue;
            }

            if (hatGenerator.locatedHat[inputButtonManager.InputButtonNum[i] - 1].gameObject.name == HatData.KingHatName + FixedName)
            {
                addScores[i] = KingHatScore;
                continue;
            }

            addScores[i] = NormalHatScore;
        }
        
    }
}
