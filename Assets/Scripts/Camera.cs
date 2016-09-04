using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {

    public Transform Player;
    Vector3 block;

	void Start () {
	    
	}
	
	void Update () {
        if (Player.position.x > -144 && Player.position.x < 144)
        {
            transform.position = new Vector3(Player.position.x, transform.position.y, -10f);
        }
    }
}
