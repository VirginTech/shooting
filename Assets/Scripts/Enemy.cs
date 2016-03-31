using UnityEngine;
using System.Collections;

public class Enemy : Token {

	void Start(){
		StartCoroutine ("_Update1");
	}

	IEnumerator _Update1(){
		while(true){
			yield return new WaitForSeconds (2.0f);
			Bullet.Add (X,Y,180,3);
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		string name = LayerMask.LayerToName (other.gameObject.layer);

		if(name=="Shot"){
			Shot s = other.GetComponent<Shot> ();
			s.Vanish ();
		}
	}

}
