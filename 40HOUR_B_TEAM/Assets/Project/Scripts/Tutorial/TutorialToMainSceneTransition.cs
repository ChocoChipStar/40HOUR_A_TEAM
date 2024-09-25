using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TutorialToMainSceneTransition : MonoBehaviour
{
    //�t�F�[�h�C���p�̕ϐ�
    private bool isFadeIn = false;

    //�t�F�[�h�A�E�g�p�̕ϐ�
    [SerializeField]
    private Image fadeOut_image;

    private float alpha;
    private bool fadeOutFlag;�@

    // Start is called before the first frame update
    void Start()
    {
        
        alpha = 0.034f; //30�t���[���ňÓ]
        fadeOutFlag = false;
        isFadeIn = true;
    }

    // Update is called once per frame
    void Update()
    {
        // ���݂̓��͏��
        var keyboardCurrent = Keyboard.current;
        var gamepadCurrent = Gamepad.current;
        var buttonA = Gamepad.current.aButton.wasPressedThisFrame;

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

        if (keyboardCurrent.enterKey.wasPressedThisFrame || buttonA)
        {

            //enter�L�[���R���g���[���[��B�{�^���������ꂽ�u�Ԃ�
            //�t�F�[�h�A�E�g�J�n
            isFadeIn = false;
            fadeOutFlag = true;
        }
        

        if (fadeOut_image.color.a >= 1)
        {
            //��ʂ��Â��Ȃ����烁�C���V�[�������[�h
            SceneManager.LoadScene("MainScene");

        }

    }

    private void FixedUpdate()
    {
        if(isFadeIn && 0 < fadeOut_image.color.a )
        {
            //�t�F�[�h�C��
            FadeIn();
        }

        if (fadeOutFlag == true && fadeOut_image.color.a < 1)
        {
            //�t�F�[�h�A�E�g
            FadeOut();
        }
    }

    void FadeIn()
    {
        //30�t���[���Ńt�F�[�h�C��
        fadeOut_image.color += new Color(0, 0, 0,-alpha);
    }
    void FadeOut()
    {
        //30�t���[���Ŋ��S�ɈÓ]����B
        fadeOut_image.color += new Color(0, 0, 0, alpha);

    }
}
