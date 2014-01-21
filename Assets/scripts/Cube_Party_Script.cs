using UnityEngine;
using System.Collections;

public class Cube_Party_Script : MonoBehaviour {


	enum MyState {ChattingContent, ImBored, ConvoW_Infected};


	public GameObject[] NPCArray = {}; 
	public GameObject target;
	MyState myState;
	float boredTimer;
	bool needTarget = true;
	public bool infected;
	public int susceptibility;
	public Cube_Party_Script targetScript;
	public bool imaMover;

	// Use this for initialization
	void Start () {
		//print (gameObject.name);
		if (this.gameObject.name == "Guest_4" || this.gameObject.name == "Guest_6") {
			imaMover = true;
			//print ("I've been promoted to a mover.");
		}

		myState = MyState.ChattingContent;
		boredTimer = Time.time + Random.Range (3, 5);
		infected = RandomBoolean ();
		susceptibility = Random.Range (0, 6);
		if (infected) {
			transform.renderer.material.color = Color.red; 
			print ("I'm infected");
		}
	}
	
	// Update is called once per frame
	void Update () {
		switch (myState) {
		case MyState.ChattingContent:
			if (imaMover) {
				GettingBored ();
				GettingInfected ();
			} else {
				//Dude_cameUpNow_ImInfected ();
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

			transform.LookAt (target.transform);

			if (Vector3.Distance (transform.position, target.transform.position) > 2) {
				transform.position = Vector3.Lerp (transform.position, target.transform.position, 0.01f);
			} else if (Vector3.Distance (transform.position, target.transform.position) <= 2) {
				myState = MyState.ChattingContent;
			}
	}

	bool RandomBoolean(){
		return (Random.value > 0.5f);
	}

	void GettingBored(){
		if (boredTimer <= Time.time) {
			boredTimer = Time.time + Random.Range (3, 10);
			myState = MyState.ImBored;
			needTarget = true;
		}
		if (needTarget) {
			target = NPCArray [(Random.Range (0, 4))];
			needTarget = false;
		}
	}

	void GettingInfected(){

		if (!infected){
		targetScript = target.GetComponent<Cube_Party_Script>();
			if (targetScript.infected && susceptibility > 0) {
				infected = true;
				print ("I got infected");
				transform.renderer.material.color = Color.red; 
			}
		}
	}
	
				/*void Dude_cameUpNow_ImInfected{
					if(Vector3.Distance(gameObject("Guest_4")<2.1 && gameObject("Guest_4"). ){

					}
	
	}*/



}
