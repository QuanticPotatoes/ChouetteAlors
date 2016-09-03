using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {

    public Transform Player;

	void Start () {
	    
	}
	
	void Update () {
        transform.position = new Vector3(Player.position.x, transform.position.y, -10f);
    }
}
