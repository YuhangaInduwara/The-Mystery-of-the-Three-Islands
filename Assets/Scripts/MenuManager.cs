using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("Level_01");
    }

    public void Options()
    {
        SceneManager.LoadScene("OptionMenu");
    }


    public void Quit()
    {
        Application.Quit();
        Debug.Log("Player has quit the game");
    }
}
