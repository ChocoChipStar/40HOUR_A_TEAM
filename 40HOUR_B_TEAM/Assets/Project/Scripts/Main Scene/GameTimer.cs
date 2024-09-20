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
}
