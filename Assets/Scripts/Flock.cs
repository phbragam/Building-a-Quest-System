using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flock : MonoBehaviour {

	public FlockManager myManager;
	public float speed;
    public float rotSpeed;
	Animator anim;
    GameObject player;
    bool dead = false;

	// Use this for initialization
	void Start () {
		anim = this.GetComponent<Animator>();
        player = GameObject.FindWithTag("Player");
        anim.SetBool("chase", true);
	}

	private void OnCollisionEnter(Collision collision)
	{
        if (collision.gameObject.tag == "Player")
        {
            anim.SetBool("dead", true);
            dead = true;
            Destroy(this.GetComponent<Collider>());
            Destroy(this.GetComponent<Rigidbody>());
        }
	}

	// Update is called once per frame
	void Update () {

        if(dead)
        {
            anim.SetBool("dead", true);
            return;
        }
        Vector3 lookAtGoal;
        Vector3 direction;

        lookAtGoal = new Vector3(player.transform.position.x,
                                 player.transform.position.y,
                                 player.transform.position.z);

      

        direction = lookAtGoal - this.transform.position;


        this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
                                                Quaternion.LookRotation(direction),
                                                   rotSpeed * Time.deltaTime);
        this.transform.Translate(0, 0, speed * Time.deltaTime);
	}

}
