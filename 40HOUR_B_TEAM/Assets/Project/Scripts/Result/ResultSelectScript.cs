using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Xml.Serialization;

public class ResultSelectScript : MonoBehaviour
{
    //サウンド
    [SerializeField]
    private AudioSource music = null;
    [SerializeField]
    private AudioSource selectSound = null;
    [SerializeField]
    private AudioSource fanfareSound = null;

    //ボタンオブジェクト
    [SerializeField]
    private GameObject retryButtonObj;
    [SerializeField]
    private GameObject titleButtonObj;

    //ボタン、イメージコンポーネント
    [SerializeField]
    private Button retryButton;

    [SerializeField]
    private Button titleButton;

    [SerializeField]
    private Image retryImage;

    [SerializeField]
    private Image titleImage;

    //フェード用イメージコンポーネント
    [SerializeField]
    private Image fadeOutImage;

    Animator resultButtonAnimator = null;

    //セレクトフラグ
    public bool isSelect = false;

    //フェードイン用フラグ
    private bool isFadeIn = false;

    //フェードアウト用フラグ
    private bool isTitle = false;
    private bool isRetry = false;

    //スティック入力フラグ
    private bool leftStick = false;
    private bool rightStick = false;

    //フェード用　画像の透明度の変化値
    private float fadeInA = 0.05f;    //20フレームでフェードイン
    private float fadeOutA = 0.0167f;  //60フレームで暗転

    //ファンファーレを鳴らすまでの待ち時間
    private const float StayTime = 0.5f;

    //ボタン非表示
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

    //ボタンを表示
    public void ButtonActive()
    {
        retryButton.enabled = true;
        titleButton.enabled = true;
        retryImage.enabled = true;
        titleImage.enabled = true;
        music.Play();
    }

    //ゲームパッド入力受付
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
            //フェードイン
            fadeOutImage.color += new Color(0, 0, 0, -fadeInA);
        }

        //暗転したらタイトルシーンへ
        if (isSelect && isTitle && fadeOutImage.color.a < 1)
        {
            
            fadeOutImage.color += new Color(0, 0, 0, fadeOutA);

        }
        else if (isSelect && isTitle && fadeOutImage.color.a >= 1)
        {
            ForTitleScene();
        }

        //暗転したらメインシーンへ
        if (isSelect && isRetry && fadeOutImage.color.a < 1)
        {
           
            fadeOutImage.color += new Color(0, 0, 0, fadeOutA);

        }
        else if (isSelect && isRetry && fadeOutImage.color.a >= 1)
        {
            ForMainScene();
        }

    }

    //タイトルシーン遷移用の関数
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

    //メインシーン遷移用の関数
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
