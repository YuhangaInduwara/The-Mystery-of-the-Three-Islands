using UnityEngine;
using UnityEngine.SceneManagement;

public class RotationManager : MonoBehaviour
{
    public float rotationSpeed = 50f;
    
    public GameObject player;

    void Update()
    {
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
    }
}

