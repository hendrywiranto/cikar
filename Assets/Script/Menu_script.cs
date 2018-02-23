using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu_script : MonoBehaviour {

    public Button bhtplay,bscanar,bquiz,babout,bexit;

    void Start () {
        bhtplay.onClick.AddListener(GoToHowtoPlay);
        bscanar.onClick.AddListener(GoToScanAr);
        bquiz.onClick.AddListener(GoToQuiz);
        babout.onClick.AddListener(GoToAbout);
        bexit.onClick.AddListener(ExitApplication);
    }

    public void GoToHowtoPlay()
    {
        SceneManager.LoadScene("howtoplay");
    }

    public void GoToScanAr()
    {
        SceneManager.LoadScene("scanar");
    }

    public void GoToQuiz()
    {
        SceneManager.LoadScene("quiz");
    }

    public void GoToAbout()
    {
        SceneManager.LoadScene("about");
    }

    public void ExitApplication()
    {
        Application.Quit();
    }

}
