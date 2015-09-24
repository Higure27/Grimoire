using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKey("w"))
		{
			Debug.Log("w");
		}
		if(Input.GetKeyDown("s"))
		{
			Debug.Log ("s");
		}
		if(Input.GetKeyUp("a"))
		{
			Debug.Log ("a");
		}

	}
}
