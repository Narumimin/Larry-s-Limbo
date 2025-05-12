using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour
{
    private bool canvasControlesActivo = false;
    public GameObject canvasControles;
    public GameObject canvasMenu;

    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void ContinueButton()
    {
        LoadNextScene();
    }

    public void ToggleControles()
    {
        canvasControlesActivo = !canvasControlesActivo;

        if (canvasControles != null)
        {
            canvasControles.SetActive(canvasControlesActivo);
            canvasMenu.SetActive(!canvasControlesActivo);
        }
    }
}