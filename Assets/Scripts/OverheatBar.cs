using UnityEngine;
using UnityEngine.UI;

public class OverheatBar : MonoBehaviour
{

    [SerializeField] GameObject slider;
    [SerializeField] GameObject iconGame2;
    [SerializeField] GameObject iconGame3;
    [SerializeField] GameObject iconPassword;
    [SerializeField] GameObject heatButton;
    [SerializeField] GameObject passwordImage;
    [SerializeField] GameObject passwordClueImage;
    [SerializeField] GameObject passwordInput;

    public static float heat = 1;
    public static bool isGame2Finished = false;
    public static bool isGame3Finished = false;
    private float maxHeat = 3.0f;

    void Update()
    {
        slider.GetComponent<Slider>().value = heat / maxHeat;
        if(isGame2Finished == true)
        {
            iconGame2.GetComponent<Button>().interactable = false;
        }
        if(isGame3Finished == true)
        {
            iconGame3.GetComponent<Button>().interactable = false;;
        }
        if(isGame3Finished == true && isGame2Finished == true)
        {
            heatButton.SetActive(true);
            iconPassword.GetComponent<Button>().interactable = true;
        }
    }

    public void OpenPassword()
    {
        passwordImage.SetActive(true);
    }

    public void OpenPasswordClue()
    {
        passwordClueImage.SetActive(true);
    }

    public void OpenPasswordInput()
    {
        passwordInput.SetActive(true);
    }

    public void ClosePasswordInput()
    {
        passwordInput.SetActive(false);
    }
}
