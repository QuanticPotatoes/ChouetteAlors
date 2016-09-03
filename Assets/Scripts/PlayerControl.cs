using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

    public float speed;

	void Start () {
	    
	}
	
	void Update () {
	    if(Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(new Vector3(speed, 0, 0));
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(new Vector3(-speed, 0, 0));
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.Translate(new Vector3(0, 0.3f, 0));
        }
    }
}
