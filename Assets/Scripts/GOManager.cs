using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GOManager : MonoBehaviour
{
    public GameObject goMessage, messageHolder, blackBG, loseScreen;
    public SpriteRenderer rend;

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip errorSound;
    [SerializeField] AudioClip GOmusique;

    private int posX, posY;
    private Vector3 goMessageScale;

    public float timeFirstMessage = 0.5f;
    public float timeRate = 0.05f;
    public float maxMessage = 50;

    private int messageSpawned = 0;
    private bool canDisplay = true;
    private bool blackScreen = true;
    private bool goScreen = true;

    // Start is called before the first frame update
    void Start()
    {
        goMessageScale = goMessage.transform.lossyScale;

        InvokeRepeating("DisplayMessage", timeFirstMessage, timeRate);

        Color c = rend.material.color;
        c.a = 0f;
        rend.material.color = c;
    }

    // Update is called once per frame
    void Update()
    {
       if(messageSpawned >= maxMessage)
        {
            canDisplay = false;
        }

       if(messageSpawned >= maxMessage / 2)
        {
            timeRate = 0.25f;
        }
    }

    void DisplayMessage()
    {
        if(canDisplay)
        {
            //pick random posX and posY between the canvas limits
            posX = Random.Range(-155, 155) % 155;
            posY = Random.Range(-80, 80) % 80;

            //instantiate message at this random pos
            Instantiate(goMessage, messageHolder.transform.position + new Vector3(posX / goMessageScale[0], posY / goMessageScale[1], 0), Quaternion.identity, messageHolder.transform);

            //play error sound
            audioSource.PlayOneShot(errorSound);

            messageSpawned++;
        }

        if(!canDisplay && blackScreen)
        {
            blackScreen = false;
            blackBG.SetActive(true);
        }

        if(!canDisplay && !blackScreen && goScreen)
        {
            goScreen = false;
            //loseScreen.SetActive(true);
            Invoke("SC", 2.0f);
        }

    }

    void SC()
    {
        StartCoroutine("FadeIn");
        audioSource.Play();
    }

    IEnumerator FadeIn()
    {
        for(float f = 0.05f; f <= 1; f += 0.05f)
        {
            Color c = rend.material.color;
            c.a = f;
            rend.material.color = c;
            yield return new WaitForSeconds(0.05f);
        }
    }
}
