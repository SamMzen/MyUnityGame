using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class lastgame : MonoBehaviour
{
    public GameObject cookie;
    public GameObject cookie2;
    public GameObject code;
    public GameObject cookiefin, cookiefin2;

    public void cookieactive()
    {
        cookie.SetActive(true);
        cookie2.SetActive(true);
    }

    public void cookietive()
    {
        cookiefin.SetActive(true);
        cookiefin2.SetActive(true);
        cookie.SetActive(false);
        cookie2.SetActive(false);
    }

    public void cookieative()
    {
        code.SetActive(true);
    }

}
