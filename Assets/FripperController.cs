using UnityEngine;
using System.Collections;

public class FripperController : MonoBehaviour {
	// HingeJointコンポーネントを入れる
	private HingeJoint myHingeJoint;

	// 初期の傾き
	private float defaultAngle = 20;
	// 弾いた時の傾き
	private float flickAngle = -20;

	// Use this for initialization
	void Start () {
		// HingeJointコンポーネント取得
		this.myHingeJoint = GetComponent<HingeJoint>();

		// フリッパーの傾きを設定
		SetAngle(this.defaultAngle);
	}

	// Update is called once per frame
	void Update () {
		// タッチされているかチェック
		if (Input.touchCount > 0) {

			// タッチ情報の取得
			foreach (Touch touch in Input.touches) {

				// タッチされた位置情報を取得
				Vector2 newVec = new Vector2 (touch.position.x, touch.position.y);

				// 画面左をタッチした時左フリッパーを動かす
				if (touch.phase == TouchPhase.Began && newVec.x <= 375 && tag == "LeftFripperTag") {
					SetAngle (this.flickAngle);
				}
				// 画面右をタッチした時右フリッパーを動かす
				else if (touch.phase == TouchPhase.Began && newVec.x >= 375 && tag == "RightFripperTag") {
					SetAngle (this.flickAngle);
				}
				// 画面左タッチが離された時フリッパーを元に戻す
				else if (touch.phase == TouchPhase.Ended && newVec.x <= 375 && tag == "LeftFripperTag") {
					SetAngle (this.defaultAngle);
				}
				// 画面右タッチが離された時フリッパーを元に戻す
				else if (touch.phase == TouchPhase.Ended && newVec.x >= 375 && tag == "RightFripperTag") {
					SetAngle (this.defaultAngle);
				}
			}		
		// 矢印キー操作
		} else {
			// 左矢印キーを押した時左フリッパーを動かす
			if (Input.GetKeyDown (KeyCode.LeftArrow) && tag == "LeftFripperTag") {
				SetAngle (this.flickAngle);
			}
			// 右矢印キーを押した時右フリッパーを動かす
			if (Input.GetKeyDown (KeyCode.RightArrow) && tag == "RightFripperTag") {
				SetAngle (this.flickAngle);
			}

			// 矢印キー離された時フリッパーを元に戻す
			if (Input.GetKeyUp (KeyCode.LeftArrow) && tag == "LeftFripperTag") {
				SetAngle (this.defaultAngle);
			}
			if (Input.GetKeyUp (KeyCode.RightArrow) && tag == "RightFripperTag") {
				SetAngle (this.defaultAngle);
			}
		}
	}

	// フリッパーの傾きを設定
	public void SetAngle (float angle){
		JointSpring jointSpr = this.myHingeJoint.spring;
		jointSpr.targetPosition = angle;
		this.myHingeJoint.spring = jointSpr;
	}
}
