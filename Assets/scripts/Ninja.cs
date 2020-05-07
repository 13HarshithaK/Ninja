using UnityEngine;
using System.Collections;

public class Ninja : MonoBehaviour 
{
	public float upForce=400f;                   //Upward force.
	private bool isDead = false;            //Has the player collided with a wall?

	private Animator anim;                  //Reference to the Animator component.
	private Rigidbody2D rb2d;               //Holds a reference to the Rigidbody2D component of the bird.
	private BoxCollider2D obj;
	private Vector2  NinjaPosition = new Vector2 (-7.76f,-1.86f);     //A holding position for 

	void Start()
	{
		//Get reference to the Animator component attached to this GameObject.
		anim=GetComponent<Animator>();
		//Get and store a reference to the Rigidbody2D attached to this GameObject.
		rb2d = GetComponent<Rigidbody2D>();
		obj= GetComponent<BoxCollider2D>();
	}

	void Update()
	{
		//Don't allow control if the bird has died.
		if (isDead == false) 
		{
			anim.SetTrigger ("PlayNinjaRun");
			//Look for input to trigger a "flap".
			if (Input.GetKeyDown(KeyCode.UpArrow)) 
			{
				//...tell the animator about it and then...
				anim.SetTrigger("NinjaJump");
				//...zero out the birds current y velocity before...
				rb2d.velocity = Vector2.zero;
				//  new Vector2(rb2d.velocity.x, 0);
				//..giving the bird some upward force.
				rb2d.AddForce(new Vector2(0, upForce));
			}

			if (Input.GetKeyDown(KeyCode.RightArrow)) 
			{
				//...tell the animator about it and then...
				anim.SetTrigger("NinjaAttack");
				//...zero out the birds current y velocity before...
				rb2d.velocity = Vector2.zero;
				obj.enabled = true;
			}

			if (Input.GetKeyUp (KeyCode.RightArrow)) {
				obj.enabled = false;
			}
		}
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag != "Floor") {		// Zero out the bird's velocity
			rb2d.velocity = Vector2.zero;
			// If the bird collides with something set it to dead...
			isDead = true;
			//...tell the Animator about it...
			anim.SetTrigger ("NinjaDie");
			//...and tell the game control about it.
			GameControl.instance.NinjaDied ();
		}
	}


}