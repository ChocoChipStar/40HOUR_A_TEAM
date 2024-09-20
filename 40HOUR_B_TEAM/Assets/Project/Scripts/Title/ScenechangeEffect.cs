using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScenechangeEffect : MonoBehaviour
{
    [SerializeField]
    private Sprite[] fadeOutImage;

    [SerializeField]
    private Image image;

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
                image.sprite = fadeOutImage[switchCount];
                switchCount++;
            }


            counter = 0;
        }

        Debug.Log(counter);
        Debug.Log(switchCount);
    }
}
