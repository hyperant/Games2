using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float speed; //How fast we want the ball to move
	public GUIText countText; //Used to display the count to the user
	public GUIText winText; //Used to display a win message to the user
	
	private int count; //How many squares the user has picked up
	
	void Start() {
		this.count =0;
		this.SetCountText();
		this.winText.text ="";
	}
	
	void FixedUpdate() {
		//Get user input
		float moveHorizontal =Input.GetAxis("Horizontal"); //x axis
		float moveVertical =Input.GetAxis("Vertical"); //y axis
		Vector3 movement =new Vector3(moveHorizontal, 0.0f, moveVertical); //Creates a new movement vector
		
		this.rigidbody.AddForce(movement *this.speed *Time.deltaTime); //Apply the movement to the ball
	}
	
	void OnTriggerEnter(Collider other) {
		//check to see if we have collided with the PickUp item, if so then we want to deactivate it
		if(other.gameObject.tag =="PickUp") {
			other.gameObject.SetActive(false);
			
			//Even though the tutorial said to do it like count =count +1 I feel that it is more common practice to add one by using ++
			this.count++;
			this.SetCountText();
		}
	}
	
	void SetCountText() {
		this.countText.text ="Count: " +this.count.ToString();
		//Once the player has all the squares tell them they have won
		if(this.count >=12) {
			this.winText.text ="YOU WIN!";
		}
	}
}
