using System;
using System.Collections.Generic;
using UnityEngine;

class Lazer : MonoBehaviour
{
    public void Update()
    {
        float speed = 40.0f;
        float width = 500;
        float height = 500;

        

        transform.position += transform.forward * speed * Time.deltaTime;
       // Debug.DrawLine(transform.position, transform.position + transform.forward * 10.0f, Color.red);
    }

	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "BotTag")
		{
			Destroy(gameObject);
			other.GetComponent<Inventory>().healthAmt --;
		}
	}
}
