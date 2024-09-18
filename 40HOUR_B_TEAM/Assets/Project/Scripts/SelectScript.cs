using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class SelectScript : MonoBehaviour
{

    void Start()
    {
        
    }

    // Update is called once per frame
    public void TitleOnclick()
    {
        
        SceneManager.LoadScene("TitleScene");

    }
    public void RetryOnclick()
    {
    
        SceneManager.LoadScene("MainScene");
    }
}
