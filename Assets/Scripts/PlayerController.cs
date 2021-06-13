using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{

	// Create public variables for player speed, and for the Text UI game objects
	public float speed;
	public TextMeshProUGUI countText;
	
	
	private float movementX;
	private float movementY;

	private Rigidbody rb;
	private int count;

	// At the start of the game..
	void Start()
	{

		rb = GetComponent<Rigidbody>();

		
		count = 5;

		SetCountText();
	
		
	}

	void FixedUpdate()
	{
		// Create a Vector3 variable, and assign X and Z to feature the horizontal and vertical float variables above
		Vector3 movement = new Vector3(movementX, 0.0f, movementY);

		rb.AddForce(movement * speed);

		if (rb.transform.position.y <= -4)
		{
			SceneManager.LoadScene(1);
		}

		if(Input.GetKeyDown(KeyCode.H)){
			SceneManager.LoadScene(0);
		}
	}

	void OnTriggerEnter(Collider other)
	{
		
		if (other.gameObject.CompareTag("PickUp"))
		{
			other.gameObject.SetActive(false);

			
			count = count - 1;

			// Run the 'SetCountText()' function 
			SetCountText();
		}
	}

	void OnMove(InputValue value)
	{

		Vector2 v = value.Get<Vector2>();

		movementX = v.x;
		movementY = v.y;
	}

	void SetCountText()
	{

		countText.text = " Faltam apanhar pickUps: " + count.ToString();

		if (count == 0){

			SceneManager.LoadScene(2);
		}
	}

	void OnFall()
    {
		
	}
}
