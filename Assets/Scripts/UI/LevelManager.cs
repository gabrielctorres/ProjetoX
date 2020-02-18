using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public GameObject PanelGame, PanelPause, PanelSettings; // panels
    public GameObject PlayerComponent; // player
    public PlayerScript playerScript;
    void Start()
    {
        // time start
        Time.timeScale = 1;
    }


    private void Update()
    {
        telaMorte();        
    }
    void telaMorte()
    {
        if (playerScript.morreu)
        {
            PanelGame.SetActive(false);
            PanelPause.SetActive(true);
            PanelSettings.SetActive(false);
        }
    }

    #region PANELS MANAGER
    // check panel game
    public void LevelGame(bool g) => PanelGame.SetActive(g);

    // check pause game
    public void OnApplicationPause(bool pause)
    {
        PanelPause.SetActive(pause);

        // check pause false
        if (pause == false)
        {
            Time.timeScale = 1;
            PlayerComponent.SetActive(true);
        }
        // check pause true
        if (pause == true)
        {
            Time.timeScale = 0;
            PlayerComponent.SetActive(false);
        }
    }

    // check panel settings
    public void SettingsGame(bool set) => PanelSettings.SetActive(set);
    #endregion

    // retry game
    public void RetryGame() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
}