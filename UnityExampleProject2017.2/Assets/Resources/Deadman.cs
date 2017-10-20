using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deadman : MonoBehaviour {
	NativeRagdoll doll;

	// Use this for initialization
	void Start () {
		doll = GetComponent<NativeRagdoll> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void dead() {
		if (doll == null) {
			Destroy (this.gameObject);
			Instantiate (Resources.Load ("DeadStickman"), transform.position, transform.rotation);
		} else {
			doll.dead ();
		}
	}

}
