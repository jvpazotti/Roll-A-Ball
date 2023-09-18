using UnityEngine;

// Include the namespace required to use Unity UI and Input System
using UnityEngine.InputSystem;
using TMPro;

using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour {
	
	// Create public variables for player speed, and for the Text UI game objects
	public float speed;
	public TextMeshProUGUI countText;
	public GameObject winTextObject;

        private float movementX;
        private float movementY;

	private Rigidbody rb;
	private int count;

	public AudioClip collectableSound;

	private AudioSource audioSource;

	// At the start of the game..
	void Start ()
	{
		// Assign the Rigidbody component to our private rb variable
		rb = GetComponent<Rigidbody>();

		// Set the count to zero 
		count = 0;

		SetCountText ();

                // Set the text property of the Win Text UI to an empty string, making the 'You Win' (game over message) blank
               winTextObject.SetActive(false);
		
		audioSource = GetComponent<AudioSource>(); 
	}

	void FixedUpdate ()
	{
		// Create a Vector3 variable, and assign X and Z to feature the horizontal and vertical float variables above
		Vector3 movement = new Vector3 (movementX, 0.0f, movementY);

		rb.AddForce (movement * speed);
	}

	void OnTriggerEnter(Collider other) 
	{
		// ..and if the GameObject you intersect has the tag 'Pick Up' assigned to it..
		if (other.gameObject.CompareTag ("PickUp"))
		{
			other.gameObject.SetActive (false);

			// Add one to the score variable 'count'
			count = count + 1;

			// Run the 'SetCountText()' function (see below)
			SetCountText ();

			audioSource.clip = collectableSound;
            audioSource.Play();

		}
	}

	void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            // Uncomment the line below to switch to a "Game Over" scene
            SceneManager.LoadScene("Dead-End");
            
            // Uncomment the line below to display the "Game Over" text in the current scene
            // winTextObject.SetActive(true);
            // winTextObject.GetComponent<TextMeshProUGUI>().text = "Game Over";
        }

		else if (collision.gameObject.CompareTag("Obstacle"))
    {
        // Handle obstacle collision, e.g., game over
        // For example, you could switch to a Game Over scene like so:
        SceneManager.LoadScene("Dead-End");
    }
    }

	void OnMove(InputValue value){
		Vector2 v = value.Get<Vector2>();

		movementX = v.x;
		movementY = v.y;
	}

	void SetCountText(){
		countText.text = "Count: " + count.ToString();

		if (count >= 16) {
					// Set the text value of your 'winText'
					SceneManager.LoadScene("YouWon");
		}
	}
}
