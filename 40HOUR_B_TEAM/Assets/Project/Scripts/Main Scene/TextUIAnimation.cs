using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class TextUIAnimation : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer textUI;
    [SerializeField]
    private Sprite roundSprite;

    [SerializeField]
    private Animator animator;
    [SerializeField]
    int round;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Update()
    {
        //デバッグ用
        if (Input.GetKeyDown(KeyCode.Z))
        {
           GameStartText();
            textUI.enabled = true;
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            RoundFinishText();
            textUI.enabled = true;
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
           RoundStartText();
            textUI.enabled = true;
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        textUI.sprite = roundSprite;
    }

    public void GameStartText()
    {
        animator.SetBool("GameStart", true);
        Invoke("Reset", 0.1f);
    }
    public void RoundStartText()
    {
        animator.SetBool("RoundStart", true);
        Invoke("Reset", 0.1f);
    }
    public void RoundFinishText()
    {
        animator.SetBool("RoundFinish", true);
        Invoke("Reset", 0.1f);
    }

    public void Reset()
    {
        animator.SetBool("GameStart", false);
        animator.SetBool("RoundStart", false);
        animator.SetBool("RoundFinish", false);
    }
}
