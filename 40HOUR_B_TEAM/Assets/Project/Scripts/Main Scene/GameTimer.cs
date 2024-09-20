using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class GameTimer : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI timerText;

    float timer;
    bool timerStop;

    //フラグとタイマー時間を初期化
    void Start()
    {
        timer = 10.99f;
        timerStop = false;
    }

    // Update is called once per frame
    void Update()
    {
        //0になったらコンポーネントを非表示
        if (timerStop)
        {
            timerText.enabled = false;
        }
        //変数をTMPに表示
        timerText.text = Mathf.FloorToInt(timer).ToString();

        //0になるまで減少
        if (timer >= 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            timerStop = true;
        }
    }

    //If(j)
    //{
    //    p1s = addscore(p1s, 3);
    //    Sprite.ebabled = true
    //    p2s = addscore(p2s, 3);
    //}

    //int p1s = 0;
    //int p2s = 0;

    //int addscore(int currentScore,int addvalue)
    //{
    //    return currentScore + addvalue;
    //}
}
