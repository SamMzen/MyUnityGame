using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class fullBandManager : MonoBehaviour
{
    public GameManagerE2 gameManagerE2;

    void Start()
    {
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
        Cursor.SetCursor(gameManagerE2.cursorTexture2, gameManagerE2.hotSpot, gameManagerE2.cursorMode);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("error scene");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Ecran Défaite");
    }

}
