using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScenechangeEffect : MonoBehaviour
{
    //フェードアウトのイメージ用のコンポーネント
    [SerializeField]
    private Sprite[] fadeOutImage;
    [SerializeField]
    private Image image;

    //BGM調整用のコンポーネント
    [SerializeField]
    private AudioSource bgmAudioSource;

    //フェードアウト速度調整用の変数
    int counter;
    public int switchCount;


    // Start is called before the first frame update
    void Start()
    {
        counter = 0;
        switchCount = 0;
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeEffect()
    {
        //2フレームに1回実行する。
        counter++;
        if (counter == 2)
        {

            if (switchCount <= 58 && counter == 2)
            {
                //画像を表示
                image.sprite = fadeOutImage[switchCount];
                switchCount++;

                //BGMのボリュームを下げる
                bgmAudioSource.volume -= 0.02f;
            }


            counter = 0;

            
        }
      
    }

}
