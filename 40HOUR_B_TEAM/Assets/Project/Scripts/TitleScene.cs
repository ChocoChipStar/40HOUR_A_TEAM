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
        var current = Keyboard.current;
        var buttonB = Input.GetButtonDown("Submit");


        // �ڑ��`�F�b�N
        if (current == null)
        {
            // �L�[�{�[�h���ڑ�����Ă��Ȃ���
            // Keyboard.current��null�ɂȂ�
            return;
        }


        if(buttonB == false)
        {
            //�R���g���[���[���ڑ�����Ă��Ȃ���
            //buttonB��null�ɂȂ�B
            return;
        }



        //Space�L�[���R���g���[���[��B�{�^���������ꂽ�u�Ԃ�
        if (current.spaceKey.wasPressedThisFrame || buttonB)
        {
            SceneManager.LoadScene("MainScene");
        }

        
        
    }
}
