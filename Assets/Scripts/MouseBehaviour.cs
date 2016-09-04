using UnityEngine;
using System.Collections;

public class MouseBehaviour : MonoBehaviour {

    private Collider2D coll;
    private bool isEncounter = false;
    private bool isPlay = false;
    private Vector2 MousePosition;
    Rigidbody2D Rigid;
    private float distance;
    private int previousClip;
    AudioSource audiosource;
    public AudioClip[] MouseClip;
    private bool jump = false;

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
        audiosource = GetComponent<AudioSource>();
        StartCoroutine(MouseSound());
        StartCoroutine(MouseJump());

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
           rigidbody.velocity = new Vector2(velocity.x * ( Mathf.Pow(distance/10,3) - 2f * distance/10 + 2f), rigidbody.velocity.y);

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

    public IEnumerator MouseSound()
    {
        while (true)
        {


            yield return new WaitForSeconds(Random.Range(1.5f,5.5f));
           
           if (Random.Range(0, 6) == 0)
            {

                while (Random.Range(0, MouseClip.Length) == previousClip);

                
                audiosource.clip = MouseClip[previousClip = Random.Range(0, MouseClip.Length)];
                audiosource.Play();
            }
            yield return null;
           
        }
    }

    public IEnumerator MouseJump()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.25f);

            if(Random.Range(0,2) == 0)
            {
                if (jump == true) Rigid.AddForce(new Vector2(Random.Range(-10, 10), Random.Range(40, 60)));
            }

            yield return null;
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "ground")
        {
            jump = true;
        }

        if(coll.gameObject.tag == "owl")
        {
            gameObject.SetActive(false);
            if (!Pooling.miceList.Contains(this.gameObject)) Pooling.miceList.Add(this.gameObject);
            RemoveMouse();
        }
    }

    void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "ground")
        {
            jump = false;
        }
    }

    void RemoveMouse()
    {
        PlayerMouseController.MouseNumber--;
    }

}
