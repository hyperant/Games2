using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	public GameObject player; //The player object we want the camera to follow
	
	private Vector3 offset; //The offset that the camera should be relative to the players position

	// Use this for initialization
	void Start () {
		this.offset =this.transform.position; //Set the offset position to be the starting position of the camera
	}
	
	// Update is called once per frame
	void LateUpdate () {
		this.transform.position =this.player.transform.position +this.offset; //Make sure the camera follows the player
	}
}
