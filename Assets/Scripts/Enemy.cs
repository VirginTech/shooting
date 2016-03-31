using UnityEngine;
using System.Collections;

public class Enemy : Token {

	void OnTriggerEnter2D(Collider2D other){
		string name = LayerMask.LayerToName (other.gameObject.layer);

		if(name=="Shot"){
			Shot s = other.GetComponent<Shot> ();
			s.Vanish ();
		}
	}

}
