using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    [SerializeField] Player[] player;

    private bool sceneChange;

    private bool[] letStart = new bool[4];
    private Gamepad gamepads;

    void Start()
    {
        for (int i = 0; i < player.Length; i++)
        {
            letStart[i] = false;
        }
        sceneChange = false;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < player.Length; i++)
        {
            gamepads = Gamepad.all[i];

            if (gamepads.leftShoulder.isPressed && gamepads.rightShoulder.isPressed)
            {
                letStart[i] = true;
            }

            if (letStart[i] == false)
            {
                sceneChange = true;
                continue;
            }
        }

        if (sceneChange)
        {
            sceneChange = false;
        }
        else
        {
            SceneManager.LoadScene("TitleScene");
        }
    }
}
