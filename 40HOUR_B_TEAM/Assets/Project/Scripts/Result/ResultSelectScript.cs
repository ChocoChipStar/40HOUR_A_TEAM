using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Xml.Serialization;

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

    //�t�F�[�h�p�C���[�W�R���|�[�l���g
    [SerializeField]
    private Image fadeOutImage;

    Animator resultButtonAnimator = null;

    //�Z���N�g�t���O
    public bool isSelect = false;

    //�t�F�[�h�C���p�t���O
    private bool isFadeIn = false;

    //�t�F�[�h�A�E�g�p�t���O
    private bool isTitle = false;
    private bool isRetry = false;

    //�X�e�B�b�N���̓t���O
    private bool leftStick = false;
    private bool rightStick = false;

    //�t�F�[�h�p�@�摜�̓����x�̕ω��l
    private float fadeInA = 0.05f;    //20�t���[���Ńt�F�[�h�C��
    private float fadeOutA = 0.0167f;  //60�t���[���ňÓ]

    //�t�@���t�@�[����炷�܂ł̑҂�����
    private const float StayTime = 0.5f;

    //�{�^����\��
    void Start()
    {
        retryButton.enabled = false;
        titleButton.enabled = false;
        retryImage.enabled = false;
        titleImage.enabled = false;
        isFadeIn = true;
        resultButtonAnimator = GetComponent<Animator>();
        Invoke("ButtonActive", 4);
        StartCoroutine(FanFare());
    }

    private IEnumerator FanFare()
    {
        yield return new WaitForSeconds(StayTime);

        fanfareSound.Play();

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
            resultButtonAnimator.SetBool("onRight", false);
            resultButtonAnimator.SetBool("onLeft", true);
        }
        else if(Gamepad.current.leftStick.ReadValue().x < -0.2f && !isSelect)
        {
            rightStick = true;
            resultButtonAnimator.SetBool("onRight", true);
            resultButtonAnimator.SetBool("onLeft", false);
        }
        else
        {
            leftStick = false;
            rightStick = false;
        }

        if (leftStick)
        {
            EventSystem.current.SetSelectedGameObject(retryButtonObj);
        }
        else if (rightStick)
        {
            EventSystem.current.SetSelectedGameObject(titleButtonObj);
        }



    }

    public void FixedUpdate()
    {

        if(isFadeIn &&  fadeOutImage.color.a > 0)
        {
            //�t�F�[�h�C��
            fadeOutImage.color += new Color(0, 0, 0, -fadeInA);
        }

        //�Ó]������^�C�g���V�[����
        if (isSelect && isTitle && fadeOutImage.color.a < 1)
        {
            
            fadeOutImage.color += new Color(0, 0, 0, fadeOutA);

        }
        else if (isSelect && isTitle && fadeOutImage.color.a >= 1)
        {
            ForTitleScene();
        }

        //�Ó]�����烁�C���V�[����
        if (isSelect && isRetry && fadeOutImage.color.a < 1)
        {
           
            fadeOutImage.color += new Color(0, 0, 0, fadeOutA);

        }
        else if (isSelect && isRetry && fadeOutImage.color.a >= 1)
        {
            ForMainScene();
        }

    }

    //�^�C�g���V�[���J�ڗp�̊֐�
    public void TitleOnclick()
    {

        if (!isSelect)
        {
            selectSound.Play();
            isSelect = true;
            isTitle = true;
            isFadeIn = false;
            resultButtonAnimator.SetBool("decideTitle", true);
        }
       
    }
    public void ForTitleScene()
    {
        SceneManager.LoadScene("TitleScene");
    }

    //���C���V�[���J�ڗp�̊֐�
    public void RetryOnclick()
    {

        if (!isSelect)
        {
            selectSound.Play();
            isSelect = true;
            isRetry = true;
            isFadeIn = false;
            resultButtonAnimator.SetBool("decideRetry", true);

        }
    }
   

    private void ForMainScene()
    {
        SceneManager.LoadScene("MainScene");
    }
}
