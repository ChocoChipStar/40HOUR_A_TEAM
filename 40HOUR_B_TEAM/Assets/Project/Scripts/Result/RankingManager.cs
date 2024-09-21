using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RankingManager : MonoBehaviour
{
    [SerializeField]
    private     TextMeshProUGUI[] rankingText;

    [SerializeField]
    private int[] scores = new int[4];

    private int[] rank = new int[4];

    void Start()
    {
        DisplayRankings(scores);
    }

    void DisplayRankings(int[] scores)
    {
        // スコアをコピーしてソートする（配列のままソートするためにコピーを作成）
        int[] sortedScores = (int[])scores.Clone();
        Array.Sort(sortedScores);
        Array.Reverse(sortedScores);  // 降順にする

        string rankingResult = "";
        int rank = 1;
        for (int i = 0; i < sortedScores.Length; i++)
        {
            rankingResult = "";
            if (i > 0 && sortedScores[i] == sortedScores[i - 1])
            {
                // 同率の場合、順位は変更しない
                rankingResult += $"{rank}";
            }
            else
            {
                // 異なるスコアの場合、現在のインデックスから順位を計算  
                rank = i + 1;
                rankingResult += $"{rank}";
            }

            // TextMeshProに表示
            rankingText[i].text = rankingResult;
        }
    }
}
