using UnityEngine;
using System.Collections;

public class TitleMgr : MonoBehaviour {

	bool _bDrawPressStart=false;

	IEnumerator Start(){
		while(true){
			_bDrawPressStart = !_bDrawPressStart;
			yield return new WaitForSeconds (0.6f);
		}
	}

	void Update(){
		if(Input.GetKeyDown(KeyCode.Space)){
			Application.LoadLevel("Main");
		}
	}

	void OnGUI(){
		if(_bDrawPressStart){
			Util.SetFontSize (32);
			Util.SetFontAlignment (TextAnchor.MiddleCenter);

			float w = 128;
			float h = 32;
			float px = Screen.width / 2 - w / 2;
			float py = Screen.height / 2 - h / 2;

			py += 65;
			Util.GUILabel (px,py,w,h,"スペースキーでゲーム開始");
		}
	}
}
