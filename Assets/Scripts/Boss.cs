﻿using UnityEngine;
using System.Collections;

public class Boss : Enemy {

	public static bool bDestroyed = false;
	bool _bStart=false;

	void OnGUI(){
		Util.SetFontColor (Color.black);
		Util.SetFontSize (24);
		Util.SetFontAlignment (TextAnchor.MiddleCenter);
		string text = string.Format ("{0,3}",Hp);
		Util.GUILabel (370,190,120,30,text);
	}

	void Start(){
		SetParam (0);
		bDestroyed = false;
	}

	public override void Vanish(){
		bDestroyed = true;
		base.Vanish ();
	}

	void BulletRadish(){
		float aim = GetAim ();
		AddEnemy (4,aim,3);
		AddEnemy (4,aim-30,3);
		AddEnemy (4,aim+30,3);
	}

	void BulletCarrot(){
		AddEnemy (5,45,3);
		AddEnemy (5,-45,3);
	}

	void Update(){
		if(_bStart==false){
			StartCoroutine ("_GenerateEnemy");
			_bStart = true;
		}
	}

	Enemy AddEnemy(int id,float direction,float speed){
		return Enemy.Add (id,X,Y,direction,speed);
	}

	IEnumerator _GenerateEnemy(){
		while(true){
			AddEnemy (1,135,5);
			AddEnemy (1,225,5);
			yield return new WaitForSeconds (3);

			BulletRadish ();
			yield return new WaitForSeconds (2);

			AddEnemy (2,90,5);
			AddEnemy (2,270,5);
			BulletCarrot ();
			yield return new WaitForSeconds (3);

			AddEnemy (3,45,5);
			AddEnemy (3,-45,5);
			yield return new WaitForSeconds (3);

			BulletRadish ();
			yield return new WaitForSeconds (2);

			BulletCarrot ();
		}
	}
}
