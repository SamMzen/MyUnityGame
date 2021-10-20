using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float timeRemaining;
    private float initialTime;
    public bool timerIsRunning = true;

    [SerializeField] GameObject slider;
    [SerializeField] GameObject gameOverPanel;

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip gameOverSound;

    void Awake()
    {
        initialTime = timeRemaining;
    }

    void Update()
    {
        if (timerIsRunning)
        {
            DisplayTime(timeRemaining);

            if(timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                timerIsRunning = false;
                SceneManager.LoadScene("GameOverScene");
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        slider.GetComponent<Slider>().value = timeRemaining / initialTime;
    }
}
