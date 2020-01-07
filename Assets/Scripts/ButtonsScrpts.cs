using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsScrpts : MonoBehaviour
{
    public GameObject MenuManager, Settings, Shop, Credits, Exit;

    // menu game
    public void MenuGame(bool m) => MenuManager.SetActive(m);

    // settings game
    public void SettingsGame(bool s) => Settings.SetActive(s);

    // shop game
    public void ShopGame(bool sh) => Shop.SetActive(sh);

    // credits game
    public void CreditsGame(bool c) => Credits.SetActive(c);

    // exit game
    public void ExitGame(bool c) => Exit.SetActive(c);

    // confirm exit game
    public void ConfirmExitGame() => Application.Quit();

    // load level
    public void LoadLevel() => SceneManager.LoadScene(1);
}