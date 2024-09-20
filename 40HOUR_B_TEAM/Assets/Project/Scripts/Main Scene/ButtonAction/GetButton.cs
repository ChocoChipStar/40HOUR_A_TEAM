using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;
using Unity.VisualScripting;

public class GetButton : MonoBehaviour
{
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

    [SerializeField]
    private TextMeshProUGUI debug;

    private bool getButtonA;
    private bool getButtonB;
    private bool getButtonX;
    private bool getButtonY;
    private bool getButtonPlus;

    private int round;
    private int getPlayerButton1;
    //int getPlayerButton2;
    //int getPlayerButton3;
    //int getPlayerButton4;

    void Start()
    {
        getButtonA    = false;
        getButtonB    = false;
        getButtonX    = false;
        getButtonY    = false;
        getButtonPlus = false;
        round = 0;
        getPlayerButton1 = 0;
    }

    // Update is called once per frame
    public void Update()
    {
        //�f�o�b�O�p
        if (Input.GetKeyUp(KeyCode.Z))
        {
            round++;
        }
        if (Input.GetKeyUp(KeyCode.X))
        {
            round--;
        }
        if (Input.GetKeyUp(KeyCode.R))
        {
            RoundFinish();
        }

        //debug.text = (round)ToString();

        //�Q�[���p�b�h���͂�����Ă��Ȃ�������
        if (getPlayerButton1 == 0)
        {
            //�{�^�����m
            if (Gamepad.current.aButton.wasPressedThisFrame && !getButtonA)
            {
                getButtonA = true;
                PressButtonA();
            }
            if(Gamepad.current.bButton.wasPressedThisFrame && !getButtonB)
            {
                getButtonB= true;
                PressButtonB();
            }
            if (Gamepad.current.xButton.wasPressedThisFrame && !getButtonX)
            {
                getButtonX = true;
                PressButtonX();
            }
            //���E���h5�ȏ�Ȃ甭�����Ȃ�
            if(round < 4)
            {
                if (Gamepad.current.yButton.wasPressedThisFrame && !getButtonY)
                {
                    getButtonY = true;
                    PressButtonY();
                }
                //�{�^����������ĂȂ�����3���E���h�ȏ�ł͂Ȃ�
                if (!getButtonPlus && round < 2)
                {
                    //�\���{�^���̂����ꂩ�������ꂽ
                    if (Gamepad.current.dpad.up.wasPressedThisFrame || Gamepad.current.dpad.down.wasPressedThisFrame || Gamepad.current.dpad.left.wasPressedThisFrame || Gamepad.current.dpad.right.wasPressedThisFrame)
                    {
                        getButtonPlus = true;
                        PressButtonPlus();
                    }
                }
            }
        }
    }
    //�{�^����t��v���C���[�ɐ��l����
    public void PressButtonA()
    {
        getPlayerButton1 = 1;
        buttonA.enabled = false;
    }
    public void PressButtonB()
    {
        getPlayerButton1 = 2;
        buttonB.enabled = false;
    }
    public void PressButtonX()
    {
        getPlayerButton1 = 3;
        buttonX.enabled = false;
    }
    public void PressButtonY()
    {
        getPlayerButton1 = 4;
        buttonY.enabled = false;
    }
    public void PressButtonPlus()
    {
        getPlayerButton1 = 5;
        buttonPlus.enabled = false;
    }

    public void RoundFinish()
    {
        //�v���C���[���l������
        getPlayerButton1 = 0;
        //�{�^�����͏�����
        getButtonA = false;
        getButtonB = false;
        getButtonX = false;
        getButtonY = false;
        getButtonPlus = false;
        //���E���h���ɉ�����
        if(round < 2)
        {
            //�ʒu����
            buttonPositionA.position    = new Vector3( 360, 140, 0);
            buttonPositionB.position    = new Vector3( 660, 140, 0);
            buttonPositionX.position    = new Vector3( 960, 140, 0);
            buttonPositionY.position    = new Vector3(1260, 140, 0);
            buttonPositionPlus.position = new Vector3(1560, 140, 0);
            //�\��
            buttonA.enabled    = true;
            buttonB.enabled    = true;
            buttonX.enabled    = true;
            buttonY.enabled    = true;
            buttonPlus.enabled = true;
        }
        else if(round < 4)
        {
            //�ʒu����
            buttonPositionA.position = new Vector3( 510, 140, 0);
            buttonPositionB.position = new Vector3( 810, 140, 0);
            buttonPositionX.position = new Vector3(1110 , 140, 0);
            buttonPositionY.position = new Vector3(1410 , 140, 0);
            //�\��
            buttonA.enabled    = true;
            buttonB.enabled    = true;
            buttonX.enabled    = true;
            buttonY.enabled    = true;
            buttonPlus.enabled = false;
        }
        else
        {
            //�ʒu����
            buttonPositionA.position = new Vector3( 660, 140, 0);
            buttonPositionB.position = new Vector3( 960, 140, 0);
            buttonPositionX.position = new Vector3(1260, 140, 0);
            //�\��
            buttonA.enabled    = true;
            buttonB.enabled    = true;
            buttonX.enabled    = true;
            buttonY.enabled    = false;
            buttonPlus.enabled = false;
        }
    }
}
