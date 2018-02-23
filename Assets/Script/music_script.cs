using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class music_script : MonoBehaviour {

	 static bool created = false;
	 void Awake() {
	     if (!created) {
	         DontDestroyOnLoad (this.gameObject);
	         created = true;
	     } else {
	         Destroy (this.gameObject);
	     }
	 }
	
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
