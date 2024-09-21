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
        // �X�R�A���R�s�[���ă\�[�g����i�z��̂܂܃\�[�g���邽�߂ɃR�s�[���쐬�j
        int[] sortedScores = (int[])scores.Clone();
        Array.Sort(sortedScores);
        Array.Reverse(sortedScores);  // �~���ɂ���

        string rankingResult = "";
        int rank = 1;
        for (int i = 0; i < sortedScores.Length; i++)
        {
            rankingResult = "";
            if (i > 0 && sortedScores[i] == sortedScores[i - 1])
            {
                // �����̏ꍇ�A���ʂ͕ύX���Ȃ�
                rankingResult += $"{rank}";
            }
            else
            {
                // �قȂ�X�R�A�̏ꍇ�A���݂̃C���f�b�N�X���珇�ʂ��v�Z  
                rank = i + 1;
                rankingResult += $"{rank}";
            }

            // TextMeshPro�ɕ\��
            rankingText[i].text = rankingResult;
        }
    }
}
