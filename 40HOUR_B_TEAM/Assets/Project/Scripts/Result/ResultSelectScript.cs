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

    [SerializeField]
    private GameObject retryButtonObj;
    [SerializeField]
    private GameObject titleButtonObj;

    [SerializeField]
    private Button retryButton;

    [SerializeField]
    private Button titleButton;

    [SerializeField]
    private Image retryImage;

    [SerializeField]
    private Image titleImage;

    public bool isSelect = false;
    bool leftStick = false;
    bool rightStick = false;    

    void Start()
    {
        retryButton.enabled = false;
        titleButton.enabled = false;
        retryImage.enabled = false;
        titleImage.enabled = false;
        music.Play();
        Invoke("ButtonActive", 4);
    }

    public void ButtonActive()
    {
        retryButton.enabled = true;
        titleButton.enabled = true;
        retryImage.enabled = true;
        titleImage.enabled = true;
    }

    private void Update()
    {
        //Debug.Log(Gamepad.current.leftStick.ReadValue().x);
        if(Gamepad.current.leftStick.ReadValue().x > 0.2f && !isSelect)
        {
            leftStick = true;
        }
        else if(Gamepad.current.leftStick.ReadValue().x < -0.2f && !isSelect)
        {
            rightStick = true;
        }
        else
        {
            leftStick = false;
            rightStick = false;
        }

        if (leftStick)
        {
            EventSystem.current.SetSelectedGameObject(retryButtonObj);
        }
        else if (rightStick)
        {
            EventSystem.current.SetSelectedGameObject(titleButtonObj);
        }
        
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
