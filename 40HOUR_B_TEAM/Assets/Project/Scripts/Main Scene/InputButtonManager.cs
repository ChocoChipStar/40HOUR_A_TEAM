using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class InputButtonManager : MonoBehaviour
{
    [SerializeField]
    private RoundCounter roundCounter;

    [SerializeField]
    private Image buttonA;
    [SerializeField]
    private Image buttonB;
    [SerializeField]
    private Image buttonX;
    [SerializeField]
    private Image buttonY;
    [SerializeField]
    private Image buttonPlus;

    [SerializeField]
    private RectTransform buttonPositionA;
    [SerializeField]
    private RectTransform buttonPositionB;
    [SerializeField]
    private RectTransform buttonPositionX;
    [SerializeField]
    private RectTransform buttonPositionY;
    [SerializeField]
    private RectTransform buttonPositionPlus;

    public readonly int[] InputButtonNum = new int[4];

    private readonly float[,] ButtonFixXPosition = new float[5, 5];

    private readonly bool[,] ButtonActive = new bool[5,5];

    private readonly float[] ButtonStartPosition = new float[] { 260.0f, 260.0f, 435.0f, 435.0f, 460.0f };

    private readonly float[] ButtonSpacePosition = new float[] { 350.0f, 350.0f, 350.0f, 350.0f, 500.0f };

    private const int ButtonANum = 0;
    private const int ButtonBNum = 1;
    private const int ButtonXNum = 2;
    private const int ButtonYNum = 3;
    private const int ButtonPlusNum = 4;

    private const float ButtonFixYPosition = 140.0f;

    private const int NonEnterState = 0;

    void Start()
    {
        for(int i = 0; i < HatData.RoundMax; i++)
        {
            for(int j = 0; j < HatData.RoundMax; j++)
            {
                ButtonFixXPosition[i,j] = ButtonStartPosition[i] + (j * ButtonSpacePosition[i]);
            }
        }

        ButtonActive[0, 0] = true;
        ButtonActive[0, 1] = true;
        ButtonActive[0, 2] = true;
        ButtonActive[0, 3] = true;
        ButtonActive[0, 4] = true;

        ButtonActive[1, 0] = true;
        ButtonActive[1, 1] = true;
        ButtonActive[1, 2] = true;
        ButtonActive[1, 3] = true;
        ButtonActive[1, 4] = true;

        ButtonActive[2, 0] = true;
        ButtonActive[2, 1] = true;
        ButtonActive[2, 2] = true;
        ButtonActive[2, 3] = true;
        ButtonActive[2, 4] = false;

        ButtonActive[3, 0] = true;
        ButtonActive[3, 1] = true;
        ButtonActive[3, 2] = true;
        ButtonActive[3, 3] = true;
        ButtonActive[3, 4] = false;

        ButtonActive[4, 0] = true;
        ButtonActive[4, 1] = true;
        ButtonActive[4, 2] = true;
        ButtonActive[4, 3] = false;
        ButtonActive[4, 4] = false;
    }

    private void Update()
    {
        //ゲームパッド接続確認
        if (Gamepad.current == null)
        {
            return;
        }
           
        var padCurrent = Gamepad.all.Count;
        for (int i = 0;i < padCurrent;i++)
        {
            if (InputButtonNum[i] != NonEnterState)
            {
                continue;
            }

            SurveyInputButtons(i);
        }
    }

    public void DrawButtonUI()
    {
        buttonA.enabled = true;
        buttonB.enabled = true;
        buttonX.enabled = true;
        buttonY.enabled = true;
        buttonPlus.enabled = true;
    }

    private void SurveyInputButtons(int surveyValue)
    {
        if (Gamepad.all[surveyValue].aButton.wasPressedThisFrame)
        {
            InputButtonNum[surveyValue] = ButtonANum;
        }
        if (Gamepad.all[surveyValue].bButton.wasPressedThisFrame)
        {
            InputButtonNum[surveyValue] = ButtonBNum;
        }
        if (Gamepad.all[surveyValue].xButton.wasPressedThisFrame)
        {
            InputButtonNum[surveyValue] = ButtonXNum;
        }

        //ラウンド5(5を含む)以上ならリターン
        if (roundCounter.GetCurrentRound() > 4)
        {
            return;
        }

        if (Gamepad.all[surveyValue].yButton.wasPressedThisFrame)
        {
            InputButtonNum[surveyValue] = ButtonYNum;
        }

        // ラウンド3(3を含まない)以上ならリターン
        if (roundCounter.GetCurrentRound() >= 2)
        {
            return;
        }

        if (Gamepad.all[surveyValue].dpad.up.wasPressedThisFrame || Gamepad.all[surveyValue].dpad.down.wasPressedThisFrame ||
            Gamepad.all[surveyValue].dpad.left.wasPressedThisFrame || Gamepad.all[surveyValue].dpad.right.wasPressedThisFrame)
        {
            InputButtonNum[surveyValue] = ButtonPlusNum;
        }
    }
    public void RelocatingButton(int currentRound)
    {
        buttonPositionA.position    = new Vector3(ButtonFixXPosition[currentRound, ButtonANum],    ButtonFixYPosition, 0);
        buttonPositionB.position    = new Vector3(ButtonFixXPosition[currentRound, ButtonBNum],    ButtonFixYPosition, 0);
        buttonPositionX.position    = new Vector3(ButtonFixXPosition[currentRound, ButtonXNum],    ButtonFixYPosition, 0);
        buttonPositionY.position    = new Vector3(ButtonFixXPosition[currentRound, ButtonYNum],    ButtonFixYPosition, 0);
        buttonPositionPlus.position = new Vector3(ButtonFixXPosition[currentRound, ButtonPlusNum], ButtonFixYPosition, 0);

        buttonA.enabled    = ButtonActive[currentRound, ButtonANum];
        buttonB.enabled    = ButtonActive[currentRound, ButtonBNum];
        buttonX.enabled    = ButtonActive[currentRound, ButtonXNum];
        buttonY.enabled    = ButtonActive[currentRound, ButtonYNum];
        buttonPlus.enabled = ButtonActive[currentRound, ButtonPlusNum];
    }
}
