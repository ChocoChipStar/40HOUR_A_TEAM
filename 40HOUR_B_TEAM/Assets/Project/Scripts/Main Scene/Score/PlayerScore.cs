using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    //TMPの取得
    [SerializeField]
    private TextMeshProUGUI textScorePlayer1;
    [SerializeField]
    private TextMeshProUGUI textScorePlayer2;
    [SerializeField]
    private TextMeshProUGUI textScorePlayer3;
    [SerializeField]
    private TextMeshProUGUI textScorePlayer4;
    //スコア加算スクリプト
    [SerializeField]
    private AddScore addScore;

    int scorePlayer1;
    int scorePlayer2;
    int scorePlayer3;
    int scorePlayer4;

    void Start()
    {
        //プレイヤースコア初期化
        scorePlayer1 = 0;
        scorePlayer2 = 0;
        scorePlayer3 = 0;
        scorePlayer4 = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Lキーを押すとスコア加算、加算画像表示
        if(Input.GetKeyUp(KeyCode.L)) 
        {
            //スコア計算
            scorePlayer1 = Addscore(scorePlayer1, 1);
            scorePlayer2 = Addscore(scorePlayer2, 1);
            scorePlayer3 = Addscore(scorePlayer3, 1);
            scorePlayer4 = Addscore(scorePlayer4, 1);
            //スコア画像
            addScore.ScoreAdd1();
        }
        //Kキーを押すとスコア加算、加算画像表示
        if (Input.GetKeyUp(KeyCode.K))
        {
            //スコア計算
            scorePlayer1 = Addscore(scorePlayer1, 2);
            scorePlayer2 = Addscore(scorePlayer2, 2);
            scorePlayer3 = Addscore(scorePlayer3, 2);
            scorePlayer4 = Addscore(scorePlayer4, 2);
            //スコア画像
            addScore.ScoreAdd2();
        }
        //Jキーを押すとスコア加算、加算画像表示
        if (Input.GetKeyUp(KeyCode.J))
        {
            //スコア計算
            scorePlayer1 = Addscore(scorePlayer1, 3);
            scorePlayer2 = Addscore(scorePlayer2, 3);
            scorePlayer3 = Addscore(scorePlayer3, 3);
            scorePlayer4 = Addscore(scorePlayer4, 3);
            //スコア画像
            addScore.ScoreAdd3();
        }

        //スコア数値表示
        textScorePlayer1.text = (scorePlayer1).ToString();
        textScorePlayer2.text = (scorePlayer2).ToString();
        textScorePlayer3.text = (scorePlayer3).ToString();
        textScorePlayer4.text = (scorePlayer4).ToString();
    }
    //スコア加算
    int Addscore(int currentScore, int addvalue)
    {
        return currentScore + addvalue;
    }
}
