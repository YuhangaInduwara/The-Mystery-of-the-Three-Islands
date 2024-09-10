using UnityEngine;
using UnityEngine.SceneManagement;

public class FloorRepeat : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
