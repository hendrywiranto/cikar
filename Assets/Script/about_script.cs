using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class about_script : MonoBehaviour {
	public Button bmenu;
	// Use this for initialization
	void Start () {
		bmenu.onClick.AddListener(GoToMenu);
		
	}
	
	public void GoToMenu()
    {
        SceneManager.LoadScene("menu");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))GoToMenu();
    }
}
