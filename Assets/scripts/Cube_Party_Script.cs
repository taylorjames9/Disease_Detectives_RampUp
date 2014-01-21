using UnityEngine;
using System.Collections;

public class Cube_Party_Script : MonoBehaviour {


	enum MyState {ChattingContent, ImBored};


	public GameObject[] NPCArray = {}; 
	GameObject target;
	MyState myState;
	float boredTimer;
	bool moving = true;
	private float startTime;
	private float journeyLength;
	public float speed = 0.001F;
	bool needTarget = true;




	// Use this for initialization
	void Start () {

		myState = MyState.ChattingContent;

		//print (Time.time);
		boredTimer = Time.time + Random.Range (3, 5);
		//print (boredTimer);
		startTime = Time.time;
		//journeyLength = Vector3.Distance(startMarker.position, endMarker.position);

	}
	
	// Update is called once per frame
	void Update () {
		//print (Time.time);

	
		switch (myState) {

		case MyState.ChattingContent:
			print ("ChattingContent");

			if (boredTimer < Time.time) {
				boredTimer = Time.time + Random.Range (3, 10);
				target = NPCArray [(Random.Range (0, 4))];
				print (boredTimer);
				myState = MyState.ImBored;
				needTarget = true;

			}

			break;

		case MyState.ImBored:
			print ("I'm bored");
			if (needTarget) {
				target = NPCArray [(Random.Range (0, 4))];
				needTarget = false;
			}

			transform.LookAt (target.transform);

			if (Vector3.Distance (transform.position, target.transform.position) > 2) {
				transform.position = Vector3.Lerp (transform.position, target.transform.position, 0.01f);
				//moving = true;
				//transform.Translate (Vector3.forward * (Time.deltaTime * 2));

			}
			//}
			else if (Vector3.Distance (transform.position, target.transform.position) <= 2) {
				myState = MyState.ChattingContent;
			}
			/*moving = false;


			//SwitchGroup ();
			if (!moving) {
				myState = MyState.ChattingContent;
			}*/
			break;

		default:
			print ("Did not hit a state somehow");
			break;

		}
	}
}
	/*void SwitchGroup(){
		if (Vector3.Distance (transform.position, target.transform.position) > 4) {
			transform.position = Vector3.Lerp(transform.position, target.transform.position, fracJourney);
			moving = true;
			//print (fracJourney);
		} else {
			moving = false;
		}

		//transform.position = Vector3.Lerp (transform.position, target.transform.position, 0.9f);

		
		//moving = false;

	}*/

