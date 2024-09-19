using System.Collections;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    private const float DrawStartTextTime = 0.15f;

    private const float DrawRoundTextTime = 1.35f;

    private const float RoomMovementTime = 1.5f;

    private const float CloseCurtainTime = 1.4f;

    private const float OpenCurtainTime = 0.1f;

    private const float SignaturePoseTime = 1.0f;

    private const float ReactionTime = 1.5f;

    private const float ForwardMovementTime = 0.75f;

    private void Start()
    {
        StartCoroutine(DrawRoundText());
    }

    private IEnumerator DrawRoundText()
    {
        // �X�^�[�g�e�L�X�g�\���i���E���h�P�̂݁j

        yield return new WaitForSeconds(DrawStartTextTime);

        // �X�^�[�g�e�L�X�g��\��
        // ���E���h�e�L�X�g�\��

        yield return new WaitForSeconds(DrawRoundTextTime);

        // ���E���h�e�L�X�g��\��
        // �{�^��UI�\��
    }

    // �e�v���C���[���X�q��I�������ۂɎ��s
    // �S�v���C���[���X�q��I������A�������͎��Ԑ؂�Ń{�^��UI��\��
    private IEnumerator MovementRoom()
    {
        // �ߑ������Ɉړ�����A�j���[�V����

        yield return new WaitForSeconds(RoomMovementTime);

        // �J�[�e���������A�j���[�V����
    }

    // �S�v���C���[���ߑ������ɓ�������Ɏ��s
    private IEnumerator HatShowTime()
    {
        // �J�����Y�[��������ɃX�^�[�g

        yield return new WaitForSeconds(CloseCurtainTime);

        // �J�[�e�����J���A�j���[�V����

        yield return new WaitForSeconds(OpenCurtainTime);

        // ���߃|�[�Y�A�j���[�V����

        yield return new WaitForSeconds(SignaturePoseTime);

        // ���A�N�V�����A�j���[�V����
        // ���Z�X�R�A�e�L�X�g�\��

        yield return new WaitForSeconds(ReactionTime);

        // �X�q�������_���Đ���
        // �v���C���[���O�Ɉړ����Ă���A�j���[�V����
        // �J�������Y�[���A�E�g����

        yield return new WaitForSeconds(ForwardMovementTime);

        // ���E���h�J�E���g�𑝂₷
    }
}
