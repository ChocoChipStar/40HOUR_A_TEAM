using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TutorialToMainSceneTransition : MonoBehaviour
{
    //フェードアウト用の変数
    [SerializeField]
    private Image fadeOut_image;

    private float alpha;
    private bool fadeOutFlag;　

    // Start is called before the first frame update
    void Start()
    {
        
        alpha = 0.034f; //30フレームで暗転
        fadeOutFlag = false;
    }

    // Update is called once per frame
    void Update()
    {
        // 現在の入力情報
        var keyboardCurrent = Keyboard.current;
        var gamepadCurrent = Gamepad.current;
        var buttonB = Gamepad.current.bButton.wasPressedThisFrame;

        if (keyboardCurrent == null)
        {
            // キーボードが接続されていないと
            // Keyboard.currentがnullになる
            return;
        }

        if (gamepadCurrent == null)
        {
            //コントローラーが接続されていないと
            //gamepadCurrentがnullになる。
            return;
        }

        if (keyboardCurrent.enterKey.wasPressedThisFrame || buttonB)
        {

            //enterキーかコントローラーのBボタンが押された瞬間に
            //フェードアウト開始
            fadeOutFlag = true;
        }
        

        if (fadeOut_image.color.a >= 1)
        {
            //画面が暗くなったらメインシーンをロード
            SceneManager.LoadScene("MainScene");

        }

    }

    private void FixedUpdate()
    {
        if (fadeOutFlag == true && fadeOut_image.color.a < 1)
        {
            //フェードアウト
            FadeOut();
        }
    }

    void FadeOut()
    {
        //30フレームで完全に暗転する。
        fadeOut_image.color += new Color(0, 0, 0, alpha);

    }
}
