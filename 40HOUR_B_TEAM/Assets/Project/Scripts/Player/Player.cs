using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] int gamePadCount;
    [SerializeField] Object playerModel;

    private Gamepad gamepads;

    [SerializeField]
    private PlayerScriptable playerScriptable;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        gamepads = Gamepad.all[gamePadCount];

        if (gamepads.aButton.wasPressedThisFrame)
        {
            Debug.Log("A");
            //playerScriptable.AnimDataList[0].taikiAnimation;
        }
        if (gamepads.bButton.wasPressedThisFrame)
        {
            Debug.Log("B");
        }
        if(gamepads.xButton.wasPressedThisFrame)
        {
            Debug.Log("X");
        }
        if (gamepads.yButton.wasPressedThisFrame)
        {
            Debug.Log("Y");
        }
        if (gamepads.leftShoulder.wasPressedThisFrame)
        {
            Debug.Log("LB");
        }
    }
}
