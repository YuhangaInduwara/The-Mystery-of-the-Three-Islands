using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PauseMenuManager : MonoBehaviour
{
    public GameObject pauseMenuUI; 
    public GameObject compass;
    public GameObject healthBar;
    private bool isPaused = false;
    public TMP_Text buttonText;
    public AudioManager audioManager;
    
    public Button resumeButton; 
    public Button muteButton;
    public Button quitButton;
    private EventSystem eventSystem;

    private void Start()
    {
        eventSystem = EventSystem.current;

        if (eventSystem == null)
        {
            Debug.LogError("EventSystem is missing from the scene.");
        }

        // Default mute state setup
        if (MenuManager.isMuted)
        {
            buttonText.text = "Unmute";
        }
        else
        {
            buttonText.text = "Mute";
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    // Method to resume the game
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        healthBar.SetActive(true);
        compass.SetActive(true);
        Time.timeScale = 1f; 
        isPaused = false; 

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        if (audioManager != null)
        {
            audioManager.ResumeMusic(); 
        }
    }

    // Method to pause the game
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        healthBar.SetActive(false);
        compass.SetActive(false);
        Time.timeScale = 0f; 
        isPaused = true; 

        Cursor.visible = true;  // Make sure the cursor is visible when the menu is active
        Cursor.lockState = CursorLockMode.None;

        // Select the Resume button so keyboard navigation starts from there
        eventSystem.SetSelectedGameObject(resumeButton.gameObject);

        if (audioManager != null)
        {
            audioManager.PauseMusic();
        }
    }

    // Method to mute/unmute the game
    public void Mute()
    {
        MenuManager.isMuted = !MenuManager.isMuted;
        buttonText.text = MenuManager.isMuted ? "Unmute" : "Mute";
    }

    // Method to quit the game
    public void QuitGame()
    {
        Application.Quit();
    }

    // Function to handle button click that hides the cursor
    public void OnButtonClicked()
    {
        Cursor.visible = false;  // Hide the cursor when an option is selected
        Cursor.lockState = CursorLockMode.Locked;
    }
}
