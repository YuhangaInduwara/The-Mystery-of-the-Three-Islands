using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PauseMenuManager : MonoBehaviour
{
    public GameObject pauseMenuUI; // Reference to the pause menu GameObject
    public GameObject compass; // Reference to the pause menu GameObject
    public GameObject healthBar; // Reference to the pause menu GameObject
    private bool isPaused = false; // To check if the game is currently paused
    public TMP_Text buttonText;
    public AudioManager audioManager; // Public reference to the AudioManager script

    private void Start()
    {
        if (audioManager == null)
        {
            Debug.LogError("AudioManager not assigned in the Inspector.");
        }

        if (MenuManager.isMuted)
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

    void Update()
    {
        // Check if the ESC key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume(); // If the game is paused, resume the game
            }
            else
            {
                Pause(); // If the game is not paused, pause the game
            }
        }
    }

    // Method to resume the game
    void Resume()
    {
        pauseMenuUI.SetActive(false);
        healthBar.SetActive(true); // Show the pause menu
        compass.SetActive(true); // Hide the pause menu
        Time.timeScale = 1f; // Resume game time
        isPaused = false; // Update pause state

        if (audioManager != null)
        {
            audioManager.ResumeMusic(); // Resume the music
        }
        else
        {
            Debug.LogWarning("AudioManager reference is missing during Resume call.");
        }
    }

    // Method to pause the game
    void Pause()
    {
        pauseMenuUI.SetActive(true); // Show the pause menu
        healthBar.SetActive(false); // Show the pause menu
        compass.SetActive(false); // Show the pause menu
        Time.timeScale = 0f; // Freeze game time
        isPaused = true; // Update pause state

        if (audioManager != null)
        {
            audioManager.PauseMusic(); // Pause the music
        }
        else
        {
            Debug.LogWarning("AudioManager reference is missing during Pause call.");
        }
    }

    void Mute()
    {
        MenuManager.isMuted = !MenuManager.isMuted; // Toggle mute state
        if (MenuManager.isMuted)
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
}
