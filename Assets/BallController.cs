using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BallController : MonoBehaviour {

	//変数の宣言
	int score = 0;

	//ボールが見える可能性があるz軸の最大値
	private float visiblePosZ = -6.5f;

	//ゲームオーバーを表示するテキスト
	private GameObject gameoverText;
	private GameObject scoreText;

	// Use this for initialization
	void Start () {

		//シーン中のGameOverTextオブジェクトを取得
		this.gameoverText = GameObject.Find("GameOverText");

		//シーン中のScoreTextオブジェクトを取得
		this.scoreText = GameObject.Find("ScoreText");

	}

	// 可算処理の実行
	void OnCollisionEnter(Collision other) {

		if (other.gameObject.tag == "SmallStarTag") {
			// 加算の処理
			score += 10;
		} else if (other.gameObject.tag == "LargeStarTag") {
			// 加算の処理
			score += 30;
		} else if (other.gameObject.tag == "SmallCloudTag") {
			// 加算の処理
			score += 20;
		} else if (other.gameObject.tag == "LargeCloudTag") {
			// 加算の処理
			score += 50;
		} 

		//ボールが画面内にある場合
		if (this.transform.position.z > this.visiblePosZ) {

			//ScoreTextに得点を表示
			this.scoreText.GetComponent<Text> ().text = "Score:" + score;
		}
	}

	// Update is called once per frame
	void Update () {

		//ボールが画面外に出た場合
		if (this.transform.position.z < this.visiblePosZ) {

			//GameoverTextにゲームオーバーを表示
			this.gameoverText.GetComponent<Text> ().text = "Game Over\r\n\r\nあなたの得点は" + score + "点です";
		}

	}

}