using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using System.Xml.Serialization;

public class ResultSelectScript : MonoBehaviour
{
    [SerializeField]
    private AudioSource musicAudio = null;
    [SerializeField]
    private AudioSource soundEffect = null;

    void Start()
    {
        musicAudio.Play();
    }

    // Update is called once per frame
    public void TitleOnclick()
    {
        soundEffect.Play();
        Invoke("ForTitleScene",2);
    }
    public void RetryOnclick()
    {
        soundEffect.Play();
        Invoke("ForMainScene", 2);
    }
    public void ForTitleScene()
    {
        SceneManager.LoadScene("TitleScene");
    }

    private void ForMainScene()
    {
        SceneManager.LoadScene("MainScene");
    }
}
