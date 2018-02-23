using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loading_script : MonoBehaviour {

    public Transform LoadingBar;

    [SerializeField] private float currentAmount;
    [SerializeField] private float speed;

    // Update is called once per frame
    void Update()
    {
        if (currentAmount < 100)
        {
            currentAmount += speed * Time.deltaTime;
            Debug.Log((int)currentAmount);
        }
        else
        {
            SceneManager.LoadScene("main_menu");
        }

        LoadingBar.GetComponent<Image>().fillAmount = currentAmount / 100;
    }

}
