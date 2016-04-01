using UnityEngine;
using System.Collections;

public class Boss : Enemy {

	bool _bStart=false;

	void Start(){
		SetParam (0);
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
