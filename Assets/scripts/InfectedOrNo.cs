using UnityEngine;
using System.Collections;

public class InfectedOrNo : MonoBehaviour {

	public bool infected;
	public int susceptibility;
	public Cube_Party_Script dudeScript; 
	GameObject dude1; 
	GameObject dude2;
	public float susceptibilityRemix;

	// Use this for initialization
	void Start () {
	
		dude1 = GameObject.Find("Guest_5"); 
		dude2 = GameObject.Find("Guest_6"); 
		susceptibilityRemix = Time.time + 3;
		infected = RandomBoolean ();
		if (infected) {
			transform.renderer.material.color = Color.red; 
			print ("Reporting: "+ gameObject.name + " .. I started off infected");
		}

	}
	
	// Update is called once per frame
	void Update () {

		if (!infected) {
			Susceptibility ();
			if (susceptibility >= 5) {
				DudeCameUpOnMeAtAparty ();
			}

		}
	}

	bool RandomBoolean(){
		return (Random.value > 0.7f);
	}

	void DudeCameUpOnMeAtAparty(){

			if((Vector3.Distance(transform.position, dude1.transform.position)<2.1) && dude1.GetComponent<Cube_Party_Script>().infected){
					infected = true;
					transform.renderer.material.color = Color.red; 
					print ("Reporting: " + gameObject.name + "... Dagg y'all I gots infected by Guest_4");
				}

			else if((Vector3.Distance(transform.position, dude2.transform.position)<2.1) && dude2.GetComponent<Cube_Party_Script>().infected){
					infected = true;
					transform.renderer.material.color = Color.red; 
					print ("Reporting: " + gameObject.name + "... Dagg y'all I gots infected by Guest_6");
				}
	}
	void Susceptibility (){
		if (susceptibilityRemix <= Time.time) {
			susceptibility = Random.Range (0, 6);
			susceptibilityRemix = Time.time + 3;

		}
	}
}
