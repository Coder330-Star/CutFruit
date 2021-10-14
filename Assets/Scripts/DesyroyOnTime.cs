using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesyroyOnTime : MonoBehaviour {

    public float desTime = 2f;
	
	void Start () {
        Invoke("Dead", desTime);
	}
	
	
	void Dead () {
        Destroy(gameObject);
	}
}
