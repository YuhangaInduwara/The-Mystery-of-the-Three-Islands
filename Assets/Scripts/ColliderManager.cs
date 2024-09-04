using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionReset : MonoBehaviour
{
    public GameObject player;  // Reference to the Player object
    public GameObject cube;    // Reference to the Cube object

    private void OnCollisionEnter(Collision collision)
    {
       
        // Check if the player and cube are the colliding objects
        if ((collision.gameObject == player || collision.gameObject == cube) && collision.gameObject != this.gameObject)
        {
               
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
          
        }
    }
}
