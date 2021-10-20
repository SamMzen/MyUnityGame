using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public void StartGame()
    {
      SceneManager.LoadScene("PasswordGame");
    }

    public void QuitGame()
    {
      Application.Quit();
    }

    public void GoToMainMenu()
    {
      SceneManager.LoadScene("MainMenu");
      OverheatBar.isGame2Finished = false;
      OverheatBar.isGame3Finished = false;
      OverheatBar.heat = 1;
    }

    public void LoadMiningGame()
    {
      SceneManager.LoadScene("MiningGame");
    }

    public void LoadFirewallGame()
    {
      SceneManager.LoadScene("FirewallGame");
    }
}
