using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using System.Xml.Serialization;

public class ResultSelectScript : MonoBehaviour
{
    [SerializeField]
    private AudioSource music = null;
    [SerializeField]
    private AudioSource soundEffect = null;

    bool isSelect = false;

    void Awake()
    {
        
        music.Play();
        Invoke("ButtonActive", 4);
    }

    public void ButtonActive()
    {
        var button = GetComponent<Button>();
        button.enabled = true;
        var image = GetComponent<Image>();
        image.enabled = true;
    }

    // Update is called once per frame
    public void TitleOnclick()
    {

        if (!isSelect)
        {
            soundEffect.Play();
            isSelect = true;
            Invoke("ForTitleScene", 2);
            
        }
       
    }
    public void RetryOnclick()
    {

        if (!isSelect)
        {
            soundEffect.Play();
            isSelect = true;
            Invoke("ForMainScene", 2);
           
        }
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
