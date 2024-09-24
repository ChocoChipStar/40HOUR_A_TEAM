using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerHatAnimation : MonoBehaviour
{

    [SerializeField]
    private Animator[] playerAnimation;

    [SerializeField]
    int playerNumber;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Z,X,Cに応じてアニメーション再生
        if (Input.GetKeyDown(KeyCode.Z))
        {
            PlayerThink(playerNumber, "AnimationDecition", true);
        }
        if (Input.GetKeyUp(KeyCode.Z))
        {
            PlayerThink(playerNumber, "AnimationDecition", false);
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            PlayerDecition(playerNumber, "AnimationThink", true);
        }
        if (Input.GetKeyUp(KeyCode.X))
        {
            PlayerDecition(playerNumber, "AnimationThink", false);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            PlayerYareYare(playerNumber, "AnimationYareYare", true);
        } 
        if (Input.GetKeyUp(KeyCode.C))
        {
            PlayerYareYare(playerNumber, "AnimationYareYare", false);
        }
    }
    //アニメーションフラグ管理
    private void PlayerThink(int animationNumber, string animationName, bool isActive)
    {
        playerAnimation[animationNumber].SetBool(animationName, isActive);
    }
    private void PlayerDecition(int animationNumber, string animationNamer, bool isActive)
    {
        playerAnimation[animationNumber].SetBool(animationNamer, isActive);
    }
    private void PlayerYareYare(int animationNumber, string animationName, bool isActive)
    {
        playerAnimation[animationNumber].SetBool(animationName, isActive);
    }
}
