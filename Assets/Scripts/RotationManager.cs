using UnityEngine;
using UnityEngine.SceneManagement;

public class RotationManager : MonoBehaviour
{
    public float rotationSpeed = 50f;
    
    // Assign the player object in the Inspector
    public GameObject player;

    void Update()
    {
        // Rotate the object around the Z-axis (forward vector)
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }

    // Detect player collision
    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object is the player
        if (other.gameObject == player)
        {
            // Load the next scene (Level_02)
            SceneManager.LoadScene("Level_02");
        }
    }
}
