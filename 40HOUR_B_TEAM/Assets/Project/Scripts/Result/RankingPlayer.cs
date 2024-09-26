using System.Collections;
using UnityEngine;

public class RankingPlayer : MonoBehaviour
{

    [SerializeField]
    private RankingUI rankingUI;

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private Material material;

    [SerializeField]
    private Texture smileSTexture;

    [SerializeField]
    private Texture smileLTexture;

    [SerializeField]
    private Texture shockTexture;

    private int playerCount;

    private const float StayTime = 0.5f;

    void Start()
    {
        playerCount = 0;
        material.mainTexture = smileSTexture;
    }

    public void PlayerRankingPosition(int count)
    {
        if (count == 1)
        {
            gameObject.transform.position = new Vector3(-5.5f, -1.3f, 0);
        }
        else if (count == 2)
        {
            gameObject.transform.position = new Vector3(-1.833333f, -1.3f, 0);
        }
        else if (count == 3)
        {
            gameObject.transform.position = new Vector3(1.833333f, -1.3f, 0);
        }
        else
        {
            gameObject.transform.position = new Vector3(5.5f, -1.3f, 0);
        }

        playerCount = count;
    }

    public void PlayerRankReaction(int rank)
    {
        StartCoroutine(RankStay(rank));
    }

    private IEnumerator RankStay(int rank)
    {
        yield return new WaitForSeconds(StayTime);

        if (rank == 1)
        {
            material.mainTexture = smileLTexture;
            rankingUI.RankingUIEnabled(rank);
            rankingUI.RankingUIPosition(playerCount);
            animator.Play("1st");
        }
        else if (rank == 2)
        {
            material.mainTexture = smileLTexture;
            rankingUI.RankingUIEnabled(rank);
            rankingUI.RankingUIPosition(playerCount);
            animator.Play("2st");
        }
        else if (rank == 3)
        {
            material.mainTexture = smileSTexture;
            rankingUI.RankingUIEnabled(rank);
            rankingUI.RankingUIPosition(playerCount);
            animator.Play("3st");
        }
        else
        {
            material.mainTexture = shockTexture;
            rankingUI.RankingUIEnabled(rank);
            rankingUI.RankingUIPosition(playerCount);
            animator.Play("4st");
        }
    }
}
