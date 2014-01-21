using UnityEngine;
using System.Collections;

public class Cube_Party_Script : MonoBehaviour {


	enum MyState {ChattingContent, ImBored};


	public GameObject[] NPCArray = {}; 
	GameObject target;
	MyState myState;
	float boredTimer;
	//bool moving = true;
	bool needTarget = true;




	// Use this for initialization
	void Start () {

		myState = MyState.ChattingContent;
		boredTimer = Time.time + Random.Range (3, 5);

	}
	
	// Update is called once per frame
	void Update () {
		switch (myState) {
		case MyState.ChattingContent:
			if (boredTimer <= Time.time) {
				boredTimer = Time.time + Random.Range (3, 10);
				myState = MyState.ImBored;
				needTarget = true;
			}
			break;

		case MyState.ImBored:
			SwitchGroup ();
			break;

		default:
			break;
		}
	}

	void SwitchGroup(){
		if (needTarget) {
			target = NPCArray [(Random.Range (0, 4))];
			needTarget = false;
		}

		transform.LookAt (target.transform);

		if (Vector3.Distance (transform.position, target.transform.position) > 2) {
			transform.position = Vector3.Lerp (transform.position, target.transform.position, 0.01f);
		}
		else if (Vector3.Distance (transform.position, target.transform.position) <= 2) {
			myState = MyState.ChattingContent;
		}

	}
}
