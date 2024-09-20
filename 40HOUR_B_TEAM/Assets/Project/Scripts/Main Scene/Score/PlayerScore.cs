using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    //TMP�̎擾
    [SerializeField]
    private TextMeshProUGUI textScorePlayer1;
    [SerializeField]
    private TextMeshProUGUI textScorePlayer2;
    [SerializeField]
    private TextMeshProUGUI textScorePlayer3;
    [SerializeField]
    private TextMeshProUGUI textScorePlayer4;
    //�X�R�A���Z�X�N���v�g
    [SerializeField]
    private AddScore addScore;

    int scorePlayer1;
    int scorePlayer2;
    int scorePlayer3;
    int scorePlayer4;

    void Start()
    {
        //�v���C���[�X�R�A������
        scorePlayer1 = 0;
        scorePlayer2 = 0;
        scorePlayer3 = 0;
        scorePlayer4 = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //L�L�[�������ƃX�R�A���Z�A���Z�摜�\��
        if(Input.GetKeyUp(KeyCode.L)) 
        {
            //�X�R�A�v�Z
            scorePlayer1 = Addscore(scorePlayer1, 1);
            scorePlayer2 = Addscore(scorePlayer2, 1);
            scorePlayer3 = Addscore(scorePlayer3, 1);
            scorePlayer4 = Addscore(scorePlayer4, 1);
            //�X�R�A�摜
            addScore.ScoreAdd1();
        }
        //K�L�[�������ƃX�R�A���Z�A���Z�摜�\��
        if (Input.GetKeyUp(KeyCode.K))
        {
            //�X�R�A�v�Z
            scorePlayer1 = Addscore(scorePlayer1, 2);
            scorePlayer2 = Addscore(scorePlayer2, 2);
            scorePlayer3 = Addscore(scorePlayer3, 2);
            scorePlayer4 = Addscore(scorePlayer4, 2);
            //�X�R�A�摜
            addScore.ScoreAdd2();
        }
        //J�L�[�������ƃX�R�A���Z�A���Z�摜�\��
        if (Input.GetKeyUp(KeyCode.J))
        {
            //�X�R�A�v�Z
            scorePlayer1 = Addscore(scorePlayer1, 3);
            scorePlayer2 = Addscore(scorePlayer2, 3);
            scorePlayer3 = Addscore(scorePlayer3, 3);
            scorePlayer4 = Addscore(scorePlayer4, 3);
            //�X�R�A�摜
            addScore.ScoreAdd3();
        }

        //�X�R�A���l�\��
        textScorePlayer1.text = (scorePlayer1).ToString();
        textScorePlayer2.text = (scorePlayer2).ToString();
        textScorePlayer3.text = (scorePlayer3).ToString();
        textScorePlayer4.text = (scorePlayer4).ToString();
    }
    //�X�R�A���Z
    int Addscore(int currentScore, int addvalue)
    {
        return currentScore + addvalue;
    }
}
