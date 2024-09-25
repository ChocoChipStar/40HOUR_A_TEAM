using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SoundPlayScript : MonoBehaviour
{
    //ÉTÉEÉìÉh
    [SerializeField]
    private AudioSource tutorialMuzic;
    [SerializeField]
    private AudioSource tutorialSoundEffect;

    bool isSelect = false;

    // Start is called before the first frame update
    void Start()
    {
        //BGMÇçƒê∂
        tutorialMuzic.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (Gamepad.current.aButton.wasPressedThisFrame && !isSelect)
        {
            tutorialSoundEffect.Play();
            isSelect = true;
        }
    }
}
