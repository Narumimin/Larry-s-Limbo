using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public string previousScene;

    private void Awake()
    {
        Debug.Log("GameManager ESTA VIVO: " + SceneManager.GetActiveScene().name);

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            Debug.Log("GameManager SIGUE VIVO.");
        }
        else if (Instance != this)
        {
            Debug.LogWarning("OH NO.");
            Destroy(gameObject);
        }
    }

    public void SetPreviousScene(string sceneName)
    {
        Debug.Log("Setting Previous Scene: " + sceneName);
        previousScene = sceneName;
    }
}
