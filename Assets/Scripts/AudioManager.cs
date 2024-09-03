using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource musicSource; // Reference to the audio source
    public AudioClip background; // Reference to the background music clip

    private void Start()
    {
        if (!MenuManager.isMuted) // Check the static variable from MenuManager
        {
            musicSource.clip = background;
            musicSource.Play();
        }
    }

    public void PauseMusic()
    {
        musicSource.Pause();
    }

    public void ResumeMusic()
    {
        musicSource.UnPause();
    }

    private void Update()
    {
        // Ensure the mute state is reflected in real-time
        if (MenuManager.isMuted && musicSource.isPlaying)
        {
            musicSource.Pause();
        }
        else if (!MenuManager.isMuted && !musicSource.isPlaying)
        {
            musicSource.Play();
        }
    }
}
