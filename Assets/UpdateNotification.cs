using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class UpdateNotification : MonoBehaviour {


	public Text displayText ;

	public UpdateNotification() {
		
	}

	// Use this for initialization
	public void Start () {
		displayText = GetComponent <Text>();
	}

	public void postNotification(string notificationData){
		displayText.text = notificationData; 
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
