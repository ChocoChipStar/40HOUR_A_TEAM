using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using System.Xml.Serialization;
using System.Runtime.CompilerServices;

public class ResultSelectScript : MonoBehaviour
{
    

    //�T�E���h
    [SerializeField]
    private AudioSource music = null;
    [SerializeField]
    private AudioSource selectSound = null;
    [SerializeField]
    private AudioSource fanfareSound = null;

    //�{�^���I�u�W�F�N�g
    [SerializeField]
    private GameObject retryButtonObj;
    [SerializeField]
    private GameObject titleButtonObj;

    //�{�^���A�C���[�W�R���|�[�l���g
    [SerializeField]
    private Button retryButton;

    [SerializeField]
    private Button titleButton;

    [SerializeField]
    private Image retryImage;

    [SerializeField]
    private Image titleImage;

    //�t�F�[�h�A�E�g�p�C���[�W�R���|�[�l���g
    [SerializeField]
    private Image fadeOutImage;

    
    //�A�j���[�V�����Đ��p
    private Animator resultButtonAnimator;

    //�A�j���[�V�����p�t���O
    private bool finishedPlaying = false;

    //�Z���N�g�t���O
    public bool isSelect = false;

    //�t�F�[�h�A�E�g�p�t���O
    private bool isTitle = false;
    private bool isRetry = false;

    //�X�e�B�b�N���̓t���O
    private bool leftStick = false;
    private bool rightStick = false;

    //�t�F�[�h�A�E�g�p�@�摜�̓����x�̕ω��l
    private float alpha = 0.01f; 

    //�{�^����\��
    void Start()
    {
        retryButton.enabled = false;
        titleButton.enabled = false;
        retryImage.enabled = false;
        titleImage.enabled = false;
        fanfareSound.Play();
        resultButtonAnimator = GetComponent<Animator>();
        Invoke("ButtonActive", 4);
    }

    //�{�^����\��
    public void ButtonActive()
    {
        retryButton.enabled = true;
        titleButton.enabled = true;
        retryImage.enabled = true;
        titleImage.enabled = true;
        music.Play();
    }

    //�Q�[���p�b�h���͎�t
    private void Update()
    {

        var gamepadCurrent = Gamepad.current;

        if(gamepadCurrent == null)
        {
            return;
        }

        //Debug.Log(Gamepad.current.leftStick.ReadValue().x);
        if(Gamepad.current.leftStick.ReadValue().x > 0.2f && !isSelect)
        {
            leftStick = true;

            
        }
        else if(Gamepad.current.leftStick.ReadValue().x < -0.2f && !isSelect)
        {
            rightStick = true;

           
            
        }
        else
        {
            leftStick = false;
            rightStick = false;

            
        }

        if (leftStick)
        {
            EventSystem.current.SetSelectedGameObject(retryButtonObj);

            resultButtonAnimator.SetBool("onLeft", true);
            resultButtonAnimator.SetBool("onRight", false);

           
        }
        else if (rightStick)
        {
            EventSystem.current.SetSelectedGameObject(titleButtonObj);

            resultButtonAnimator.SetBool("onLeft", false);
            resultButtonAnimator.SetBool("onRight", true);

            
        }

        finishedPlaying = FinishedPlaying();�@//�{�^���I���A�j���[�V�������Đ������ǂ��������m����B

        if (isSelect && isTitle && fadeOutImage.color.a < 1)
        {
            

            fadeOutImage.color += new Color(0, 0, 0, alpha);

        }
        else if(isSelect && isTitle && fadeOutImage.color.a >= 1 )
        {
            //���S�ɈÓ]�����P�b��ɃV�[���J��
            Invoke("ForTitleScene", 1); �@
        }

        if (isSelect && isRetry && fadeOutImage.color.a < 1)
        {


            fadeOutImage.color += new Color(0, 0, 0, alpha);

        }
        else if (isSelect && isRetry && fadeOutImage.color.a >= 1)
        {
            //���S�ɈÓ]�����P�b��ɃV�[���J��
            Invoke("ForMainScene", 1);
        }


    }

   
    //�^�C�g���֑J��
    public void TitleOnclick()
    {

        if (!isSelect && finishedPlaying)
        {
            selectSound.Play();
            isSelect = true;
            isTitle = true;

            resultButtonAnimator.SetBool("decideTitle", true);

        }
       
    }
    public void ForTitleScene()
    {
        SceneManager.LoadScene("TitleScene");
    }

    //���C���V�[���֑J��
    public void RetryOnclick()
    {

        if (!isSelect && finishedPlaying)
        {
            selectSound.Play();
            isSelect = true;
            isRetry = true;
            
           
        }
    }
   

    private void ForMainScene()
    {
        SceneManager.LoadScene("MainScene");
        resultButtonAnimator.SetBool("decideRetry", true);
    }

    private bool FinishedPlaying()
    {
        //�{�^���I���A�j���[�V�������Đ������ǂ��������m����B
        if (resultButtonAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime <= 2.5)
        {
            return false;
        }else
        {  
            return true; 
        }

           
    }
}
