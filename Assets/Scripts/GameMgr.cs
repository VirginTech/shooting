using UnityEngine;
using System.Collections;

public class GameMgr : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Shot.parent = new TokenMgr<Shot> ("Shot",32);
		Particle.parent = new TokenMgr<Particle> ("Particle",256);
		Bullet.parent = new TokenMgr<Bullet> ("Bullet",256);
	}
	
}
