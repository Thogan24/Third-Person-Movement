using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class MainUI : MonoBehaviour
{

    public bool GameIsPaused = false; //static?
    public GameObject pauseMenuUI;
    public GameObject optionsMenuUI;
    public Slider healthBarSlider;
    public TextMeshProUGUI healthText;
    public Slider sprintBarSlider;
    public TextMeshProUGUI sprintText;
    public GameObject player;
    private PlayerStats ps;
    private void Start()
    {
        ps = player.GetComponent<PlayerStats>();
        healthBarSlider.maxValue = ps.maxPlayerHealth;
        sprintBarSlider.maxValue = ps.maxPlayerSprint;
        ResumeGame();
    }

    void Update()
    {
        healthBarSlider.value = ps.playerHealth;
        healthText.text = ps.playerHealth.ToString();
        sprintBarSlider.value = (int)ps.playerSprint;
        sprintText.text = Mathf.Clamp((int)ps.playerSprint, 0, int.MaxValue).ToString();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // If the game is already paused, unpause. If the game isn't paused, pause.
            if (GameIsPaused)
            {
                ResumeGame(); // Mouse does not lock back with the game because Escape key is being pressed which unity automatically unlocks the cursor
                
            }
            else
            {
                Debug.Log("PAUSE GAME");
                PauseGame();
                
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