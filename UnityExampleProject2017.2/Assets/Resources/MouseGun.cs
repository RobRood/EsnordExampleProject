using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseGun : MonoBehaviour {
	//references
	public Deadman deadman;
	public GameObject burst;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
			RayGun ();
        }


    }




	void RayGun(){
		RaycastHit Hit;
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		if (Physics.Raycast(ray, out Hit, 200f)){
			//stuff
			deadman = Hit.collider.GetComponentInParent<Deadman>();
			if (deadman != null) {
				deadman.dead ();
				//resets deadman
				deadman = null;
			}
			//add impact to deadman
			//Instantiate (Resources.Load("KaBoom"),Hit.transform.position,Hit.transform.rotation);

			//add smoke
			if (Hit.rigidbody != null) {
				GameObject smokeClone =Instantiate (burst, Hit.point, Quaternion.Euler(Hit.normal));
				Destroy (smokeClone,2f);
				//Hit.collider.GetComponent<Rigidbody> ().AddForceAtPosition (Hit.point *5f, Hit.point);
			}
		}
	}
			


}
