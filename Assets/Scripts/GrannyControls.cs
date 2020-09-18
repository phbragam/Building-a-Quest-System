using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrannyControls : MonoBehaviour {

    Animator anim;
    float speed = 0.1f;
    public AudioSource dying;
    public AudioSource winSound;
    public AudioSource runSound;
    public AudioSource puffSound;

    // Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void LateUpdate () {
        //keyboard controls
        if (Input.GetKey("space"))
        {
            anim.SetTrigger("jump");
        }
        else if (Input.GetKey("left"))
        {
            this.transform.Rotate(Vector3.up, -3);
        }
        else if (Input.GetKey("right"))
        {
            this.transform.Rotate(Vector3.up, 3);
        }

        if (Input.GetKey("up"))
        {

            if (runSound && !runSound.isPlaying) runSound.Play();
            if (puffSound && !puffSound.isPlaying) puffSound.Play();
            anim.SetBool("running", true);
            this.transform.position += this.transform.forward * speed;
        }
        else if (Input.GetKey("down"))
        {
            if (runSound && !runSound.isPlaying) runSound.Play();
            if (puffSound && !puffSound.isPlaying) puffSound.Play();
            anim.SetBool("running", true);
            this.transform.position -= this.transform.forward * speed;
        }
        else if (Input.GetKeyUp("up") || Input.GetKeyUp("down"))
        {
            if (runSound) runSound.Stop();
            if (puffSound) puffSound.Stop();
            anim.SetBool("running", false);
        }
	}
}
