using UnityEngine;
using System.Collections;

public class Enemy : Token {

	public Sprite Spr0;
	public Sprite Spr1;
	public Sprite Spr2;
	public Sprite Spr3;
	public Sprite Spr4;
	public Sprite Spr5;

	public static Player target = null;
	public static TokenMgr<Enemy> parent = null;

	int _hp=0;
	int _id=0;

	public void SetParam(int id){
		if (_id != 0){
			StopCoroutine ("_Update"+_id);
		}
		if (id != 0) {
			StartCoroutine ("_Update"+id);
		}
		_id = id;
		int[] hps = {100,30,30,30,30,30};
		Sprite[] sprs = { Spr0,Spr1,Spr2,Spr3,Spr4,Spr5 };
		_hp=hps[id];
		SetSprite (sprs[id]);
		Scale=0.5f;
	}

	public static Enemy Add(int id,float x,float y,float direction,float speed){
		//return parent.Add (x,y,direction,speed);
		Enemy e=parent.Add (x,y,direction,speed);
		if(e==null){
			return null;
		}
		e.SetParam (id);
		return e;
	}

	public float GetAim(){
		float dx = target.X - X;
		float dy = target.Y - Y;
		return Mathf.Atan2 (dy, dx) * Mathf.Rad2Deg;
	}

	public int Hp{
		get{
			return _hp;
		}
	}

	bool Damage(int v){
		_hp -= v;
		if(_hp<=0){
			Vanish ();
			for(int i=0;i<4;i++){
				Particle.Add (X,Y);
			}
			Sound.PlaySe ("destroy",0);
			if(_id==0){
				Enemy.parent.ForEachExist (e=>e.Damage(9999));
				if(Bullet.parent!=null){
					Bullet.parent.Vanish ();
				}
			}
			return true;
		}
		return false;
	}

	/*void Start(){
		_hp = 30;
		_id = 3;
		StartCoroutine ("_Update"+_id);
	}*/

	void DoBullet(float direction,float speed){
		Bullet.Add (X,Y,direction,speed);
	}

	void Update(){
		if(_id==4){
			Vector2 min = GetWorldMin ();
			Vector2 max = GetWorldMax ();
			if(Y<min.y || max.y<Y){
				ClampScreen ();
				VY *= -1;
			}
			if(X<min.x || max.x<X){
				Vanish ();
			}
			Angle = Direction;
		}
	}

	void FixedUpdate(){
		if(_id<=3){
			MulVelocity (0.93f);
		}
	}

	IEnumerator _Update1(){
		while(true){
			yield return new WaitForSeconds (2.0f);
			float dir = GetAim ();
			Bullet.Add (X,Y,dir,3);
		}
	}
	IEnumerator _Update2(){
		yield return new WaitForSeconds (2.0f);
		float dir = 0;
		while(true){
			Bullet.Add (X,Y,dir,2);
			dir += 16;
			yield return new WaitForSeconds (0.1f);
		}
	}
	IEnumerator _Update3(){
		while(true){
			yield return new WaitForSeconds (2.0f);
			DoBullet (180-2,2);
			DoBullet (180,2);
			DoBullet (180+2,2);
		}
	}
	IEnumerator _Update4(){
		yield return new WaitForSeconds (1.0f);
	}
	IEnumerator _Update5(){
		const float ROT = 5.0f;
		while(true){
			yield return new WaitForSeconds (0.02f);
			float dir = Direction;
			float aim = GetAim ();
			float delta = Mathf.DeltaAngle (dir, aim);
			if (Mathf.Abs (delta) < ROT) {

			} else if (delta > 0) {
				dir += ROT;
			} else {
				dir -= ROT;
			}
			SetVelocity (dir,Speed);
			Angle = dir;
			if(IsOutside()){
				Vanish ();
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		string name = LayerMask.LayerToName (other.gameObject.layer);

		if(name=="Shot"){
			Shot s = other.GetComponent<Shot> ();
			s.Vanish ();
			Damage (1);
		}
	}

}
