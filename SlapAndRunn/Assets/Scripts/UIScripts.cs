using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIScripts : MonoBehaviour
{

    public void ChangeSceneToPlay()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void ChangeSceneToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
