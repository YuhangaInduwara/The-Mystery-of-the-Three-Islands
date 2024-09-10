using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using UnityEngine.UI;

public class VideoSceneTransition : MonoBehaviour
{
    public VideoPlayer videoPlayer;  // Attach the VideoPlayer component here
    public Button skipButton;  // Attach your skip button here
    private bool sceneTransitioned = false;

    void Start()
    {
        // Set up the skip button listener
        if (skipButton != null)
        {
            skipButton.onClick.AddListener(SkipScene);
        }

        // Start playing the video
        videoPlayer.Play();

        // Start a coroutine to handle scene transition 1 second before video ends
        StartCoroutine(CheckForVideoEnd());

        // Skip button should transition to the next scene immediately
        videoPlayer.loopPointReached += EndReached;
    }

    // Skip to the next scene if the skip button is pressed
    void SkipScene()
    {
        LoadNextScene();
    }

    // Coroutine to check for the video's end (minus 1 second)
    System.Collections.IEnumerator CheckForVideoEnd()
    {
        // Wait until the video is almost done, minus 1 second
        yield return new WaitForSeconds((float)videoPlayer.length - 0.3f);

        if (!sceneTransitioned)
        {
            LoadNextScene();
        }
    }

    // Called when the video reaches the end
    void EndReached(VideoPlayer vp)
    {
        if (!sceneTransitioned)
        {
            LoadNextScene();
        }
    }

    // Load the next scene
    void LoadNextScene()
    {
        sceneTransitioned = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
