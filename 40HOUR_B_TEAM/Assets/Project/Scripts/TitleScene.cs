using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;




public class TitleScene : MonoBehaviour
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
        var buttonB = Input.GetButtonDown("Submit");
        var buttonA = Input.GetButtonDown("Cancel");


        // �ڑ��`�F�b�N
        if (keyboardCurrent == null)
        {
            // �L�[�{�[�h���ڑ�����Ă��Ȃ���
            // Keyboard.current��null�ɂȂ�
            return;
        }


        if(gamepadCurrent == null)
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
        if(keyboardCurrent.spaceKey.wasPressedThisFrame || buttonA)
        {
            //space�L�[�����g���[���[��A�{�^���������ꂽ�u�Ԃ�
            //�A�v���P�[�V���������
            Application.Quit();
        }

        
        
    }
}
