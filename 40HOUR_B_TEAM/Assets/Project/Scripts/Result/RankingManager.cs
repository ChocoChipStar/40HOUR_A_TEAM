using System.Linq;
using UnityEngine;

public class RankingManager : MonoBehaviour
{
    [SerializeField]
    private RankingPlayer[] rankingPlayer;

    [SerializeField]
    private int[] scores = new int[4];

    (int index, int value)[] playerScore = new (int, int)[4];

    //private int[] rank = new int[4];

    void Start()
    {
        for (int i = 0; i < playerScore.Length; i++)
        {
            int value = scores[i];

            playerScore[i] = (i, value);
        }

        var sorted = playerScore.OrderByDescending(item => item.value)  // �܂��l�ō~���Ƀ\�[�g
                      .ThenBy(item => item.index)             // ���ɃC���f�b�N�X�����������̂�D��
                      .Select((item, rank) => (item.index, item.value, rank + 1)) // ���ʂ�1����J�n
                      .ToArray();

        // �����ʏ���
        int[] ranks = new int[4];
        int currentRank = 1; // ���݂̏���
        for (int i = 0; i < sorted.Length; i++)
        {
            // �ŏ��̗v�f�͂��̂܂܏��ʂ�t����
            if (i == 0)
            {
                ranks[sorted[i].index] = currentRank;
            }
            else
            {
                // �O�̗v�f�ƒl�������Ȃ瓯�����ʂ�t����
                if (sorted[i].value == sorted[i - 1].value)
                {
                    ranks[sorted[i].index] = currentRank;
                }
                else
                {
                    // �قȂ�l�Ȃ珇�ʂ��X�V
                    currentRank = i + 1;
                    ranks[sorted[i].index] = currentRank;
                }
            }
        }

        for (int i = 0; i < playerScore.Length; i++)
        {
            var player = sorted.First(s => s.index == i);
            var playerRank = player.Item3;

            rankingPlayer[i].PlayerRankingPosition(playerRank);
            rankingPlayer[i].PlayerRankReaction(ranks[i]);
        }
    }
}
