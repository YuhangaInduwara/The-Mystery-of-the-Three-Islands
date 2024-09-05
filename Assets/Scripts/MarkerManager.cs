using UnityEngine;
using UnityEngine.SceneManagement;

public class RotateImage : MonoBehaviour
{
    public float rotationSpeed = 50f;
    
    public GameObject player;

    void Update()
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            SceneManager.LoadScene("Level_02");
        }
    }
}
