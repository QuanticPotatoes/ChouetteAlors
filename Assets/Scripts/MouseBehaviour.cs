using UnityEngine;
using System.Collections;

public class MouseBehaviour : MonoBehaviour {

    private Collider2D coll;
    private bool isEncounter = false;
    private Vector2 MousePosition;
    Rigidbody2D Rigid;

	// Use this for initialization
	void Start () {
        Rigid = GetComponent<Rigidbody2D>();
        MousePosition = new Vector2(transform.position.x,transform.position.y);
	}
	
	// Update is called once per frame
	void Update () {
        if (isEncounter)
        {
            Rigid.AddForce(new Vector2(PlayerMouseController.Player.transform.position.x * MousePosition.x, PlayerMouseController.Player.transform.position.y / MousePosition.y));
        }
	}

    

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "mouse" && !isEncounter)
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
