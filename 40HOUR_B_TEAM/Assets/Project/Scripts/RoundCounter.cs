using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundCounter : MonoBehaviour
{
    private int currentRound = 0;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
            SetNextRound();
    }

    public void SetNextRound()
    {
        currentRound++;
    }

    public int GetCurrentRound()
    {
        return currentRound;
    }
}
