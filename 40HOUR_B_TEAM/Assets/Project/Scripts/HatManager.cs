using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HatManager : MonoBehaviour
{
    [SerializeField]
    private GameObject eaglesHat;

    [SerializeField]
    private GameObject kingHat;

    [SerializeField]
    private GameObject[] normalHat = new GameObject[] { };

    private List<GameObject> generateHats = new List<GameObject>();

    private List<int> hatNumber = new List<int>();

    private void Start()
    {
        ResetHatData(0);
    }

    private void SelectedHat(int currentRound)
    {
        generateHats.Add(eaglesHat);

        if (currentRound >= HatData.KingHatGenerateRound)
        {
            generateHats.Add(kingHat);
        }

        ShuffleHat(hatNumber, 0, HatData.HatMax);
        
        for (int i = 0; i < HatData.GenerateCountInRound[currentRound]; i++)
        {
            generateHats.Add(normalHat[hatNumber[i]]);
        }

        ShuffleHat(generateHats, 0, generateHats.Count);
    }

    private List<T> ShuffleHat<T>(List<T> list, int min, int max)
    {
        for (int i = 0; i < list.Count; i++)
        {
            var randomValue = Random.Range(min, max);
            var temp = list[i];
            list[i] = list[randomValue];
            list[randomValue] = temp;
        }

        return list;
    }

    private void GenerateHat(int currentRound)
    {
        for(int i = 0; i < generateHats.Count; i++)
        {
            Instantiate(generateHats[i]);
        }
    }

    private void ResetHatData(int currentRound)
    {
        generateHats.Clear();
        hatNumber.Clear();

        for (int i = 0; i < HatData.HatMax; i++)
        {
            hatNumber.Add(i);
        }
    }

    public void LineUpHat(int currentRound)
    {
        SelectedHat(currentRound);
        GenerateHat(currentRound);
        ResetHatData(currentRound);
    }
}
