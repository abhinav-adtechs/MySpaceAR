using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class rawActivity : MonoBehaviour {


	string worldString ; 
	// Use this for initialization
	void Start () {

		Console.WriteLine ("Name?");
		worldString = Console.ReadLine ();
		Console.WriteLine(worldString);

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
