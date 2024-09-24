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
        //決定
        if (Input.GetKeyDown(KeyCode.Z))
        {
            PlayerAnimation(playerNumber, "AnimationDecition", true);
        }
        if (Input.GetKeyUp(KeyCode.Z))
        {
            PlayerAnimation(playerNumber, "AnimationDecition", false);
        }
        //考える
        if (Input.GetKeyDown(KeyCode.X))
        {
            PlayerAnimation(playerNumber, "AnimationThink", true);
        }
        if (Input.GetKeyUp(KeyCode.X))
        {
            PlayerAnimation(playerNumber, "AnimationThink", false);
        }
        //やれやれ
        if (Input.GetKeyDown(KeyCode.C))
        {
            PlayerAnimation(playerNumber, "AnimationYareYare", true);
        } 
        if (Input.GetKeyUp(KeyCode.C))
        {
            PlayerAnimation(playerNumber, "AnimationYareYare", false);
        }
        //クールポーズ
        if (Input.GetKeyDown(KeyCode.V))
        {
            PlayerAnimation(playerNumber, "AnimationCoolPose", true);
        }
        if (Input.GetKeyUp(KeyCode.V))
        {
            PlayerAnimation(playerNumber, "AnimationCoolPose", false);
        }
        //走る
        if (Input.GetKeyDown(KeyCode.B))
        {
            PlayerAnimation(playerNumber, "AnimationRun", true);
        }
        if (Input.GetKeyUp(KeyCode.B))
        {
            PlayerAnimation(playerNumber, "AnimationRun", false);
        }
        //ショック
        if (Input.GetKeyDown(KeyCode.N))
        {
            PlayerAnimation(playerNumber, "AnimationShock", true);
        }
        if (Input.GetKeyUp(KeyCode.N))
        {
            PlayerAnimation(playerNumber, "AnimationShock", false);
        }
        //ハッピー
        if (Input.GetKeyDown(KeyCode.M))
        {
            PlayerAnimation(playerNumber, "AnimationHappy", true);
        }
        if (Input.GetKeyUp(KeyCode.M))
        {
            PlayerAnimation(playerNumber, "AnimationHappy", false);
        }
    }
    //アニメーションフラグ管理
    private void PlayerAnimation(int animationNumber, string animationName, bool isActive)
    {
        playerAnimation[animationNumber].SetBool(animationName, isActive);
    }
}
