using UnityEngine;
using System.Collections;

public class CloudController : MonoBehaviour {

	//最小サイズ
	private float minimum = 1.0f;
	//拡大縮小スピード
	private float magSpeed = 10.0f;
	//拡大率
	private float magnification = 0.07f;

	//最小サイズ（サイズ変更）
	//private float minimum = 2.0f;
	//拡大縮小スピード（スピード変更）
	//private float magSpeed = 20.0f;
	//拡大率（拡大率変更）
	//private float magnification = 0.20f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//雲を拡大縮小
		this.transform.localScale = new Vector3(this.minimum + Mathf.Sin(Time.time * this.magSpeed) * this.magnification, this.transform.localScale.y, this.minimum + Mathf.Sin(Time.time * this.magSpeed) * this.magnification);
		
	}
}
