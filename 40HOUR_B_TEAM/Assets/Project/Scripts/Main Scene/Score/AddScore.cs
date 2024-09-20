using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AddScore : MonoBehaviour
{
    //イメージ取得
    [SerializeField]
    private Image player1Add1Score;
    [SerializeField]
    private Image player1Add2Score;
    [SerializeField]
    private Image player1Add3Score;
    [SerializeField]
    private Image player2Add1Score;
    [SerializeField]
    private Image player2Add2Score;
    [SerializeField]
    private Image player2Add3Score;
    [SerializeField]
    private Image player3Add1Score;
    [SerializeField]
    private Image player3Add2Score;
    [SerializeField]
    private Image player3Add3Score;
    [SerializeField]
    private Image player4Add1Score;
    [SerializeField]
    private Image player4Add2Score;
    [SerializeField]
    private Image player4Add3Score;

    bool add1;
    bool add2;
    bool add3;
    void Start()
    {
        //すべてのスコア加算画像を非表示
        player1Add1Score.enabled = false;
        player1Add2Score.enabled = false;
        player1Add3Score.enabled = false;
        player2Add1Score.enabled = false;
        player2Add2Score.enabled = false;
        player2Add3Score.enabled = false;
        player3Add1Score.enabled = false;
        player3Add2Score.enabled = false;
        player3Add3Score.enabled = false;
        player4Add1Score.enabled = false;
        player4Add2Score.enabled = false;
        player4Add3Score.enabled = false;

        add1 =false; add2 =false; add3 =false;
    }

    public void Update()
    {
        if (add1)
        {
            //表示
            player1Add1Score.enabled = true;
            player2Add1Score.enabled = true;
            player3Add1Score.enabled = true;
            player4Add1Score.enabled = true;
        }
        else
        {
            //非表示
            player1Add1Score.enabled = false;
            player2Add1Score.enabled = false;
            player3Add1Score.enabled = false;
            player4Add1Score.enabled = false;
        }
        if (add2)
        {
            //表示
            player1Add2Score.enabled = true;
            player2Add2Score.enabled = true;
            player3Add2Score.enabled = true;
            player4Add2Score.enabled = true;
        }
        else
        {
            //非表示
            player1Add2Score.enabled = false;
            player2Add2Score.enabled = false;
            player3Add2Score.enabled = false;
            player4Add2Score.enabled = false;
        }
        if (add3)
        { 
            //表示
            player1Add3Score.enabled = true;
            player2Add3Score.enabled = true;
            player3Add3Score.enabled = true;
            player4Add3Score.enabled = true;
        }
        else
        {
            //非表示
            player1Add3Score.enabled = false;
            player2Add3Score.enabled = false;
            player3Add3Score.enabled = false;
            player4Add3Score.enabled = false;
        }
    }

    public void ScoreAdd1()
    {
        add1 = true;
        add2 = false;
        add3 = false;
    }

    public void ScoreAdd2()
    {
        add1 = false;
        add2 = true;
        add3 = false;
    }

    public void ScoreAdd3()
    {
        add1 = false;
        add2 = false;
        add3 = true;
    }
}
