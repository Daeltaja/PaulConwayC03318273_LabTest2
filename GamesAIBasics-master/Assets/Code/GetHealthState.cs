using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class GetHealthState:State
{
	GameObject myGameObject, healthTarget;
	bool foundNearestHealth = false;
	float distanceCheck = 0f;
	Vector3 newTar = Vector3.zero;
	GameManager gm;

    public override string Description()
    {
		return "Finding Health!";
    }

	public GetHealthState(GameObject myGameObject):base(myGameObject)
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
		if(GameObject.Find ("Health")!=null)
		{
			if(!foundNearestHealth)
			{
				healthTarget = GameObject.Find ("Health");
				myGameObject.GetComponent<SteeringBehaviours>().seekPos = healthTarget.transform.position;
				foundNearestHealth = true;
			}
			if((healthTarget.transform.position - myGameObject.transform.position).magnitude < 1f)
			{
				myGameObject.GetComponent<Inventory>().healthAmt += 10;
				gm.healths.Remove(healthTarget);
				MonoBehaviour.Destroy(healthTarget);
				myGameObject.GetComponent<StateMachine>().SwitchState(new IdleState(myGameObject, myGameObject));
			}
		}
		else
		{
			myGameObject.GetComponent<StateMachine>().SwitchState(new IdleState(myGameObject, myGameObject));
		}

    }

    public override void Exit()
    {
        myGameObject.GetComponent<SteeringBehaviours>().TurnOffAll();            
    }
}
