using UnityEngine;
using UnityEngine.InputSystem;

public class MannequinManager : MonoBehaviour
{
    [SerializeField]
    private GameObject mannequin = null;

    [SerializeField]
    private Transform parentTrans = null;

    private GameObject[] generatedMannequins = new GameObject[MannequinMax];

    private readonly int[] GenerateCountInRound = new int[] { 5, 5, 4, 4, 3 };

    private const int MannequinMax = 5;

    /// <summary>
    /// ラウンド毎で配置位置が違うため再度配置し直す処理を実行します
    /// </summary>
    /// <param name="currentRound"></param>
    public void GenerateMannequin(int currentRound)
    {
        for(int i = 0; i < parentTrans.childCount; i++)
        {
            Destroy(parentTrans.GetChild(i).gameObject);
        }

        for(int i = 0; i < GenerateCountInRound[currentRound]; i++)
        {
            var instance = Instantiate(mannequin, parentTrans);
            instance.transform.position = new Vector3(HatData.GenerateFixXPosition[currentRound,i], HatData.GenerateMannequinFixYPosition, HatData.GenerateFixZPosition);
            instance.transform.rotation = Quaternion.Euler(0.0f, -90.0f, 0.0f);
        }
    }
}
