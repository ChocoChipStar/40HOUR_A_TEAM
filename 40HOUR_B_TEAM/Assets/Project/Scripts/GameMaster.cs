using JetBrains.Annotations;
using System.Collections;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    [SerializeField]
    private RoundCounter roundCounter = null;

    [SerializeField]
    private InputButtonManager inputButtonManager = null;

    [SerializeField]
    private ScoreManager scoreManager = null;

    [SerializeField]
    private HatGenerator hatManager = null;

    [SerializeField]
    private HatCover hatCover = null;

    [SerializeField]
    private MannequinManager mannequinManager = null;

    [SerializeField]
    private PlayerMover[] playerMover = null;

    [SerializeField]
    private CurtainMover[] curtainMover = null;

    private bool isLastFrameActive = false;

    private const float DrawStartTextTime = 0.15f;

    private const float DrawRoundTextTime = 1.35f;

    private const float RoomMovementTime = 1.5f;

    private const float CloseCurtainTime = 1.4f;

    private const float OpenCurtainTime = 0.25f;

    private const float ShowcaseMovementTime = 0.75f;

    private const float CoolPoseTime = 1.0f;

    private const float ReactionTime = 1.5f;

    private const float IntervalTime = 1.0f;

    private const float ThinkingMovementTime = 0.75f;

    private void Start()
    {
        // �}�l�L������
        mannequinManager.GenerateMannequin(roundCounter.GetCurrentRound());
        // �ڂ�������
        hatManager.LineUpHat(roundCounter.GetCurrentRound());

        StartCoroutine(DrawRoundText());
    }

    private void Update()
    {
        if(inputButtonManager.isAllPlayerSelectedButton != isLastFrameActive)
        {
            StartCoroutine(MovementRoom());

            isLastFrameActive = inputButtonManager.isAllPlayerSelectedButton;
        }
    }

    private IEnumerator DrawRoundText()
    {
        // �X�^�[�g�e�L�X�g�\���i���E���h�P�̂݁j

        yield return new WaitForSeconds(DrawStartTextTime);

        // �X�^�[�g�e�L�X�g��\��
        // ���E���h�e�L�X�g�\��

        yield return new WaitForSeconds(DrawRoundTextTime);

        // ���E���h�e�L�X�g��\��

        // ���̓{�^���f�[�^������
        inputButtonManager.ResetInputButtonData();

        // �{�^��UI�\���Ɠ��͏��ON
        inputButtonManager.DrawButtonUI();
    }

    // �e�v���C���[���X�q��I�������ۂɎ��s
    // �S�v���C���[���X�q��I������A�������͎��Ԑ؂�Ń{�^��UI��\��
    private IEnumerator MovementRoom()
    {
        // ����A�j���[�V����

        // �ߑ������Ɉړ�����
        for(int i = 0; i < PlayerData.PlayerMax; i++)
        {
            playerMover[i].isThinkingToRoom = true;
        }
        
        yield return new WaitForSeconds(RoomMovementTime);

        StartCoroutine(HatShowTime());
    }

    // �S�v���C���[���ߑ������ɓ�������Ɏ��s
    private IEnumerator HatShowTime()
    {
        // �J�����Y�[���C����ɃX�^�[�g

        // �I�������ڂ������v���C���[���f���ɔz�u
        hatCover.CoveringHat();

        // �I�������ڂ������X�R�A���_�̂ڂ������m�F����
        scoreManager.ConvertButtonNumToScore();

        yield return new WaitForSeconds(CloseCurtainTime);

        // �J�[�e�����J���ҋ@����
        for (int i = 0; i < PlayerData.PlayerMax; i++)
        {
            curtainMover[i].isOpen = true;
        }

        yield return new WaitForSeconds(OpenCurtainTime);

        // ���߃|�[�Y�A�j���[�V����

        yield return new WaitForSeconds(CoolPoseTime);

        // ����A�j���[�V�����Đ�

        // ����I�ڏꏊ�Ɉړ�����
        for (int i = 0; i < PlayerData.PlayerMax; i++)
        {
            playerMover[i].isRoomToShowcase = true;
        }
        
        yield return new WaitForSeconds(ShowcaseMovementTime);

        // ��b�ҋ@
        yield return new WaitForSeconds(IntervalTime);

        // �ڂ��������Ȃ������A�j���[�V����


        // �ڂ�����������A�j���[�V����


        // �ڂ��������������A�j���[�V����


        // ���Z�X�R�A�e�L�X�g�\��
        for (int i = 0; i < PlayerData.PlayerMax; i++)
        {
            scoreManager.AddScore(i);
        }


        yield return new WaitForSeconds(ReactionTime);

        // �}�l�L�����Ĕz�u
        mannequinManager.GenerateMannequin(roundCounter.GetCurrentRound());

        // �X�q�������_���Đ���
        hatManager.LineUpHat(roundCounter.GetCurrentRound());

        // �{�^��UI�Ĕz�u
        inputButtonManager.RelocatingButton(roundCounter.GetCurrentRound());

        // ����A�j���[�V�����Đ�


        // �ڂ����I���ꏊ�Ɉړ�����
        for (int i = 0; i < PlayerData.PlayerMax; i++)
        {
            playerMover[i].isShowcaseToThinking = true;
        }
        
        // �J�������Y�[���A�E�g����
        

        yield return new WaitForSeconds(ThinkingMovementTime);

        // ���E���h�J�E���g�𑝂₷
        roundCounter.SetNextRound();
    }
}
