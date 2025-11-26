using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEditor;

public class LanguageSelect : Subject<ButtonType>
{
    [SerializeField] GameObject menuManagerObject;
    MenuManager menuManager;
    int languageSelected;

    //Getting the menu manager on the actual gameobject
    void Start()
    {
        menuManager = menuManagerObject.GetComponent<MenuManager>();
        //Testing notifyobservers on gamestart
    }


    //Functionality of the buttons
    public void OnEnglishSelected()
    {
        NotifyObservers(ButtonType.English);
        menuManager.languageIsDutch = false;
        SceneManager.LoadScene(2);
    }   

    public void OnDutchSelected()
    {
        menuManager.languageIsDutch = true;
        SceneManager.LoadScene(2);
    } 

}
