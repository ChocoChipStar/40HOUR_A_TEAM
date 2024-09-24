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
        //Z,X,C�ɉ����ăA�j���[�V�����Đ�
        //����
        if (Input.GetKeyDown(KeyCode.Z))
        {
            PlayerAnimation(playerNumber, "AnimationDecition", true);
        }
        if (Input.GetKeyUp(KeyCode.Z))
        {
            PlayerAnimation(playerNumber, "AnimationDecition", false);
        }
        //�l����
        if (Input.GetKeyDown(KeyCode.X))
        {
            PlayerAnimation(playerNumber, "AnimationThink", true);
        }
        if (Input.GetKeyUp(KeyCode.X))
        {
            PlayerAnimation(playerNumber, "AnimationThink", false);
        }
        //�����
        if (Input.GetKeyDown(KeyCode.C))
        {
            PlayerAnimation(playerNumber, "AnimationYareYare", true);
        } 
        if (Input.GetKeyUp(KeyCode.C))
        {
            PlayerAnimation(playerNumber, "AnimationYareYare", false);
        }
        //�N�[���|�[�Y
        if (Input.GetKeyDown(KeyCode.V))
        {
            PlayerAnimation(playerNumber, "AnimationCoolPose", true);
        }
        if (Input.GetKeyUp(KeyCode.V))
        {
            PlayerAnimation(playerNumber, "AnimationCoolPose", false);
        }
        //����
        if (Input.GetKeyDown(KeyCode.B))
        {
            PlayerAnimation(playerNumber, "AnimationRun", true);
        }
        if (Input.GetKeyUp(KeyCode.B))
        {
            PlayerAnimation(playerNumber, "AnimationRun", false);
        }
        //�V���b�N
        if (Input.GetKeyDown(KeyCode.N))
        {
            PlayerAnimation(playerNumber, "AnimationShock", true);
        }
        if (Input.GetKeyUp(KeyCode.N))
        {
            PlayerAnimation(playerNumber, "AnimationShock", false);
        }
        //�n�b�s�[
        if (Input.GetKeyDown(KeyCode.M))
        {
            PlayerAnimation(playerNumber, "AnimationHappy", true);
        }
        if (Input.GetKeyUp(KeyCode.M))
        {
            PlayerAnimation(playerNumber, "AnimationHappy", false);
        }
    }
    //�A�j���[�V�����t���O�Ǘ�
    private void PlayerAnimation(int animationNumber, string animationName, bool isActive)
    {
        playerAnimation[animationNumber].SetBool(animationName, isActive);
    }
}
