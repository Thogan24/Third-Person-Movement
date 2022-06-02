using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenuBanana;
    public GameObject StartGameButton;
    public GameObject OptionsButton;
    public GameObject QuitButton;
    public GameObject OptionsPage;

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Options()
    {
        StartGameButton.SetActive(false);
        OptionsButton.SetActive(false);
        QuitButton.SetActive(false);
        OptionsPage.SetActive(true);
    }

    public void QuitGame()
    {
        
        Debug.Log("Quitting Game...");
        Application.Quit();
    }

    public void Back()
    {
        StartGameButton.SetActive(true);
        OptionsButton.SetActive(true);
        QuitButton.SetActive(true);
        OptionsPage.SetActive(false);
        
    }

    public void FixedUpdate()
    {
        Vector3 rotationVector = mainMenuBanana.transform.rotation.eulerAngles;
        rotationVector.y += 30f * Time.deltaTime;
        mainMenuBanana.transform.rotation = Quaternion.Euler(rotationVector);
    }

}
