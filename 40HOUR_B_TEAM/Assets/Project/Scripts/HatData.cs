using UnityEngine;

public static class HatData
{
    private const int generatePointCount = 5;

    public static readonly int KingHatGenerateRound;

    public static readonly int[] GenerateCountInRound = new int[] { 4, 4, 3, 2, 1 };

    public static readonly Vector3[,] GeneratePosition;

    public const int HatMax = 10;

    static HatData()
    {
        KingHatGenerateRound = 3;

        GeneratePosition = new Vector3[generatePointCount];
        GeneratePosition[0] = new Vector3(-12.0f, 2.8f, -28.0f);
        GeneratePosition[1] = new Vector3(-6.0f,  2.8f, -28.0f);
        GeneratePosition[2] = new Vector3( 0.0f,  2.8f, -28.0f);
        GeneratePosition[3] = new Vector3( 6.0f,  2.8f, -28.0f);
        GeneratePosition[4] = new Vector3( 12.0f, 2.8f, -28.0f);
    }
}
