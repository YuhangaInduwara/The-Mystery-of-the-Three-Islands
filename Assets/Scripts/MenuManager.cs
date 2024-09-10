using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuManager : MonoBehaviour
{
    public static bool isMuted = false;
    public TMP_Text buttonText;

    public void Play()
    {
        SceneManager.LoadScene("Level_01");
    }

    public void Mute()
    {
        isMuted = !isMuted; // Toggle mute state
        if (isMuted)
        {
            Debug.Log("Audio is muted");
            buttonText.text = "Unmute"; // Change button text to "Unmute"
        }
        else
        {
            Debug.Log("Audio is unmuted");
            buttonText.text = "Mute"; // Change button text to "Mute"
        }
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Player has quit the game");
    }
}
