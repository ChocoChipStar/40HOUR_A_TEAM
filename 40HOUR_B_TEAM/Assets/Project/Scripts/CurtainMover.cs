using UnityEngine;
using UnityEngine.InputSystem;

public class CurtainMover : MonoBehaviour
{
    [SerializeField]
    private GameObject curtainObj = null;

    private float openMovementum = 0.0f;
    private float closeMovementum = 0.0f;

    private const float CurtainOpenFrame = 15.0f;
    private const float CurtainCloseFrame = 30.0f;

    private const float CurtainOpenPositionY = 22.0f;
    private const float CurtainClosedPositionY = 7.5f;

    public bool isOpen = false;
    public bool isClose = false;

    private void Start()
    {
        openMovementum = (CurtainOpenPositionY - CurtainClosedPositionY) / CurtainOpenFrame;
        closeMovementum = (CurtainClosedPositionY - CurtainOpenPositionY) / CurtainCloseFrame;
    }

    private void FixedUpdate()
    {
        if(isOpen)
        {
            OpenToCurtain();
        }

        if(isClose)
        {
            CloseToCurtain();
        }    
    }

    private void OpenToCurtain()
    {
        if(curtainObj.transform.position.y >= CurtainOpenPositionY)
        {
            curtainObj.transform.position = new Vector3(curtainObj.transform.position.x, CurtainOpenPositionY, curtainObj.transform.position.z);
            isOpen = false;
            return;
        }

        curtainObj.transform.position += new Vector3(0.0f, openMovementum, 0.0f);
    }

    private void CloseToCurtain()
    {
        if(transform.position.y <= CurtainClosedPositionY)
        {
            curtainObj.transform.position = new Vector3(curtainObj.transform.position.x, CurtainClosedPositionY, curtainObj.transform.position.z);
            isClose = false;
            return;
        }

        curtainObj.transform.position += new Vector3(0.0f, closeMovementum, 0.0f);
    }
}
