using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankingPlayer : MonoBehaviour
{
    [SerializeField]
    public int ranking;

    [SerializeField]
    private Animator animator;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ranking == 1)
        {
            animator.Play("run");
        }
        else if (ranking == 2)
        {
            animator.Play("Decition");
        }
        else if (ranking == 3)
        {
            animator.Play("Think");
        }
        else
        {
            animator.Play("Stand");
        }
    }
}
