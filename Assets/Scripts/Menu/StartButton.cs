using UnityEngine;

public class PauseGame : MonoBehaviour
{
    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Change KeyCode.Space to the key you want to use
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Pause();
        }
        else
        {
            Unpause();
        }
    }

    private void Pause()
    {
        Time.timeScale = 0f; // Pauses the game
        Debug.Log("Game Paused");
    }

    private void Unpause()
    {
        Time.timeScale = 1f; // Resumes the game
        Debug.Log("Game Unpaused");
    }
}
