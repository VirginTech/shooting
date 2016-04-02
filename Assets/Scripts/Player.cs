using UnityEngine;
using System.Collections;

public class Player : Token {

	public Sprite Spr0;
	public Sprite Spr1;

	public float MoveSpeed = 5.0f;

	int _tAnim = 0;

	void Start(){
		var w = SpriteWidth / 2;
		var h = SpriteHeight / 2;
		SetSize (w,h);
	}

	void Update(){
		Vector2 v = Util.GetInputVector ();
		float speed = MoveSpeed * Time.deltaTime;
		ClampScreenAndMove (v * speed);
		if(Input.GetKey(KeyCode.Space)){
			float px = X + Random.Range (0,SpriteWidth/2);
			float dir = Random.Range (-3.0f,3.0f);
			Shot.Add (px,Y,dir,10);
		}
	}

	void FixedUpdate(){
		_tAnim++;
		if (_tAnim % 48 < 24) {
			SetSprite (Spr0);
		} else {
			SetSprite (Spr1);
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		string name = LayerMask.LayerToName (other.gameObject.layer);
		switch (name) {
		case "Enemy":
		case "Bullet":
			Vanish ();
			for (int i = 0; i < 8; i++) {
				Particle.Add (X, Y);
			}
			Sound.PlaySe ("damage");
			Sound.StopBgm ();
			break;
		}
	}

}
