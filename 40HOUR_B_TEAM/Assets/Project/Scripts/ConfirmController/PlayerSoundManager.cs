using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundManager : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;

    //よし
    [SerializeField] AudioClip Playercheck_Good;
    
    //ホワッツ？
    [SerializeField] AudioClip Playercheck_What;
    
    //えー？
    [SerializeField] AudioClip Playercheck_Surprise;
    
    //シャキーン
    [SerializeField] AudioClip Playercheck_Shakeen;

    [SerializeField] AudioClip Playercheck_OK;

    public void PlayerSE()
    {
        audioSource.Play();
    }

    public float SEClipLength()
    {
        // 再生中のAudioClipの長さを取得
        if (audioSource.clip != null)
        {
            return audioSource.clip.length;
        }
        return 0f;
    }

    public void GoodSoundChange()
    {
        audioSource.clip = Playercheck_Good;
    }

    public void WhatSoundChange()
    {
        audioSource.clip = Playercheck_What;
    }

    public void SurpriseSoundChange()
    {
        audioSource.clip = Playercheck_Surprise;
    }

    public void ShakeenSoundChange()
    {
        audioSource.clip = Playercheck_Shakeen;
    }

    public void OKSoundChange()
    {
        audioSource.clip = Playercheck_OK;
    }
}

