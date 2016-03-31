using UnityEngine;
using System.Collections;

public class Bullet : Token {

	public static TokenMgr<Bullet> parent = null;

	public static Bullet Add(float x,float y,float direction,float speed){
		return parent.Add (x,y,direction,speed);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(IsOutside()){
			Vanish ();
		}
	}
}
