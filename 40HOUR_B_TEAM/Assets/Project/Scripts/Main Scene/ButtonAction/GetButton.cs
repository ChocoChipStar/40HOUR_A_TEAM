using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using Unity.VisualScripting;
using System.Linq;

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

    private int round;
    int[] getPlayerButton = new int[4];


    void Start()
    {
        //������
        round = 0;
    }

    // Update is called once per frame
    public void Update()
    {
        //�Q�[���p�b�h�ڑ��m�F
        var gamepad = Gamepad.current;
        if (gamepad == null)
        {
            return;
        }
           
        var padCurrent = Gamepad.all.Count;

        //for (int i = 0; i < padCurrent; i++)
        //{
        //    if (Gamepad.all[i].aButton.wasPressedThisFrame)
        //    {
        //        if (i == 0)
        //        {
        //            Debug.Log("sucsees");
        //        }
        //    }
        //}

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


        //�Q�[���p�b�h���͂�����Ă��Ȃ�������
        for (int i = 0;i < padCurrent;i++)
        {
            if (getPlayerButton[i] == 0)
            {
                //�{�^�����m
                if (Gamepad.all[i].aButton.wasPressedThisFrame)
                {
                    getPlayerButton[i] = 1;
                    Debug.Log("Gamepad " + i);
                    Debug.Log("choose " + getPlayerButton[i]);
                }
                if (Gamepad.all[i].bButton.wasPressedThisFrame)
                {
                    getPlayerButton[i] = 2;
                    Debug.Log("Gamepad " + i);
                    Debug.Log("choose " + getPlayerButton[i]);
                }
                if (Gamepad.all[i].xButton.wasPressedThisFrame)
                {
                    getPlayerButton[i] = 3;
                    Debug.Log("Gamepad " + i);
                    Debug.Log("choose " + getPlayerButton[i]);
                }
                //���E���h5�ȏ�Ȃ甭�����Ȃ�
                if (round < 4)
                {
                    if (Gamepad.all[i].yButton.wasPressedThisFrame)
                    {
                        getPlayerButton[i] = 4;
                        Debug.Log("Gamepad " + i);
                        Debug.Log("choose " + getPlayerButton[i]);
                    }
                    //�{�^����������ĂȂ�����3���E���h�ȏ�ł͂Ȃ�
                    if (round < 2)
                    {
                        //�\���{�^���̂����ꂩ�������ꂽ
                        if (Gamepad.all[i].dpad.up.wasPressedThisFrame || Gamepad.all[i].dpad.down.wasPressedThisFrame || Gamepad.all[i].dpad.left.wasPressedThisFrame || Gamepad.all[i].dpad.right.wasPressedThisFrame)
                        {
                            getPlayerButton[i] = 5;
                            Debug.Log("Gamepad " + i);
                            Debug.Log("choose " + getPlayerButton[i]);
                        }
                    }
                }
            }
        }
        
    }

    public void RoundFinish()
    {
        //�v���C���[���l������
        getPlayerButton = new int[4];
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
