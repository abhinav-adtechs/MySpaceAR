using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using SimpleJSON;


public class UpdateNotification : MonoBehaviour {


	public Text displayText ;
	string getUrl = "https://myspace-api-abhinav-adtechs.c9users.io/getAll" ; 
	public UpdateNotification() {
		
	}

	// Use this for initialization
	public void Start () {
		displayText = GetComponent <Text>();

		InvokeRepeating("testingMethod", 2.0f, 5.0f);
	}

	public void postNotification(string notificationDataString){

		Debug.Log ("Posting Notification again");
		string temp = displayText.text;
		displayText.text = temp + "\n" + notificationDataString ; 
	}

	public void testingMethod(){
		Debug.Log ("Posting Notification testing again");


		WWW www = new WWW(getUrl);
	
		StartCoroutine(WaitForRequest(www));
	}
	
	// Update is called once per frame

	//private float nextActionTime = 0.0f;
	//public float period = 0.1f;
	void Update () {

	}

	IEnumerator WaitForRequest (WWW www)
	{
		yield return www;

		// check for errors
		if (www.error == null)
		{
			Debug.Log("WWW Ok!: " + www.text);
			NotificationData notifData = new NotificationData();
			notifData.data = new NotificationItem[1];


			var jsonRaw = JSON.Parse (www.text);
			var jsonData = jsonRaw ["data"];

			displayText.text = " ";


			Debug.Log("WWW Ok!: " + jsonData);

			for (int i = 0; i < jsonData.Count; i++) {
				var provider = jsonData [i]["provider"];
				var devTimestamp = jsonData [i] ["devTimestamp"];
				var notifId = jsonData [i] ["notifId"]; 
				var title = jsonData [i] ["title"];
				var message = jsonData [i] ["message"]; 

				DateTime dateRaw = UnixTimeStampToDateTime (devTimestamp.AsDouble);
				string dateString = dateRaw.ToLongTimeString();

				Debug.Log("WWW Ok!: " + provider);
				string postString = " " + dateString + "\t" + provider + "\n \t\t " + title + "\n \t\t" + message;


				postNotification (postString);

			}
			//Debug.Log("WWW Ok!: " + jsonArrayData);
			//JsonUtility.FromJsonOverwrite(www.text, notifData); 


			/*for (int i = 0; i < notifData.data.Length; i++) {
				Debug.Log("WWW Ok!: " + notifData.data[0].provider);
			}*/



		} else {
			Debug.Log("WWW Error: "+ www.error);
		}    
	}

	public static DateTime UnixTimeStampToDateTime( double unixTimeStamp )
	{
		// Unix timestamp is seconds past epoch
		System.DateTime dtDateTime = new DateTime(1970,1,1,0,0,0,0,System.DateTimeKind.Utc);
		dtDateTime = dtDateTime.AddSeconds( unixTimeStamp ).ToLocalTime();
		return dtDateTime;
	}
}
