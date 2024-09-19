using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TutorialToMainSceneTransition : MonoBehaviour
{
    //�t�F�[�h�A�E�g�p�̕ϐ�
    private GameObject fadeOutImage;
    private Image fadeOut_image;
    private Color alpha;
    private bool fadeOutFlag;�@

    // Start is called before the first frame update
    void Start()
    {
        GameObject fadeOutImage = GameObject.Find("FadeOut");
        fadeOut_image = fadeOutImage.GetComponent<Image>();

        alpha = new Color(0.0f, 0.0f, 0.0f, 0.002f);
        fadeOutFlag = false;
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
            //�t�F�[�h�A�E�g�J�n
            fadeOutFlag = true;
        }

        if (fadeOutFlag == true && fadeOut_image.color.a < 1)
            {
            //�t�F�[�h�A�E�g
                FadeOut();
            }

            
            if (fadeOut_image.color.a >= 1)
            {
            //��ʂ��Â��Ȃ����烁�C���V�[�������[�h

            SceneManager.LoadScene("MainScene");

            }

    }

    void FadeOut()
    {
        //�C���[�W�̓����x��������������
            fadeOut_image.color += alpha;
        
    }
}
