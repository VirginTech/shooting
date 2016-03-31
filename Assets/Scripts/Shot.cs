using UnityEngine;
using System.Collections;

public class Shot : Token {

	public static TokenMgr<Shot> parent = null;

	public static Shot Add(float x,float y,float direction,float speed){
		return parent.Add (x,y,direction,speed);
	}

	public override void Vanish(){
		Particle p = Particle.Add (X,Y);
		if(p!=null){
			p.SetColor (0.1f,0.1f,1);
			p.MulVelocity (0.7f);
		}
		base.Vanish ();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(IsOutside()){
			//DestroyObj ();
			Vanish();
		}
	}
}
