using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerHatAnimation : MonoBehaviour
{

    [SerializeField]
    private Animator[] playerAnimation;
    //[SerializeField]
    //private Animator playerAnimation2;
    //[SerializeField]
    //private Animator playerAnimation3;
    //[SerializeField]
    //private Animator playerAnimation4;

    [SerializeField]
    int playerNomber;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Z,X,Cに応じてアニメーション再生
        if (Input.GetKey(KeyCode.Z))
        {
            PlayerThink(playerNomber, "AnimationDecition");
        }
        if (Input.GetKey(KeyCode.X))
        {
            PlayerDecition(playerNomber, "AnimationThink");
        }
        if(Input.GetKey(KeyCode.C)) 
        {
            PlayerYareYare(playerNomber, "AnimationYareYare");
        }
    }

    private void PlayerThink(int animationNomber, string animationName)
    {
        playerAnimation[animationNomber].SetBool(animationName, true);
    }
    private void PlayerDecition(int animationNomber, string animationNamer)
    {
        playerAnimation[animationNomber].SetBool(animationNamer, true);
    }
    private void PlayerYareYare(int animationNomber, string animationName)
    {
        playerAnimation[animationNomber].SetBool(animationName, true);
    }
}
