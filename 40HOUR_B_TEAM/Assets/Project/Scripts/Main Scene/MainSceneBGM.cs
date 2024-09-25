using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSceneBGM : MonoBehaviour
{
    [SerializeField]
    private AudioSource mainBGM;
    // Start is called before the first frame update
    void Start()
    {
        mainBGM.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
