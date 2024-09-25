using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HatCover : MonoBehaviour
{
    [SerializeField]
    private InputButtonManager inputButtonManager = null;

    [SerializeField]
    private HatGenerator hatGenerator = null;

    [SerializeField]
    private GameObject[] playerObj = new GameObject[4];

    [SerializeField]
    private GameObject[] hatPos = new GameObject[4];

    public void CoveringHat()
    {
        for (int i = 0; i < PlayerData.PlayerMax; i++)
        {
            // �������ꂽ�ڂ����̒�����v���C���[�����I�������ڂ������Đ�������
            var instance = Instantiate(hatGenerator.locatedHat[inputButtonManager.InputButtonNum[i]]);

            instance.transform.SetParent(playerObj[i].transform);

            instance.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
            instance.transform.localRotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);

            instance.transform.SetParent(hatPos[i].transform);

            instance.transform.localPosition = new Vector3(0.0f, -6.0f, 0.0f);
            instance.transform.localRotation = Quaternion.identity;
        }
    }
}
