using UnityEngine;
using System.Collections;

public class DestroyTimer : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
		Invoke ("Destroy", 4f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Destroy()
	{
		Destroy(gameObject);
	}
}
