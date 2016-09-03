﻿using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

    public static bool isInLight;

    public float speed;
    Rigidbody2D Rigid;
    bool jump = false;

	void Start () {
        Rigid = GetComponent<Rigidbody2D>();
	}
	
	void Update () {
	    if(Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(new Vector3(speed, 0f, 0f));
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(new Vector3(-speed, 0f, 0f));
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if(jump == true) Rigid.AddForce(new Vector2(0f, 25000f));
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "ground")
        {
            jump = true;
        }
    }

    void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "ground")
        {
            jump = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "light")
        {

        }
    }

    /*IEnumerator EnableGravity()
    {
        yield return new WaitForSeconds(0.3f);
    }*/
}
