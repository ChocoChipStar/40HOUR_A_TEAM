using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    Gamepad gamepads;
     
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        gamepads = Gamepad.all[0];

        
    }
}
