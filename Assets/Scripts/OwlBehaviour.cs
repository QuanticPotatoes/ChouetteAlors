using UnityEngine;
using System.Collections;

public class OwlBehaviour : MonoBehaviour {

    public Transform Player;
    bool attacking = false;
    public float startTime;
    public float elapsedTime;
    float x;
    float startx;
    int killNumber;

	void Start () {
        startx = -20f;
        killNumber = 0;
	}
	
	void Update () {
	    if(PlayerControl.isInLight == true)
        {
            transform.position = new Vector3(Player.position.x, transform.position.y, 0f);

            StartCoroutine("Attack");
        }

        if (attacking == true)
        {

            x = - (Time.time - startTime) * 20f;
            transform.position = new Vector2(PlayerMouseController.Player.transform.position.x +  x - startx ,0.05f*((x - startx) * (x - startx)) - 1f);

            if (x < -50f)
            {
                x = 0;
                
                attacking = false;
            }
            {

            }
        }
        else
        {
            startTime = Time.time;
        }
    }

    void OnCollisionEnter2D (Collision2D coll)
    {
        if(coll.gameObject.tag == "mouse")
        {
            killNumber++;

            if(killNumber == 3)
            {
                gameObject.tag = "Untagged";
                StartCoroutine("NameOwl");
            }
        }

        if (coll.gameObject.tag == "hide")
        {
            gameObject.tag = "Untagged";
            StartCoroutine("NameOwl");
        }
    }

    IEnumerator Attack()
    {
        yield return new WaitForSeconds(1f);
        attacking = true;
    }

    IEnumerator NameOwl()
    {
        yield return new WaitForSeconds(2f);
        gameObject.tag = "owl";
        killNumber = 0;
    }
}
