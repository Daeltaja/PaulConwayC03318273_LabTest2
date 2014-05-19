using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class GetAmmoState:State
{
	GameObject myGameObject, ammoTarget;
	bool foundNearestAmmo = false;
	float distanceCheck = 0f;
	Vector3 newTar = Vector3.zero;
	GameManager gm;

    public override string Description()
    {
		return "Finding Ammo!";
    }

	public GetAmmoState(GameObject myGameObject):base(myGameObject)
    {
		this.myGameObject = myGameObject;
    }

    public override void Enter()
    {
        myGameObject.GetComponent<SteeringBehaviours>().TurnOffAll();
		myGameObject.GetComponent<SteeringBehaviours>().SeekEnabled = true;
		gm = GameObject.Find ("GameManager").GetComponent<GameManager>();
    }

    public override void Update()
    {
		if(!foundNearestAmmo)
		{
			foreach(GameObject go in gm.ammos)
			{
				float toOther = (go.transform.position - myGameObject.transform.position).magnitude;
			}
			for(int i = 0; i < gm.ammos.Count; i++)
			{
				if(Vector3.Distance(gm.ammos[i].transform.position, myGameObject.transform.position) < distanceCheck)
				{
					newTar = gm.ammos[i].transform.position;
					//distanceCheck = 
					//ammoTarget = gm.ammos[i].transform.position;
				}
			}
			ammoTarget = GameObject.Find ("Ammo");
			myGameObject.GetComponent<SteeringBehaviours>().seekPos = ammoTarget.transform.position;
			foundNearestAmmo = true;
		}
		if((ammoTarget.transform.position - myGameObject.transform.position).magnitude < 1f)
		{
			myGameObject.GetComponent<Inventory>().ammoAmt += 10;
			gm.ammos.Remove(ammoTarget);
			MonoBehaviour.Destroy(ammoTarget);
			myGameObject.GetComponent<StateMachine>().SwitchState(new IdleState(myGameObject, myGameObject));
		}
    }

    public override void Exit()
    {
        myGameObject.GetComponent<SteeringBehaviours>().TurnOffAll();            
    }
}
