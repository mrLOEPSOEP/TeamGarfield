using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LanguageSelect : MonoBehaviour
{
    //Functionality of the buttons
    public void OnEnglishSelected(bool english)
    {
        SceneManager.LoadScene("GamemodeSelectionScene");
    }   

    public void OnDutchSelected(bool dutch)
    {
        SceneManager.LoadScene("GamemodeSelectionScene");
    } 
}
