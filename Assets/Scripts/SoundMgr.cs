using UnityEngine;
using System.Collections;

public class SoundMgr : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Sound.LoadBgm ("bgm","bgm01");
		Sound.LoadSe ("damage","damage");
		Sound.LoadSe ("destroy","destroy");
	}
}
