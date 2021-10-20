using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DragAndDropVictory : MonoBehaviour
{

    public GameObject buttonImage;

    void Update()
    {
      if(transform.childCount == 6)
      {
          Destroy(buttonImage);
      }
    }

    public void OKbutton()
    {
        if(transform.childCount == 6)
        {
            SceneManager.LoadScene("DesktopScene");
        }
    }
}
