using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DataToMineVictory : MonoBehaviour
{

    [SerializeField] private GameObject OKbutton;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip victorySound;

    void Update()
    {
        if(transform.childCount == 0)
        {
            OKbutton.SetActive(true);
            audioSource.PlayOneShot(victorySound);
        }
    }

    public void FinishLevel()
    {
        OverheatBar.heat += 1.0f;
        OverheatBar.isGame2Finished = true;
        SceneManager.LoadScene("DesktopScene");
    }
}
