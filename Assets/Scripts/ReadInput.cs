using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ReadInput : MonoBehaviour
{

    [SerializeField] GameObject inputField;
    [SerializeField] GameObject inputText;
    [SerializeField] GameObject hackingBar;
    private string input;
    private string password = "COOKIE";

    public void Uppercase()
    {
      input = inputText.GetComponent<InputField>().text;
      input = input.ToUpper();
      inputText.GetComponent<InputField>().text = input;
      Debug.Log(input);
    }

    public void PasswordCheck()
    {
        if(input == password)
        {
            hackingBar.SetActive(true);
        }
        else
        {
            SceneManager.LoadScene("GameOverScene");
        }
    }
}
