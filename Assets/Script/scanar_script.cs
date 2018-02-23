using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class scanar_script : MonoBehaviour {

    public Button bmenu;
    public Button bclose;
    public GameObject detail;
	// Use this for initialization
	void Start () {		
        bmenu.onClick.AddListener(GoToMenu);
        bclose.onClick.AddListener(Close);
    }
	
	void GoToMenu()
    {
        SceneManager.LoadScene("menu");
    
    }

    void Close()
    {
         detail.gameObject.SetActive(false);
        bclose.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))GoToMenu();
    }
}
