using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getNotificationData : MonoBehaviour {


	public string getUrl = "https://myspace-api-abhinav-adtechs.c9users.io/getAll" ;
	// Use this for initialization
	void Start () {

		Debug.Log ("Starting custom script");
		WWW www = new WWW(getUrl);
		StartCoroutine(WaitForRequest(www));

	}

	IEnumerator WaitForRequest (WWW www)
	{
		yield return www;

		// check for errors
		if (www.error == null)
		{
			Debug.Log("WWW Ok!: " + www.text);
		} else {
			Debug.Log("WWW Error: "+ www.error);
		}    
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
