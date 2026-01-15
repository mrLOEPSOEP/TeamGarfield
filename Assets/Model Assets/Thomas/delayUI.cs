using UnityEngine;
using System.Collections;

public class delayUI : MonoBehaviour
{
    public GameObject UIpopup;

    void Start()
    {
        UIpopup.SetActive(false);
    }

    public void ShowUI()
	{
		StartCoroutine(PopUI(1.0f));
	}
    
    public void HideUI()
    {
	    UIpopup.SetActive(false);
    }

	IEnumerator PopUI(float time)
	{
		yield return new WaitForSeconds(time);
		UIpopup.SetActive(true);
	}
}
