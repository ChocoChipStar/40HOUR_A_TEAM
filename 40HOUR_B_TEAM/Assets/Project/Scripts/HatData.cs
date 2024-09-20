using UnityEngine;

public static class HatData
{
    private const int GeneratePointMax = 5;

    public static readonly int KingHatGenerateRound;

    public static readonly int[] GenerateCountInRound = new int[] { 4, 4, 3, 2, 1 };

    public static readonly Vector3[,] GeneratePosition;

    public static readonly float[,] GenerateFixXPosition;

    public const float GenerateFixYPosition = 4.5f;

    public const float GenerateFixZPosition = -60.0f;

    public const int RoundMax = 4;

    public const int HatMax = 10;

    static HatData()
    {
        KingHatGenerateRound = 3;

        GeneratePosition = new Vector3[RoundMax, GeneratePointMax];

        GenerateFixXPosition[0, 0] = -12.0f;
        GenerateFixXPosition[0, 1] = -6.0f;
        GenerateFixXPosition[0, 2] = 0.0f;
        GenerateFixXPosition[0, 3] = 6.0f;
        GenerateFixXPosition[0, 4] = 12.0f;

        GenerateFixXPosition[1, 0] = -12.0f;
        GenerateFixXPosition[1, 1] = -6.0f;
        GenerateFixXPosition[1, 2] = 0.0f;
        GenerateFixXPosition[1, 3] = 6.0f;
        GenerateFixXPosition[1, 4] = 12.0f;

        GenerateFixXPosition[2, 0] = -9.0f;
        GenerateFixXPosition[2, 1] = -3.0f;
        GenerateFixXPosition[2, 2] = 3.0f;
        GenerateFixXPosition[2, 3] = 9.0f;

        GenerateFixXPosition[3, 0] = -9.0f;
        GenerateFixXPosition[3, 1] = -3.0f;
        GenerateFixXPosition[3, 2] = 3.0f;
        GenerateFixXPosition[3, 3] = 9.0f;

        GenerateFixXPosition[4, 0] = -8.5f;
        GenerateFixXPosition[4, 1] = 0.0f;
        GenerateFixXPosition[4, 2] = 8.5f;
    }
}
