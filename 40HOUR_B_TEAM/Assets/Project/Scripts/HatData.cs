using UnityEngine;

public static class HatData
{
    private const int GeneratePointMax = 5;

    public static readonly int KingHatGenerateRound;

    public static readonly int[] GenerateCountInRound = new int[] { 4, 4, 3, 2, 1 };

    public static readonly Vector3[,] GeneratePosition;

    public const int RoundMax = 4;

    public const int HatMax = 10;

    static HatData()
    {
        KingHatGenerateRound = 3;

        GeneratePosition = new Vector3[RoundMax, GeneratePointMax];

        GeneratePosition[0,0] = new Vector3(-12.0f, 2.8f, -28.0f);
        GeneratePosition[0,1] = new Vector3( -6.0f, 2.8f, -28.0f);
        GeneratePosition[0,2] = new Vector3(  0.0f, 2.8f, -28.0f);
        GeneratePosition[0,3] = new Vector3(  6.0f, 2.8f, -28.0f);
        GeneratePosition[0,4] = new Vector3( 12.0f, 2.8f, -28.0f);

        GeneratePosition[1,0] = new Vector3(-12.0f, 2.8f, -28.0f);
        GeneratePosition[1,1] = new Vector3( -6.0f, 2.8f, -28.0f);
        GeneratePosition[1,2] = new Vector3(  0.0f, 2.8f, -28.0f);
        GeneratePosition[1,3] = new Vector3(  6.0f, 2.8f, -28.0f);
        GeneratePosition[1,4] = new Vector3( 12.0f, 2.8f, -28.0f);
    }
}
