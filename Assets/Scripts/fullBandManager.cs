using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class fullBandManager : MonoBehaviour
{
    public GameManagerE2 gameManagerE2;
    public GameObject error, error1, error2, error3, error4, error5, error6, error7, error8, error9, error10;
    public int err;

    void Start()
    {
        error.SetActive(false);
        error1.SetActive(false);
        error2.SetActive(false);
        error3.SetActive(false);
        error4.SetActive(false);
        error5.SetActive(false);
        error6.SetActive(false);
        error7.SetActive(false);
        error8.SetActive(false);
        error9.SetActive(false);
        error10.SetActive(false);
        gameManagerE2 = GameObject.FindGameObjectWithTag("GameManagerE2").GetComponent<GameManagerE2>();
    }

    void OnMouseOver()
    {
        if (gameManagerE2.isGameRunning)
        {
            //mouse over a danger band
            if (this.transform.name == "leftBand" || this.transform.name == "rightBand")
            {
                //Debug.Log("a band");
                if (gameManagerE2.life > 0 && gameManagerE2.isCollisionActive)
                {
                    gameManagerE2.isCollisionActive = false;
                    StartCoroutine(gameManagerE2.TempInactivity());
                }
                else if (gameManagerE2.life <= 0 && gameManagerE2.isCollisionActive)
                {
                    gameManagerE2.bandSpeed = 0;
                    StartCoroutine(ExampleCoroutine());
                    //  error.SetActive(true);
                    //   error1.SetActive(true);
                    //    error2.SetActive(true);
                    //     error3.SetActive(true);
                    //      error4.SetActive(true);
                    //       error5.SetActive(true);

                    //        SceneManager.LoadScene("Ecran Défaite");

                    //     Cursor.SetCursor(gameManagerE2.cursorTexture2, gameManagerE2.hotSpot, gameManagerE2.cursorMode);
                }
            }

            //mouse over the finish band
            else if (this.transform.name == "finishBand")
            {
                //Debug.Log("finish band");
                gameManagerE2.isGameRunning = false;
                gameManagerE2.bandSpeed = 0;
                OverheatBar.heat += 1.0f;
                OverheatBar.isGame3Finished = true;
                SceneManager.LoadScene("HubCentrale");
            }
        }

    }

    IEnumerator ExampleCoroutine()
    {
        error.SetActive(true);
        error1.SetActive(true);
        error2.SetActive(true);
        error3.SetActive(true);
        error4.SetActive(true);
        error5.SetActive(true);
        error6.SetActive(true);
        error7.SetActive(true);
        error8.SetActive(true);
        error9.SetActive(true);
        error10.SetActive(true);
        yield return new WaitForSeconds(5);

        SceneManager.LoadScene("Ecran Défaite");

        Cursor.SetCursor(gameManagerE2.cursorTexture2, gameManagerE2.hotSpot, gameManagerE2.cursorMode);
    }

}
