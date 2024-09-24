using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class PlayerHatAnimation : MonoBehaviour
{

    [SerializeField]
    private new Animator animation;

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
            PlayerThink(animation);
            
        }
        if (Input.GetKey(KeyCode.X))
        {
            PlayerDecition(animation);
        }
        if(Input.GetKey(KeyCode.C)) 
        {
            PlayerYareYare(animation);
        }
    }

    private void PlayerThink(Animator animator)
    {
        animator.SetBool("AnimationDecition", true);
    }
    private void PlayerDecition(Animator animator)
    {
        animator.SetBool("AnimationThink", true);
    }
    private void PlayerYareYare(Animator animator)
    {
        animator.SetBool("AnimationYareYare", true);
    }
}
