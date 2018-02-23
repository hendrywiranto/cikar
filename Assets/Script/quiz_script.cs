using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class quiz_script : MonoBehaviour {
	public Button bmenu,bback;
    public MenuManager menu;
    // Use this for initialization
    void Start () {
		bmenu.onClick.AddListener(GoToMenu);
        bback.onClick.AddListener(GoBack);
        // Screen.orientation = ScreenOrientation.Portrait;
    }
	
	public void GoToMenu()
    {
        SceneManager.LoadScene("menu");
    }

    public void GoBack()
    {
        SceneManager.LoadScene("quiz");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))GoToMenu();
    }
}
