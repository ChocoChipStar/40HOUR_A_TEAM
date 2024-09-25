using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] int gamePadCount;
    [SerializeField] SpriteRenderer okTextSprite;
    [SerializeField] Animator animator;
    [SerializeField] Animator okButtonAnimator;
    [SerializeField] PlayerSoundManager soundManager;
    private Gamepad gamepads;

    // ボタンの状態を管理するフラグ
    private bool isAButtonPlaying = false;
    private bool isBButtonPlaying = false;
    private bool isXButtonPlaying = false;
    private bool isYButtonPlaying = false;
    private bool isOkSoundPlaying = false;


    void Update()
    {
        gamepads = Gamepad.all[gamePadCount];

        if (gamepads.aButton.wasPressedThisFrame && !isAButtonPlaying)
        {
            soundManager.ShakeenSoundChange();
            soundManager.PlayerSE();
            animator.Play("anime_Happy");
            isAButtonPlaying = true;
            StartCoroutine(ResetButtonFlag("A", soundManager.SEClipLength()));
        }
        if (gamepads.bButton.wasPressedThisFrame && !isBButtonPlaying)
        {
            soundManager.WhatSoundChange();
            soundManager.PlayerSE();
            animator.Play("anime_YareYare");
            isBButtonPlaying = true;
            StartCoroutine(ResetButtonFlag("B", soundManager.SEClipLength()));
        }
        if (gamepads.xButton.wasPressedThisFrame && !isXButtonPlaying)
        {
            soundManager.GoodSoundChange();
            soundManager.PlayerSE();
            animator.Play("anime_Decition");
            isXButtonPlaying = true;
            StartCoroutine(ResetButtonFlag("X", soundManager.SEClipLength()));
        }
        if (gamepads.yButton.wasPressedThisFrame && !isYButtonPlaying)
        {
            soundManager.SurpriseSoundChange();
            soundManager.PlayerSE();
            animator.Play("anime_Shock");
            isYButtonPlaying = true;
            StartCoroutine(ResetButtonFlag("Y", soundManager.SEClipLength()));
        }

        if (gamepads.leftShoulder.isPressed && gamepads.rightShoulder.isPressed && !isOkSoundPlaying)
        {
            soundManager.OKSoundChange();
            soundManager.PlayerSE();
            okButtonAnimator.Play("PlayerSelectButtonAnimation");
            okTextSprite.enabled = true;
            isOkSoundPlaying = true;
            StartCoroutine(ResetButtonFlag("OK", soundManager.SEClipLength()));
        }
    }

    // ボタン状態をリセットするためのコルーチン
    private IEnumerator ResetButtonFlag(string buttonType, float duration)
    {
        yield return new WaitForSeconds(duration);

        switch (buttonType)
        {
            case "A":
                isAButtonPlaying = false;
                break;
            case "B":
                isBButtonPlaying = false;
                break;
            case "X":
                isXButtonPlaying = false;
                break;
            case "Y":
                isYButtonPlaying = false;
                break;
        }
    }
}
