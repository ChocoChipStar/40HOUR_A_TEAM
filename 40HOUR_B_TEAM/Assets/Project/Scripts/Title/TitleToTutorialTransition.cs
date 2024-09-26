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
        // 現在の入力情報
        var keyboardCurrent = Keyboard.current;
        var gamepadCurrent = Gamepad.current;
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

      

        if (keyboardCurrent.enterKey.wasPressedThisFrame && !startFlag || buttonA && !startFlag)
        {

            //enterキーかコントローラーのBボタンが押された瞬間に
            //エフェクトを再生
            titleSE.Play();
            titleButtonAnim.SetBool("Start", true);
            changeEffect = true; 
            startFlag = true;
            

        }
        
        
        //エフェクト再生後メインシーンをロード
        if (scenechangeEffect.switchCount == 59)
        {
            SceneManager.LoadScene("ConfirmControllerScene");
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
