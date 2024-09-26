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

    [SerializeField]
    private Animator titleButtonAnim;

    bool changeEffect = false;

    bool startFlag = false;

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

      

        if (keyboardCurrent.enterKey.wasPressedThisFrame && !startFlag || buttonA && !startFlag)
        {

            //enter�L�[���R���g���[���[��B�{�^���������ꂽ�u�Ԃ�
            //�G�t�F�N�g���Đ�
            titleSE.Play();
            titleButtonAnim.SetBool("Start", true);
            changeEffect = true; 
            startFlag = true;
            

        }
        
        
        //�G�t�F�N�g�Đ��チ�C���V�[�������[�h
        if (scenechangeEffect.switchCount == 59)
        {
            SceneManager.LoadScene("ConfirmControllerScene");
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
