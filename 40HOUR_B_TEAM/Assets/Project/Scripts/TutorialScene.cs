using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class TutorialScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // ���݂̓��͏��
        var keyboardCurrent = Keyboard.current;
        var gamepadCurrent = Gamepad.current;
        var buttonB = Gamepad.current.bButton.wasPressedThisFrame;

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

        if (keyboardCurrent.enterKey.wasPressedThisFrame || buttonB)
        {

            //enter�L�[���R���g���[���[��B�{�^���������ꂽ�u�Ԃ�
            //���C���V�[�������[�h
            SceneManager.LoadScene("MainScene");

        }

    }
}
