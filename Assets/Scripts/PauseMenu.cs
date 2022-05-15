using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject optionsMenuUI;

    private void Start()
    {
        ResumeGame();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // If the game is already paused, unpause. If the game isn't paused, pause.
            if (GameIsPaused)
            {
                ResumeGame(); // Mouse does not lock back with the game because Escape key is being pressed which unity automatically unlocks the cursor
                Debug.Log(Cursor.visible);
            }
            else
            {
                PauseGame();
                Debug.Log(Cursor.visible);
            }
        }
    }
    public void ResumeGame()
    {
        //Deactivate both canvases and lock the cursor back to the screen
        pauseMenuUI.SetActive(false);
        optionsMenuUI.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        GameIsPaused = false;
    }

    void PauseGame()
    {
        //Pause the game when this method is called. Unlocks the cursor from the screen
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        GameIsPaused = true;
    }

    public void Options()
    {
        //Open the options menu and closes the pause menu
        pauseMenuUI.SetActive(false);
        optionsMenuUI.SetActive(true);
    }

    public void Back()
    {
        //Goes back from the options menu to the pause menu
        pauseMenuUI.SetActive(true);
        optionsMenuUI.SetActive(false);
    }

    public void QuitGame()
    {
        // Quits to main menu
        Debug.Log("Quitting to main menu...");

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }



}