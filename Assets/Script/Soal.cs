using UnityEngine;
using System.Collections;
using LitJson;
using UnityEngine.UI;

public class Soal : MonoBehaviour {

	public string jsonString;
	public JsonData soalData;
	public int numberSoal=0;
	public GameObject jawabanPrefab;
	public bool nextSoal;
	public bool clickJawaban;
	public int score;
    private string jsonNameTemp;


	public void SoalBegin(string jsonName){
		score = 0;
		nextSoal = true;
		TextAsset file = Resources.Load("Soal/"+jsonName) as TextAsset;
 		jsonString = file.ToString();
        jsonNameTemp = jsonName;
		soalData = JsonMapper.ToObject (jsonString);
		OnClick ();
	}


	public void OnClick(){
		if (numberSoal >= soalData ["data"].Count) {
			Debug.Log("Soal Habis Lalu Pindah Menu ke Result");

			if(score == soalData["data"].Count){
				GameObject.Find("Rank").GetComponent<Text>().text = "Sangat baik";//bintang 3
			}else
			if(score >= soalData["data"].Count*1/2){
				GameObject.Find("Rank").GetComponent<Text>().text = "Baik";//bintang 2
			}else
			if(score <= soalData["data"].Count*1/2){
				GameObject.Find("Rank").GetComponent<Text>().text = "Buruk";//bintang 1
			}

			MenuManager menuResult = GameObject.Find("Canvas").GetComponent<MenuManager>();
			menuResult.ShowMenu (GameObject.Find("Result").GetComponent<Menu>());

			GameObject.Find("Score").GetComponent<Text>().text = score.ToString()+"/"+ soalData["data"].Count;
            if (!PlayerPrefs.HasKey(jsonNameTemp))
            {
                PlayerPrefs.SetInt(jsonNameTemp, score);
            }
            else if (PlayerPrefs.GetInt(jsonNameTemp) < score)
            {
                PlayerPrefs.SetInt(jsonNameTemp, score);
            }

        }

			if (nextSoal) {
				GameObject[] jawabanDestroy = GameObject.FindGameObjectsWithTag ("Jawaban");
				if (jawabanDestroy != null) {
					for (int x=0; x<jawabanDestroy.Length; x++) {
						DestroyImmediate (jawabanDestroy [x]);
					}
				}

				GameObject.Find ("Soal/Panel/SoalC/Soal").GetComponentInChildren<Text> ().text = soalData ["data"] [numberSoal] ["soal"].ToString ();

				for (int i=0; i<soalData["data"][numberSoal]["jawaban"].Count; i++) {

					GameObject jawaban = Instantiate (jawabanPrefab);
					jawaban.GetComponentInChildren<Text> ().text = soalData ["data"] [numberSoal] ["jawaban"] [i].ToString ();
					Transform jawabanC = GameObject.Find ("JawabanC").GetComponent<Transform> ();
					jawaban.transform.SetParent (jawabanC);

					string x = i.ToString ();

					if (i == 0) {
						jawaban.name = "JawabanBenar";
						jawaban.GetComponent<Button> ().onClick.AddListener (() => Jawaban ("0"));
					} else {
						jawaban.name = "JawabanSalah" + x;
						jawaban.GetComponent<Button> ().onClick.AddListener (() => Jawaban (x));
					}
					jawaban.transform.SetSiblingIndex (Random.Range (0, 3));
				}

				numberSoal++;
				nextSoal = false;
				clickJawaban = true;
				StartCoroutine ("Timer");
			}

	}
	public void Jawaban(string x){
		if (clickJawaban) {
			if (x == "0") {
				score++;
				GameObject.Find ("JawabanBenar").GetComponent<Button> ().image.color = Color.green;
				GameObject.Find("Image ("+numberSoal+")").GetComponent<Image>().color = Color.green;
				Debug.Log ("Jawaban Benar");
			} else {
				GameObject.Find ("JawabanSalah" + x).GetComponent<Button> ().image.color = Color.red;
				GameObject.Find ("JawabanBenar").GetComponent<Button> ().image.color = Color.green;
				GameObject.Find("Image ("+numberSoal+")").GetComponent<Image>().color = Color.red;
				Debug.Log ("Jawaban Salahh");
			}
		}
		nextSoal = true;
		clickJawaban = false;

	}
	IEnumerator Timer(){
		Image time = GameObject.Find ("Timer").GetComponent<Image> ();
		time.fillAmount =1;
		float timeToWait = 30f;
		float incrementToRemove = 0.05f;
		float x = time.fillAmount / timeToWait * incrementToRemove;

		while(timeToWait>0){
			yield return new WaitForSeconds(incrementToRemove);

			if(!nextSoal){
				time.fillAmount -=x;
				timeToWait-=incrementToRemove;
			}else{
				timeToWait = 0;
			}

		}
		if (time.fillAmount <= 0.1f) {
			for(int i=1; i<4; i++){
				GameObject.Find ("JawabanSalah" + i).GetComponent<Button> ().image.color = Color.red;
			}
			GameObject.Find ("JawabanBenar").GetComponent<Button> ().image.color = Color.green;
			GameObject.Find("Image ("+numberSoal+")").GetComponent<Image>().color = Color.red;
			clickJawaban = false;
			nextSoal = true;
		}

	}



}
