using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TutorialToMainSceneTransition : MonoBehaviour
{
    //フェードアウト用の変数
    private GameObject fadeOutImage;
    private Image fadeOut_image;
    private Color alpha;
    private bool fadeOutFlag;　

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

        if (fadeOutFlag == true && fadeOut_image.color.a < 1)
            {
            //フェードアウト
                FadeOut();
            }

            
            if (fadeOut_image.color.a >= 1)
            {
            //画面が暗くなったらメインシーンをロード

            SceneManager.LoadScene("MainScene");

            }

    }

    void FadeOut()
    {
        //イメージの透明度を少しずつ下げる
            fadeOut_image.color += alpha;
        
    }
}
