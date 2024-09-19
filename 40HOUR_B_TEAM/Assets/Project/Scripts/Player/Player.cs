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
    [SerializeField] PlayerScriptable playerScriptable;
    [SerializeField] Animator animator;
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
            Debug.Log("A");
            animator.Play("anime_Happy");
        }
        if (gamepads.bButton.wasPressedThisFrame)
        {
            Debug.Log("B");
            animator.Play("anime_YareYare");
        }
        if(gamepads.xButton.wasPressedThisFrame)
        {
            Debug.Log("X");
            animator.Play("anime_4th");
        }
        if (gamepads.yButton.wasPressedThisFrame)
        {
            Debug.Log("Y");
            animator.Play("anime_Shock");
        }
        if (gamepads.leftShoulder.isPressed && gamepads.rightShoulder.isPressed)
        {
            Debug.Log("OK");
            okTextSprite.enabled = true;
        }
    }
}
