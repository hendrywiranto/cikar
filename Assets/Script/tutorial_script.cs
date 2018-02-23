using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class tutorial_script : MonoBehaviour {

	public Image imagetut;
	public Button bnext,bprev,bmenu;
	int i=1,numimages=4;
	// Use this for initialization
	void Start () {
		imagetut.sprite=Resources.Load<Sprite>("tut"+i);	
		bnext.onClick.AddListener(nextClick);
		bprev.onClick.AddListener(prevClick);
		bmenu.onClick.AddListener(GoToMenu);
	}
	
	// Update is called once per frame
	public void prevClick() {
		if(i>1){
			i--;
			imagetut.sprite=Resources.Load<Sprite>("tut"+i);	
		}
	}
	public void nextClick() {
		if(i<numimages){
			i++;
			imagetut.sprite=Resources.Load<Sprite>("tut"+i);			
		}
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


