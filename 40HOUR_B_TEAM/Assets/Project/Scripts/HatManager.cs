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

    int a = 0;

    void Update()
    {
        if(Keyboard.current.enterKey.wasPressedThisFrame)
        {
            HatRandomizer(a);
            GenerateHat(a);
            ResetHatData();
        }

        if(Keyboard.current.rKey.wasPressedThisFrame)
        {
            a++;
        }
    }

    private void HatRandomizer(int currentRound)
    {
        generateHats.Add(eaglesHat);

        if (currentRound >= HatData.KingHatGenerateRound)
        {
            generateHats.Add(kingHat);
        }

        for(int i = 0; i < HatData.GenerateCountInRound[currentRound]; i++)
        {
            generateHats.Add(normalHat[Random.Range(0, HatData.HatMax)]);
        }

        for (int i = 0; i < generateHats.Count; i++)
        {
            var randomValue = Random.Range(0, generateHats.Count);

            var hat = generateHats[i];
            var randomHat = generateHats[randomValue];
            generateHats[i] = randomHat;
            generateHats[randomValue] = hat;
        }
    }

    private void GenerateHat(int currentRound)
    {
        for(int i = 0; i < generateHats.Count; i++)
        {
            Instantiate(generateHats[i]);
        }
    }

    private void ResetHatData()
    {
        generateHats.Clear();
    }
}
