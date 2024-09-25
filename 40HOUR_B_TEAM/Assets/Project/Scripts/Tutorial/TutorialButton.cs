using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class TutorialButton : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private Button startButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Gamepad.current.aButton.isPressed)
        {
            animator.SetTrigger("Button");
        }
    }
}
