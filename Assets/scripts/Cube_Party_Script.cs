using UnityEngine;
using System.Collections;

public class Cube_Party_Script : MonoBehaviour {


	enum MyState {ChattingContent, ImBored};


	public GameObject[] NPCArray = {}; 
	public GameObject target;
	MyState myState;
	float boredTimer;
	bool needTarget = true;
	public bool infected;
	public int susceptibility;
	public InfectedOrNo targetScript;
	//public Gui_Report guiScript;

	// Use this for initialization
	void Start () {

		myState = MyState.ChattingContent;
		boredTimer = Time.time + Random.Range (3, 5);
		infected = RandomBoolean ();
		if (infected) {
			//transform.renderer.material.color = Color.red; 
			print ("Reporting: "+ gameObject.name + " ... I started off infected");
		}
	}
	
	// Update is called once per frame
	void Update () {
		switch (myState) {
		case MyState.ChattingContent:
				GettingBored ();
				GettingInfected ();
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
			susceptibility = Random.Range (0, 6);
			print (gameObject.name + " Susceptibility = " +susceptibility);
			needTarget = true;
		}
		if (needTarget) {
			target = NPCArray [(Random.Range (0, 3))];
			needTarget = false;
		}
	}

	void GettingInfected(){

		if (!infected){
			targetScript = target.GetComponent<InfectedOrNo>();

			if (targetScript.infected && susceptibility >= 4) {
				infected = true;
				print ("Reporting: "+ gameObject.name + " ... I recently became infected");
				//transform.renderer.material.color = Color.red; 
				if (gameObject.name == "Guest_5") {
				
				}
				else if (gameObject.name == "Guest_6") {

				}

			}
		}
	}

}



























