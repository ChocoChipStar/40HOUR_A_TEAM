using UnityEngine;

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
        if (Input.GetKey(KeyCode.Z))
        {
            PlayerThink(playerNumber, "AnimationDecition");
        }
        if (Input.GetKey(KeyCode.X))
        {
            PlayerDecition(playerNumber, "AnimationThink");
        }
        if(Input.GetKey(KeyCode.C)) 
        {
            PlayerYareYare(playerNumber, "AnimationYareYare");
        }
    }

    private void PlayerThink(int animationNumber, string animationName)
    {
        playerAnimation[animationNumber].SetBool(animationName, true);
    }
    private void PlayerDecition(int animationNumber, string animationNamer)
    {
        playerAnimation[animationNumber].SetBool(animationNamer, true);
    }
    private void PlayerYareYare(int animationNumber, string animationName)
    {
        playerAnimation[animationNumber].SetBool(animationName, true);
    }
}
