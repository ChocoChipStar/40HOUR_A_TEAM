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
        }
        if (gamepads.bButton.wasPressedThisFrame)
        {
            Debug.Log("B");
            //animator.
        }
        if(gamepads.xButton.wasPressedThisFrame)
        {
            Debug.Log("X");
        }
        if (gamepads.yButton.wasPressedThisFrame)
        {
            Debug.Log("Y");
        }
        if (gamepads.leftShoulder.isPressed && gamepads.rightShoulder.isPressed)
        {
            Debug.Log("OK");
            okTextSprite.enabled = true;
        }
    }
}
