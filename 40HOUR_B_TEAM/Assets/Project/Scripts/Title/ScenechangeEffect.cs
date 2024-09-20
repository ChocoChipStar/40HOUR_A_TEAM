using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScenechangeEffect : MonoBehaviour
{
    //�t�F�[�h�A�E�g�̃C���[�W�p�̃R���|�[�l���g
    [SerializeField]
    private Sprite[] fadeOutImage;
    [SerializeField]
    private Image image;

    //BGM�����p�̃R���|�[�l���g
    [SerializeField]
    private AudioSource bgmAudioSource;

    //�t�F�[�h�A�E�g���x�����p�̕ϐ�
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
        //2�t���[����1����s����B
        counter++;
        if (counter == 2)
        {

            if (switchCount <= 58 && counter == 2)
            {
                //�摜��\��
                image.sprite = fadeOutImage[switchCount];
                switchCount++;

                //BGM�̃{�����[����������
                bgmAudioSource.volume -= 0.02f;
            }


            counter = 0;

            
        }
      
    }

}
