using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HackingBar : MonoBehaviour
{

    [SerializeField] GameObject slider;

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip audioClip;

    [SerializeField] GameObject inProcess;
    private Color color;


    void Start()
    {
        audioSource.PlayOneShot(audioClip);
        StartCoroutine("FillHackBar");
        StartCoroutine("ShowProcessing");
    }

    void Update()
    {
        if(slider.GetComponent<Slider>().value == 1)
        {
            SceneManager.LoadScene("VictoryScene");
        }
    }

    IEnumerator FillHackBar()
    {
        yield return new WaitForSeconds(0.05f);
        slider.GetComponent<Slider>().value += 0.01f;
        StartCoroutine("FillHackBar");
    }

    IEnumerator HideProcessing()
    {
        inProcess.GetComponent<Text>().color = new Color(1,1,1,0);
        yield return new WaitForSeconds(0.3f);
        StartCoroutine("ShowProcessing");
    }

    IEnumerator ShowProcessing()
    {
        inProcess.GetComponent<Text>().color = new Color(1,1,1,1);
        yield return new WaitForSeconds(0.3f);
        StartCoroutine("HideProcessing");
    }
}
