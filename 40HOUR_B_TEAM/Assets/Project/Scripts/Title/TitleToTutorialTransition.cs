using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;




public class TitleToTutorialTransition : MonoBehaviour
{
    [SerializeField]
    ScenechangeEffect scenechangeEffect;

    [SerializeField]
    private AudioSource titleSE;

    bool changeEffect;

    // Start is called before the first frame update
    void Start()
    {
        changeEffect = false;
    }

    // Update is called once per frame
    void Update()
    {
        // ���݂̓��͏��
        var keyboardCurrent = Keyboard.current;
        var gamepadCurrent = Gamepad.current;
        var buttonB = Gamepad.current.bButton.wasPressedThisFrame;
        var buttonA = Gamepad.current.aButton.wasPressedThisFrame;


        // �ڑ��`�F�b�N
        if (keyboardCurrent == null)
        {
            // �L�[�{�[�h���ڑ�����Ă��Ȃ���
            // Keyboard.current��null�ɂȂ�
            return;
        }


        if (gamepadCurrent == null)
        {
            //�R���g���[���[���ڑ�����Ă��Ȃ���
            //gamepadCurrent��null�ɂȂ�B
            return;
        }

        Debug.Log(keyboardCurrent.enterKey.wasPressedThisFrame);
        Debug.Log(buttonB);

        if (keyboardCurrent.enterKey.wasPressedThisFrame || buttonB)
        {

            //enter�L�[���R���g���[���[��B�{�^���������ꂽ�u�Ԃ�
            //�G�t�F�N�g���Đ�
            titleSE.Play();
            changeEffect = true;
            Debug.Log(changeEffect);

        }
        if (keyboardCurrent.spaceKey.wasPressedThisFrame || buttonA)
        {
            //space�L�[�����g���[���[��A�{�^���������ꂽ�u�Ԃ�
            //�A�v���P�[�V���������
            titleSE.Play();
            Application.Quit();
        }
        
        //�G�t�F�N�g�Đ��チ�C���V�[�������[�h
        if (scenechangeEffect.switchCount == 59)
        {
            SceneManager.LoadScene("MainScene");
        }


    }
    private void FixedUpdate()
    {
        if (changeEffect)
        {
            //�V�[���`�F���W�G�t�F�N�g���Đ�
            scenechangeEffect.ChangeEffect();
        }
    }
}
