using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
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

    //ボタン非表示
    void Start()
    {
        retryButton.enabled = false;
        titleButton.enabled = false;
        retryImage.enabled = false;
        titleImage.enabled = false;
        isFadeIn = true;
        fanfareSound.Play();
        Invoke("ButtonActive", 4);
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
                       
        }
    }
   

    private void ForMainScene()
    {
        SceneManager.LoadScene("MainScene");
    }
}
