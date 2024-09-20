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

    //�t���O�ƃ^�C�}�[���Ԃ�������
    void Start()
    {
        timer = 10.99f;
        timerStop = false;
    }

    // Update is called once per frame
    void Update()
    {
        //0�ɂȂ�����R���|�[�l���g���\��
        if (timerStop)
        {
            timerText.enabled = false;
        }
        //�ϐ���TMP�ɕ\��
        timerText.text = Mathf.FloorToInt(timer).ToString();

        //0�ɂȂ�܂Ō���
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
