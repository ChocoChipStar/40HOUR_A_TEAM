using System.Collections.Generic;
using UnityEngine;

public class HatManager : MonoBehaviour
{
    [SerializeField]
    private GameObject eaglesHat;

    [SerializeField]
    private GameObject kingHat;

    [SerializeField]
    private GameObject[] normalHat = new GameObject[] { };

    private List<GameObject> generateHats = new List<GameObject>();


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void HatRandomizer(int currentRound)
    {
        generateHats.Add(eaglesHat);

        var round = HatData.GenerateCountInRound[currentRound];
        if (round >= HatData.KingHatGenerateRound)
        {
            generateHats.Add(kingHat);
        }

        for(int i = 0; i < round; i++)
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
