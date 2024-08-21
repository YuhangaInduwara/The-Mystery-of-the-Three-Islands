using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionManager : MonoBehaviour
{
    public void Reset()
    {
        SceneManager.LoadScene("Level_01");
    }

    public void Sound()
    {
        SceneManager.LoadScene("OptionMenu");
    }


    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
