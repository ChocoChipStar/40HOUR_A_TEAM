using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSoundEffectPlayer : MonoBehaviour
{
    [SerializeField]
    private AudioSource mainSE;

    [SerializeField]
    private AudioClip success;
    [SerializeField]
    private AudioClip failure;
    [SerializeField]
    private AudioClip select;
    [SerializeField]
    private AudioClip show;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            playSuccess();
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            PlayFailure();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            PlaySelect();
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            PlayShow();
        }
    }
    public void playSuccess()
    {
        mainSE.PlayOneShot(success);
    }
    public void PlayFailure()
    {
        mainSE.PlayOneShot(failure);
    }
    public void PlaySelect()
    {
        mainSE.PlayOneShot(select);
    }
    public void PlayShow()
    {
        mainSE.PlayOneShot(show);
    }
}
