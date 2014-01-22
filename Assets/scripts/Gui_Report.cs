using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Gui_Report : MonoBehaviour {


	public Cube_Party_Script moverScript;
	public InfectedOrNo mover_Script;
	
	GameObject guest1Object;
	GameObject guest2Object;
	GameObject guest3Object;
	GameObject guest4Object;
	GameObject guest5Object;
	GameObject guest6Object;

	// Use this for initialization
	void Start () {


		guest1Object = GameObject.Find ("Guest_1");
		guest2Object = GameObject.Find ("Guest_2");
		guest3Object = GameObject.Find ("Guest_3");
		guest4Object = GameObject.Find ("Guest_4");
		guest5Object = GameObject.Find ("Guest_5");
		guest6Object = GameObject.Find ("Guest_6");

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI() {

		string readout = string.Format(" {0}\n {1}\n {2}\n {3}\n {4}\n {5}" , InfectedReadout_Guest_1(),InfectedReadout_Guest_2(),InfectedReadout_Guest_3(),InfectedReadout_Guest_4(),InfectedReadout_Guest_5(),InfectedReadout_Guest_6());

		GUI.Label (new Rect (10, (Screen.height - 100), 500, 500), readout);/*,InfectedReadout_Guest_2(),InfectedReadout_Guest_3(),InfectedReadout_Guest_4(),InfectedReadout_Guest_5(),InfectedReadout_Guest_6())*/

		//if(gameObject.name("Guest_6")
	}


	public string InfectedReadout_Guest_1(){
		if (guest1Object.GetComponent<InfectedOrNo> ().infected) {
			return "Guest1 is Infected";
		} else {
			return "";
		}
	}
	public string InfectedReadout_Guest_2(){
		if (guest2Object.GetComponent<InfectedOrNo> ().infected) {
			return "Guest2 is Infected";
		} else {
			return "";
		}
	}
	public string InfectedReadout_Guest_3(){
		if (guest3Object.GetComponent<InfectedOrNo> ().infected) {
			return "Guest3 is Infected";
		} else {
			return "";
		}
	}
	public string InfectedReadout_Guest_4(){
		if (guest4Object.GetComponent<InfectedOrNo> ().infected) {
			return "Guest4 is Infected";
		} else {
			return "";
		}
	}
	public string InfectedReadout_Guest_5(){
		if (guest5Object.GetComponent<Cube_Party_Script> ().infected) {
			return "Guest5 is Infected";
		} else {
			return "";
		}
	}
	public string InfectedReadout_Guest_6(){
		if (guest6Object.GetComponent<Cube_Party_Script> ().infected) {
			return "Guest6 is Infected";
		} else {
			return "";
		}
	}




}
