using UnityEngine;
using System.Collections;

public class Ammo : MonoBehaviour {

	float rotSpeed;

	void Start ()
	{
		rotSpeed = Random.Range (20f, 40f);
	}

	void Update () 
	{
		transform.Rotate(transform.up * rotSpeed * Time.deltaTime);
	}
}
