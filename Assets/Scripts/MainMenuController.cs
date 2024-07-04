using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    //private GameObject CreditsMenu;

    private void Start()
    {
        //CreditsMenu = GameObject.Find("CreditsMenu");
        //Debug.Log($"{CreditsMenu.gameObject.name}");
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void CreditScreen()
    {
        Debug.Log("Teste");
        //CreditsMenu.SetActive(true);
    }
}
