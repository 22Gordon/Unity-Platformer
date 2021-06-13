using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SceneManagement;



public class Stage4Script : MonoBehaviour
{

	// Create public variables for player speed, and for the Text UI game objects
	public float speed;
	public bool checkpoint = false;
	public TextMeshProUGUI countText;
	public GameObject gameObjectToActivate;
	

	
	private float movementX;
	private float movementY;

	private Rigidbody rb;
	private int count;

    

	// At the start of the game..
	void Start()
	{

		// Assign the Rigidbody component to our private rb variable
		rb = GetComponent<Rigidbody>();

		count = 16;

		SetCountText();
	
		
	}

	void FixedUpdate()
	{
		// Create a Vector3 variable, and assign X and Z to feature the horizontal and vertical float variables above
		Vector3 movement = new Vector3(movementX, 0.0f, movementY);

		rb.AddForce(movement * speed);

		if (rb.transform.position.y <= -4)
		{
			SceneManager.LoadScene(7);
		}

		if(Input.GetKeyDown(KeyCode.H)){
			SceneManager.LoadScene(0);
		}
	}

	void OnTriggerEnter(Collider other){

		// ..and if the GameObject you intersect has the tag 'Pick Up' assigned to it..
		if (other.gameObject.CompareTag("PickUp"))
		{
			other.gameObject.SetActive(false);
			checkpoint = true;

			count = count - 1;

			SetCountText();

			if(count == 1){
				gameObjectToActivate.SetActive(false);
			}
            

			
		}

        if(other.gameObject.CompareTag("Speed")){
            speed = 40;
        }

		if(other.gameObject.CompareTag("Slow")){
			speed = 20;
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

			SceneManager.LoadScene(0);
		}

	
	}



}