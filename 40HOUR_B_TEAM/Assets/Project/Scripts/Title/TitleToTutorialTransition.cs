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

    bool changeEffect;

    // Start is called before the first frame update
    void Start()
    {
        changeEffect = false;
    }

    // Update is called once per frame
    void Update()
    {
        // 現在の入力情報
        var keyboardCurrent = Keyboard.current;
        var gamepadCurrent = Gamepad.current;
        var buttonB = Gamepad.current.bButton.wasPressedThisFrame;
        var buttonA = Gamepad.current.aButton.wasPressedThisFrame;


        // 接続チェック
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

        Debug.Log(keyboardCurrent.enterKey.wasPressedThisFrame);
        Debug.Log(buttonB);

        if (keyboardCurrent.enterKey.wasPressedThisFrame || buttonB)
        {

            //enterキーかコントローラーのBボタンが押された瞬間に
            //エフェクトを再生
            titleSE.Play();
            changeEffect = true;
            Debug.Log(changeEffect);

        }
        if (keyboardCurrent.spaceKey.wasPressedThisFrame || buttonA)
        {
            //spaceキーかントローラーのAボタンが押された瞬間に
            //アプリケーションを閉じる
            titleSE.Play();
            Application.Quit();
        }
        
        //エフェクト再生後メインシーンをロード
        if (scenechangeEffect.switchCount == 59)
        {
            SceneManager.LoadScene("MainScene");
        }


    }
    private void FixedUpdate()
    {
        if (changeEffect)
        {
            //シーンチェンジエフェクトを再生
            scenechangeEffect.ChangeEffect();
        }
    }
}
