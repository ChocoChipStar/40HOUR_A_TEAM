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
        var current = Keyboard.current;
        var buttonB = Input.GetButtonDown("Submit");


        // 接続チェック
        if (current == null)
        {
            // キーボードが接続されていないと
            // Keyboard.currentがnullになる
            return;
        }


        if(buttonB == false)
        {
            //コントローラーが接続されていないと
            //buttonBがnullになる。
            return;
        }



        //SpaceキーかコントローラーのBボタンが押された瞬間に
        if (current.spaceKey.wasPressedThisFrame || buttonB)
        {
            SceneManager.LoadScene("MainScene");
        }

        
        
    }
}
