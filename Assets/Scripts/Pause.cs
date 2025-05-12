using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    private bool isPaused = false;
    public GameObject pausePanel;

    public void TogglePause()
    {
        isPaused = !isPaused;

        Time.timeScale = isPaused ? 0 : 1;

        if (pausePanel != null)
        {
            pausePanel.SetActive(isPaused);
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void Salir()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
