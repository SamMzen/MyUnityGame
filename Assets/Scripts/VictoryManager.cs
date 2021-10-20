using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class VictoryManager : MonoBehaviour
{

    [SerializeField] GameObject victoryScreen;
    [SerializeField] Text victoryButton;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip victoryMusic;
    private Color color;
    private float fading = 0f;

    void Start()
    {
        victoryScreen.GetComponent<Image>().color = new Color(0,0,0,1);
        victoryButton.GetComponent<Text>().color = new Color(0,0,0,1);
        StartCoroutine("DebutFade");
    }

    IEnumerator DebutFade()
    {
        yield return new WaitForSeconds(1.5f);
        audioSource.Play();
        StartCoroutine("Fade");
    }

    IEnumerator Fade()
    {
        fading += 0.01f;
        victoryScreen.GetComponent<Image>().color = new Color(fading,fading,fading,100);
        victoryButton.GetComponent<Text>().color = new Color(fading,fading,fading,100);
        yield return new WaitForSeconds(0.05f);
        StartCoroutine("Fade");
    }
}
