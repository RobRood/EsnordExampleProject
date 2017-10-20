using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NativeRagdoll : MonoBehaviour {
	/* note: need Character joints on all bones with
	 * isKinematic set to true and projection enabled, 
	 * else mesh stretching will occure*/ 
	


	public void dead(){
		GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
		GetComponent<Animator>().enabled = false;
		GetComponent<RandomWalker>().enabled = false;

		Rigidbody[] bones = GetComponentsInChildren<Rigidbody> ();
		//give physics control of bones
		for (int i = 0; i < bones.Length; i++) {
			bones[i].isKinematic = false;
		}

	}

	public void zombie(){
		GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = true;
		GetComponent<Animator>().enabled = true;
		GetComponent<RandomWalker>().enabled = true;

		Rigidbody[] bones = GetComponentsInChildren<Rigidbody> ();
		//give physics control of bones
		for (int i = 0; i < bones.Length; i++) {
			bones[i].isKinematic = true;
		}

	}


}
