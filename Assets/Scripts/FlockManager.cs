using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockManager : MonoBehaviour {

	public GameObject Prefab;
	public int numObjs = 20;
	public GameObject[] allObjs;

	[Header("Settings")]
	[Range(0.0f, 5.0f)]
	public float minSpeed;
	[Range(0.0f, 5.0f)]
	public float maxSpeed;
	[Range(0.0f, 5.0f)]
	public float rotationSpeed;

	// Use this for initialization
	void Start () {
		allObjs = new GameObject[numObjs];
        for(int i = 0; i < numObjs; i++)
		{
			Vector3 pos = this.transform.position + new Vector3(Random.Range(-100,100),
				                      							0,
				                      							Random.Range(-100,100));
            allObjs[i] = (GameObject) Instantiate(Prefab, pos, Quaternion.identity);
            allObjs[i].GetComponent<Flock>().myManager = this;
            allObjs[i].GetComponent<Flock>().speed = Random.Range(minSpeed, maxSpeed);
            allObjs[i].GetComponent<Flock>().rotSpeed = rotationSpeed;
		}
	}
	
}
