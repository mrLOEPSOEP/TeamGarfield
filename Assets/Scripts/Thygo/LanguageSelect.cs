using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LanguageSelect : MonoBehaviour
{
    [SerializeField] GameObject menuManagerObject;
    MenuManager menuManager;

    //Getting the menu manager on the actual gameobject
    void Start()
    {
        menuManager = menuManagerObject.GetComponent<MenuManager>();
    }


    //Functionality of the buttons
    public void OnEnglishSelected()
    {
        menuManager.languageIsDutch = false;
        SceneManager.LoadScene("GamemodeSelectionScene");
    }   

    public void OnDutchSelected()
    {
        menuManager.languageIsDutch = true;
        SceneManager.LoadScene("GamemodeSelectionScene");
    } 
}
