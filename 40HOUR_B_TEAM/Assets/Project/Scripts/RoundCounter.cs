using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundCounter : MonoBehaviour
{
    private int currentRound = 0;

    public void SetNextRound()
    {
        currentRound++;
    }

    public int GetCurrentRound()
    {
        return currentRound;
    }
}
