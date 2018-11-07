using UnityEngine;
using System.Collections;

public class FripperController : MonoBehaviour {

	//HingiJointコンポーネントを入れる
	private HingeJoint myHingeJoint;

	//初期の傾き
	private float defaultAngle = 20;

	//弾いた時の傾き
	private float flickAngle = -20;

	// Use this for initialization
	void Start () {

		//HingiJointコンポーネントを取得
		this.myHingeJoint = GetComponent<HingeJoint>();

		//フリッパーの傾きを設定
		SetAngle(this.defaultAngle);

	}

	// Update is called once per frame
	void Update (){

		//左矢印キーを押した時左フリッパーを動かす
		if (Input.GetKeyDown (KeyCode.LeftArrow) && tag == "LeftFripperTag") {
			SetAngle (this.flickAngle);
		}

		//右矢印キーを押した時右フリッパーを動かす
		if (Input.GetKeyDown (KeyCode.RightArrow) && tag == "RightFripperTag") {
			SetAngle (this.flickAngle);
		}

		//左矢印キーが離された時に左フリッパーを元に戻す
		if (Input.GetKeyUp (KeyCode.LeftArrow) && tag == "LeftFripperTag") {
			SetAngle (this.defaultAngle);
		}
		//右矢印キーが離された時に右フリッパーを元に戻す
		if (Input.GetKeyUp (KeyCode.RightArrow) && tag == "RightFripperTag") {
			SetAngle (this.defaultAngle);
		}

		foreach (Touch t in Input.touches){
			
			var pos = t.position;

			switch(t.phase){

			case TouchPhase.Began:
				if (pos.x < Screen.width * 0.5f && tag == "LeftFripperTag") {
					
					SetAngle (this.flickAngle);

				} else if (pos.x > Screen.width * 0.5f && tag == "RightFripperTag") {
					
					SetAngle (this.flickAngle);

				}
			break;

			case TouchPhase.Ended:
			case TouchPhase.Canceled:
				if (pos.x < Screen.width * 0.5f && tag == "LeftFripperTag") {
					
					SetAngle (this.defaultAngle);

				} else if (pos.x > Screen.width * 0.5f && tag == "RightFripperTag") {
					
					SetAngle (this.defaultAngle);

				}
			break;
			}
		}
	}
			
	//フリッパーの傾きを設定
	public void SetAngle (float angle){
		JointSpring jointSpr = this.myHingeJoint.spring;
		jointSpr.targetPosition = angle;
		this.myHingeJoint.spring = jointSpr;
	}
}

