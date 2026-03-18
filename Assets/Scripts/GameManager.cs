using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public float worldSpeed ;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) || Input.GetButtonDown("Fire3") || Input.GetKeyDown(KeyCode.P))
        {
            Pause();
        }
    }

    public void Pause()
    {
        if (UIController.Instance.pausePanel.activeSelf == false)
        {
            UIController.Instance.pausePanel.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            UIController.Instance.pausePanel.SetActive(false);
            Time.timeScale = 1f;
            PlayerController.Instance.ExitBoost();
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
