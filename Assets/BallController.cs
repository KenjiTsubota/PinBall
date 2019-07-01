using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BallController : MonoBehaviour {

	// ボールが見える可能性のあるz軸の最大値
	private float visiblePosZ = -6.5f;

	// ゲームオーバを表示するテキスト
	private GameObject gameoverText;

	// 得点を表示するテキスト
	private GameObject pointsText;

	// 得点
	private int point = 0;

	// Use this for initialization
	void Start () {
		// シーン中のGameOverTextオブジェクトを取得
		this.gameoverText = GameObject.Find("GameOverText");

		// シーン中のPointsTextオブジェクトを取得
		this.pointsText = GameObject.Find("PointsText");

	}

	// Update is called once per frame
	void Update () {
		// ボールが画面外に出た場合
		if (this.transform.position.z < this.visiblePosZ) {
			// GameoverTextにゲームオーバを表示
			this.gameoverText.GetComponent<Text> ().text = "Game Over";
		}
	}

	// 衝突時に呼ばれる関数
	void OnCollisionEnter(Collision other) {
		// タグによって加算する点数を変える
		if (other.gameObject.tag == "SmallStarTag") {
			this.point += 10;
		} else if (other.gameObject.tag == "LargeStarTag") {
			this.point += 100;
		} else if (other.gameObject.tag == "SmallCloudTag") {
			this.point += 25;
		} else if (other.gameObject.tag == "LargeCloudTag") {
			this.point += 500;
		}

		// PointsTextに得点を表示
		this.pointsText.GetComponent<Text> ().text = this.point.ToString() + " pt";

	}
}