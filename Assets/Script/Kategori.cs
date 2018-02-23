using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;

public class Kategori : MonoBehaviour {

	public GameObject katPrefab;
	public MenuManager menu;
	public Soal soal;

	string GetStreamingAssetsPath()
	{
		string path;
		#if UNITY_EDITOR
		path = Application.dataPath + "/StreamingAssets";
		#elif UNITY_ANDROID
		path = "jar:file://"+ Application.dataPath + "!/assets/";
		#elif UNITY_IOS
		path = Application.dataPath + "/Raw";
		#else
		//Desktop (Mac OS or Windows)
		path = "file:"+ Application.dataPath + "/StreamingAssets";
		#endif
		
		return path;
	}

	void Start () {

		RectTransform rect = gameObject.GetComponent<RectTransform> ();
		TextAsset[] files = Resources.LoadAll<TextAsset> ("Soal");
		foreach(TextAsset file in files){
			GameObject kat = Instantiate(katPrefab) as GameObject;
			kat.name = Path.GetFileNameWithoutExtension(file.name).ToString();
			kat.transform.SetParent(GameObject.Find("Kategori/Panel/Scroll/KategoriC").GetComponent<Transform>());
            string katName = kat.name;
            kat.GetComponentInChildren<Text>().text = kat.name + "(Tertinggi: " + PlayerPrefs.GetInt(kat.name) + ")";
			kat.GetComponent<Button>().onClick.AddListener(() => OnClick(katName));
            kat.GetComponent<Button>().onClick.AddListener(() => menu.ShowMenu(GameObject.Find("Canvas/Soal").GetComponent<Menu>()));

		}
		rect.sizeDelta = new Vector2 (rect.sizeDelta.x, (rect.sizeDelta.y/6)* files.Length);
	
	}

	public void OnClick(string kategori){
		soal.SoalBegin (kategori);
		Debug.Log(kategori);
	}

}
