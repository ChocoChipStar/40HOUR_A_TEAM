using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMover : MonoBehaviour
{
    [SerializeField]
    private CurtainMover curtainMover = null;

    private float thinkingToRoomMomentum = 0.0f;
    private float roomToShowcaseMomentum = 0.0f;
    private float showcaseToThikingMovementum = 0.0f;

    private const float RoomPositionZ = 0.0f;
    private const float ShowcasePositionZ = -10.0f;
    private const float ThinkingPositionZ = -25.0f;

    private const float ThinkingPosToRoomFrame = 90.0f;
    private const float RoomToShowcaseFrame = 45.0f;
    private const float ShowcaseToThinkingFrame = 72.0f;

    public bool isRoom = false;
    public bool isShowcase = false;
    public bool isThinking = false;

    public bool isThinkingToRoom = false;
    public bool isRoomToShowcase = false;
    public bool isShowcaseToThinking = false;

    private void Start()
    {
        thinkingToRoomMomentum = (RoomPositionZ - ThinkingPositionZ) / ThinkingPosToRoomFrame;
        roomToShowcaseMomentum = (ShowcasePositionZ - RoomPositionZ) / RoomToShowcaseFrame;
        showcaseToThikingMovementum = (ThinkingPositionZ - ShowcasePositionZ) / ShowcaseToThinkingFrame;
    }

    private void Update()
    {
        if(Keyboard.current.tKey.wasPressedThisFrame)
        {
            isThinkingToRoom = true;
        }

        if(Keyboard.current.yKey.wasPressedThisFrame)
        {
            isRoomToShowcase = true;
        }

        if(Keyboard.current.uKey.wasPressedThisFrame)
        {
            isShowcaseToThinking = true;
        }
    }

    private void FixedUpdate()
    {
        if(isThinkingToRoom)
        {
           MoveToRoom();
        }

        if(isRoomToShowcase)
        {
            MoveToShowcase();
        }

        if(isShowcaseToThinking)
        {
            MoveToThinkingSpace();
        }
    }

    private void MoveToRoom()
    {
        if(transform.position.z >= RoomPositionZ)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, RoomPositionZ);
            isThinkingToRoom = false;

            curtainMover.isClose = true;

            isRoom = true;
            isThinking = false;
            return;
        }

        transform.position += new Vector3(0.0f, 0.0f, thinkingToRoomMomentum);
    }

    private void MoveToShowcase()
    {
        if (transform.position.z <= ShowcasePositionZ)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, ShowcasePositionZ);
            isRoomToShowcase = false;

            isShowcase = true;
            isRoom = false;
            return;
        }

        transform.position += new Vector3(0.0f, 0.0f, roomToShowcaseMomentum);
    }

    private void MoveToThinkingSpace()
    {
        if (transform.position.z <= ThinkingPositionZ)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, ThinkingPositionZ);
            isShowcaseToThinking = false;

            isThinking = true;
            isShowcase = false;
            return;
        }

        transform.position += new Vector3(0.0f, 0.0f, showcaseToThikingMovementum);
    }
}
