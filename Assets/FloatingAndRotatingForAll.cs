using UnityEngine;

public class FloatingAndRotatingForAll : MonoBehaviour
{
    public float rotationSpeed = 50f;       // Rotation speed
    public float floatSpeed = 0.5f;         // Speed of the up-down floating
    public float floatAmplitude = 0.5f;     // Amplitude of the floating (how much it moves up and down)

    private GameObject[] targetLocations;   // Array to store all tagged objects
    private Vector3[] startPositions;       // Array to store initial positions of the objects

    void Start()
    {
        // Find all objects with the tag "TargetLocation"
        targetLocations = GameObject.FindGameObjectsWithTag("TargetLocation");
        startPositions = new Vector3[targetLocations.Length];

        // Save the initial positions of all tagged objects
        for (int i = 0; i < targetLocations.Length; i++)
        {
            startPositions[i] = targetLocations[i].transform.position;
        }
    }

    void Update()
    {
        // Loop through each "TargetLocation" and apply movement
        for (int i = 0; i < targetLocations.Length; i++)
        {
            if (targetLocations[i] != null)
            {
                // Rotate the object around its Y-axis
                targetLocations[i].transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime, Space.World);

                // Move the object up and down (floating)
                float newY = startPositions[i].y + Mathf.Sin(Time.time * floatSpeed) * floatAmplitude;
                targetLocations[i].transform.position = new Vector3(startPositions[i].x, newY, startPositions[i].z);
            }
        }
    }
}
