using UnityEngine;
using System.Collections;

public class OwlBehaviour : MonoBehaviour {

    public Transform Player;
    bool attacking = false;
    bool goUp = false;
    public float startTime;
    public float elapsedTime;
    float x;
    float startx;

	void Start () {
        startx = -20f;
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
