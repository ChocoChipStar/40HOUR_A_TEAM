using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;




public class TitleScene : MonoBehaviour
{
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 現在の入力情報
        var keyboardCurrent = Keyboard.current;
        var gamepadCurrent = Gamepad.current;
        var buttonB = Input.GetButtonDown("Submit");
        var buttonA = Input.GetButtonDown("Cancel");


        // 接続チェック
        if (keyboardCurrent == null)
        {
            // キーボードが接続されていないと
            // Keyboard.currentがnullになる
            return;
        }


        if(gamepadCurrent == null)
        {
            //コントローラーが接続されていないと
            //gamepadCurrentがnullになる。
            return;
        }

        
        if (keyboardCurrent.enterKey.wasPressedThisFrame || buttonB)
        {

            //enterキーかコントローラーのBボタンが押された瞬間に
            //メインシーンをロード
            SceneManager.LoadScene("MainScene");
      
        }
        if(keyboardCurrent.spaceKey.wasPressedThisFrame || buttonA)
        {
            //spaceキーかントローラーのAボタンが押された瞬間に
            //アプリケーションを閉じる
            Application.Quit();
        }

        
        
    }
}
