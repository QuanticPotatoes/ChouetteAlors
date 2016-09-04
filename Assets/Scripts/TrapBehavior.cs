using UnityEngine;
using System.Collections;

public class TrapBehavior : MonoBehaviour {

    
    private Collider2D collider;
    private Rigidbody2D rigid;
    public static float mass;
    
	// Use this for initialization
	void Start () {

        collider = GetComponent<Collider2D>();
        collider.enabled = false;
        rigid = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {

        rigid.mass = mass + 10;
        
        if ( PlayerMouseController.MouseNumber > 4)
        {
            collider.enabled = true;
            rigid.isKinematic = false;
            
                 
        }
        else
        {
            collider.enabled = false;
            rigid.isKinematic = true;

        }

    }
}
