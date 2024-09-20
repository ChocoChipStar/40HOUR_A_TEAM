using UnityEngine;
using UnityEngine.InputSystem;

public class RelocationMannequin : MonoBehaviour
{
    [SerializeField]
    private GameObject mannequin = null;

    [SerializeField]
    private Transform parentTrans = null;

    private GameObject[] generatedMannequins = new GameObject[MannequinMax];

    private readonly int[] GenerateCountInRound = new int[] { 5, 5, 4, 4, 3 };

    private const int MannequinMax = 5;

    int a = 0;

    private void Update()
    {
        if(Keyboard.current.enterKey.wasPressedThisFrame)
        {
            Relocating(a);
        }

        if(Keyboard.current.rKey.wasPressedThisFrame)
        {
            a++;
        }
    }


    private void Relocating(int currentRound)
    {
        for(int i = 0; i < GenerateCountInRound[currentRound]; i++)
        {
            var instance = Instantiate(mannequin, parentTrans);
            instance.transform.position = new Vector3(HatData.GenerateFixXPosition[currentRound,i], HatData.GenerateFixYPosition, HatData.GenerateFixZPosition);
            instance.transform.rotation = Quaternion.Euler(0.0f, -90.0f, 0.0f);
        }
    }
}
