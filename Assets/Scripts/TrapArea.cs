using UnityEngine;
using System.Collections;

public class TrapArea : MonoBehaviour {

    public static int numberTrapReady;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.tag == "Trap")
        {
            numberTrapReady--;
            Debug.Log(numberTrapReady);
        }
    }
}
