using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    [SerializeField] Player[] player;

    private bool sceneChange;

    void Start()
    {
        sceneChange = false;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < player.Length; i++)
        {
            if (player[i].OKflg == false)
            {
                sceneChange = true;
                continue;
            }
        }

        if (sceneChange)
        {
            sceneChange = false;
        }
        else
        {
            SceneManager.LoadScene("TitleScene");
        }
    }
}
