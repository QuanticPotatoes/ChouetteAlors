﻿using UnityEngine;
using System.Collections;

public class OwlBehaviour : MonoBehaviour {

    public Transform Player;
    bool attacking = false;
    bool goUp = false;

	void Start () {
	    
	}
	
	void Update () {
	    if(PlayerControl.isInLight == true)
        {
            transform.position = new Vector3(Player.position.x, transform.position.y, 0f);

            StartCoroutine("Attack");
        }

        if (attacking == true)
        {
            transform.Translate(new Vector3(0f, -0.3f, 0f));
        }

        if (goUp == true)
        {
            transform.Translate(new Vector3(0f, 0.1f, 0f));
        }
    }

    void OnCollisionEnter2D (Collision2D coll)
    {
        if(coll.gameObject.tag == "mouse")
        {
            attacking = false;
            goUp = true;
        }

        if (coll.gameObject.tag == "ground")
        {
            attacking = false;
            goUp = true;
        }

        if (coll.gameObject.tag == "stop")
        {
            goUp = false;
        }
    }

    IEnumerator Attack()
    {
        yield return new WaitForSeconds(1f);
        attacking = true;
    }
}
