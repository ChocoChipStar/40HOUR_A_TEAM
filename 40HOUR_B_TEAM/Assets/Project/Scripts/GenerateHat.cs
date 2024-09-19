using UnityEngine;

public class GenerateHat : MonoBehaviour
{
    private const int HatMax = 10;

    private readonly int[] GenerateCountInRound = new int[] { 5, 5, 4, 4, 3 };

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private int GetRandomValue()
    {
        return Random.Range(0, HatMax);
    }

    private void Generator(int currentRound)
    {
        for(int i = 0; i < GenerateCountInRound[currentRound]; i++)
        {

        }
    }
}
