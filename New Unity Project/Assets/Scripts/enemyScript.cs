using UnityEngine;
using System.Collections;

public class enemyScript : MonoBehaviour {
    public Transform pos1;
    public Transform pos2;
    private float rng;
    private float delay = 2.0f;
    public float modifier;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        
        transform.position = Vector3.Lerp(pos1.position, pos2.position, Mathf.PingPong(Time.time * 1,modifier));
	}
}
