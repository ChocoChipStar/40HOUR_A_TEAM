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

        var sorted = playerScore.OrderByDescending(item => item.value)  // まず値で降順にソート
                      .ThenBy(item => item.index)             // 次にインデックスが小さいものを優先
                      .Select((item, rank) => (item.index, item.value, rank + 1)) // 順位を1から開始
                      .ToArray();

        // 同順位処理
        int[] ranks = new int[4];
        int currentRank = 1; // 現在の順位
        for (int i = 0; i < sorted.Length; i++)
        {
            // 最初の要素はそのまま順位を付ける
            if (i == 0)
            {
                ranks[sorted[i].index] = currentRank;
            }
            else
            {
                // 前の要素と値が同じなら同じ順位を付ける
                if (sorted[i].value == sorted[i - 1].value)
                {
                    ranks[sorted[i].index] = currentRank;
                }
                else
                {
                    // 異なる値なら順位を更新
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
