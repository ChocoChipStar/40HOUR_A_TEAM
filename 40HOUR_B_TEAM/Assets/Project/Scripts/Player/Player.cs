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
            animator.Play("anime_Happy");
        }
        if (gamepads.bButton.wasPressedThisFrame)
        {
            animator.Play("anime_YareYare");
        }
        if(gamepads.xButton.wasPressedThisFrame)
        {
            animator.Play("anime_4th");
        }
        if (gamepads.yButton.wasPressedThisFrame)
        {
            animator.Play("anime_Shock");
        }

        if (gamepads.leftShoulder.isPressed && gamepads.rightShoulder.isPressed)
        {
            okTextSprite.enabled = true;
        }
    }
}
