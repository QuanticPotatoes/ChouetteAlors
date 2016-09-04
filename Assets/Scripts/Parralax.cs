using UnityEngine;
using System.Collections;

public class Parralax : MonoBehaviour {

    // Use this for initialization
    
    
    public float ParralaxDisplacement;
    public int Zindex;
    public Transform Camera;
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        transform.position = new Vector3(ParralaxDisplacement * Camera.position.x, transform.position.y,Zindex);

	}
}
