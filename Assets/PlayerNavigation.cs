using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerNavigation : MonoBehaviour
{
    public Transform playerArmature;  // Reference to the PlayerArmature transform
    public Transform[] targetLocations;  // Array of target locations
    private int currentTargetIndex = 0;
    public TextMeshProUGUI distanceText;  // TextMesh Pro for displaying distance
    public TextMeshProUGUI quoteText;  // TextMesh Pro for displaying unique quotes
    public GameObject messagePanel;  // The UI panel to show the quote
    public Button okButton;  // The OK button to proceed
    public string[] locationQuotes;  // Array of unique quotes for each location
    public float stopDistance = 0.2f;  // Minimum distance to stop
    private EventSystem eventSystem;

    private bool canMove = true;  // Flag to control player movement

    //test comment
    
    private void Start()
    {
        eventSystem = EventSystem.current;
        if (eventSystem == null)
        {
            Debug.LogError("EventSystem is missing from the scene.");
        }
        // Add listener for OK button to move to the next target when clicked
        // okButton.onClick.AddListener(OnOkButtonClicked);

        // Initially hide the message panel
        messagePanel.SetActive(false);

        // Ensure the cursor is visible and not locked at the start
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    void Update()
    {
        if (currentTargetIndex < targetLocations.Length)
        {
            // Calculate the distance from the PlayerArmature to the current target
            float distanceToTarget = Vector3.Distance(playerArmature.position, targetLocations[currentTargetIndex].position);

            // If it's the last target, show a short, mysterious message
            if (currentTargetIndex == targetLocations.Length)
            {
                // Short and mysterious message for the last target
                Debug.Log("Currentttt Target Index: " + currentTargetIndex);   
                distanceText.text = "The mountain top holds the answer to your quest!";
            }
            else
            {
                // Update the distance on the TextMeshPro UI with a general message
                distanceText.text = "You are " + (distanceToTarget * 3.28084f).ToString("F2") + " feet away from the next clue.";
            }

            // If the player is close enough to the target location, stop movement and show the message
            if (distanceToTarget <= stopDistance)
            {
                ShowMessage();
                canMove = false;

                // Show the cursor when the message panel appears
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }


    public void ShowMessage()
    {
        // Show the message panel
        messagePanel.SetActive(true);

        // Display the unique quote for the current target location
        quoteText.text = locationQuotes[currentTargetIndex];

        // Show the cursor
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void OnOkButtonClicked()
    {
        // Log to check if the button click is detected
        Debug.Log("OK button clicked");

        // Hide the message panel when OK is clicked
        messagePanel.SetActive(false);

        // Move to the next target location
        if (currentTargetIndex < targetLocations.Length )  // Prevent going out of bounds
        {
            currentTargetIndex++;
            Debug.Log("Moved to next target: " + currentTargetIndex);
        }
        else
        {
            Debug.Log("No more targets to move to.");
        }

        // Allow the player to move to the next target
        canMove = true;

        // Optionally hide the cursor again during gameplay if needed
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;  // Lock cursor to the game screen while playing
    }
}
