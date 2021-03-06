﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BallController : MonoBehaviour {

	//ボールが見える可能性のあるz軸の最大値
	private float visiblePosZ = -6.5f;

	//ゲームオーバを表示するテキスト
	private GameObject gameoverText;

	//スコアを表示するテキスト
	private GameObject scoreText;

	//スコアの初期値
	public int score = 0;

	// Use this for initialization
	void Start () {

		//シーン中のGameOverTextオブジェクトを取得
		this.gameoverText = GameObject.Find("GameOverText");

		//シーン中のScoreTextオブジェクトを取得
		this.scoreText = GameObject.Find("ScoreText");
	}
		
	// Update is called once per frame
	void Update () {

		//ボールが画面外に出た場合
		if (this.transform.position.z < this.visiblePosZ) {
			//GameoverTextにゲームオーバを表示
			this.gameoverText.GetComponent<Text> ().text = "Game Over";
		}
	}

	//衝突時に呼ばれる関数
	void OnCollisionEnter(Collision other) {
		if (other.gameObject.tag == "SmallStarTag") {
			//otherが小さい星だった場合
			score += 30;
		} else if (other.gameObject.tag == "LargeStarTag") {
			//otherが大きい星だった場合
			score += 10;
		} else if (other.gameObject.tag == "SmallCloudTag") {
			//otherが大きい星だった場合
			score += 10;
		} else if (other.gameObject.tag == "LargeCloudTag") {
			//otherが大きい星だった場合
			score += 10;
		}

		//ScoreTextにスコアを表示
		this.scoreText.GetComponent<Text> ().text = score.ToString(); ;

		//スコアの値を表示する
		Debug.Log (score);
	}
}