using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundManager : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;

    //�悵
    [SerializeField] AudioClip Playercheck_Good;
    
    //�z���b�c�H
    [SerializeField] AudioClip Playercheck_What;
    
    //���[�H
    [SerializeField] AudioClip Playercheck_Surprise;
    
    //�V���L�[��
    [SerializeField] AudioClip Playercheck_Shakeen;

    [SerializeField] AudioClip Playercheck_OK;

    public void PlayerSE()
    {
        audioSource.Play();
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

