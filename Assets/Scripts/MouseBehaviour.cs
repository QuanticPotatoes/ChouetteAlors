using UnityEngine;
using System.Collections;

public class MouseBehaviour : MonoBehaviour {

    private Collider2D coll;
    private bool isEncounter = false;
    private Vector2 MousePosition;
    Rigidbody2D Rigid;
    private float distance;

    float mDroneSpeed = 10.0f;

    float mFarThreshold = 20.0f;
    float mShootThreshold = 10.0f;
    float mCloseThreshold = 5.0f;
    Rigidbody2D rigidbody;

    // Use this for initialization
    void Start () {
        Rigid = GetComponent<Rigidbody2D>();
        MousePosition = new Vector2(transform.position.x,transform.position.y);
        rigidbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (isEncounter)
        {
            Vector2 direction = PlayerMouseController.Player.transform.position - transform.position;
            float magnitude = direction.magnitude;
            direction.Normalize();

            //Calculate crawler's speed
            Vector2 velocity = direction * mDroneSpeed;

           distance = Vector2.Distance(PlayerMouseController.Player.transform.position, transform.position);
           rigidbody.velocity = new Vector2(velocity.x, rigidbody.velocity.y);

        }
    }

    

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player" && !isEncounter)
        {
            PlayerMouseController.MouseNumber++;
            Debug.Log(PlayerMouseController.MouseNumber++);
            isEncounter = true;
        }
    }


    void Desactive() {

        RemoveMouse();

    }


    void RemoveMouse()
    {
        PlayerMouseController.MouseNumber--;
    }

}
