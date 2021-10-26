using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class lastgame : MonoBehaviour
{
    public GameObject cookie;
    public GameObject cookie2;

    public void cookieactive()
    {
        cookie.SetActive(true);
        cookie2.SetActive(true);
    }

}
