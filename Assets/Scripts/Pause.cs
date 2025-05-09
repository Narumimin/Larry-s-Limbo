using UnityEngine;

public class Pause : MonoBehaviour
{
    private bool isPaused = false;
    public GameObject pausePanel;
    public GameObject pauseButton;

    public void TogglePause()
    {
        isPaused = !isPaused;

        Time.timeScale = isPaused ? 0 : 1;

        if (pausePanel != null)
        {
            pausePanel.SetActive(isPaused);
            pauseButton.SetActive(!isPaused);
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }
}
