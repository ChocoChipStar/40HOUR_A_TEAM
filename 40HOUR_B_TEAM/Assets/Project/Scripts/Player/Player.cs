using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] int gamePadCount;
    [SerializeField] SpriteRenderer okTextSprite;
    [SerializeField] Animator animator;
    [SerializeField] PlayerSoundManager soundManager;
    private Gamepad gamepads;    


    void Start()
    {
        okTextSprite.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        gamepads = Gamepad.all[gamePadCount];

        if (gamepads.aButton.wasPressedThisFrame)
        {
            soundManager.ShakeenSoundChange();
            soundManager.PlayerSE();
            animator.Play("anime_Happy");
        }
        if (gamepads.bButton.wasPressedThisFrame)
        {
            soundManager.WhatSoundChange();
            soundManager.PlayerSE();
            animator.Play("anime_YareYare");
        }
        if(gamepads.xButton.wasPressedThisFrame)
        {
            soundManager.GoodSoundChange();
            soundManager.PlayerSE();
            animator.Play("anime_Decition");
        }
        if (gamepads.yButton.wasPressedThisFrame)
        {
            soundManager.SurpriseSoundChange();
            soundManager.PlayerSE();
            animator.Play("anime_Shock");
        }

        if (gamepads.leftShoulder.isPressed && gamepads.rightShoulder.isPressed)
        {
            soundManager.OKSoundChange();
            soundManager.PlayerSE();
            okTextSprite.enabled = true;
        }
    }
}
