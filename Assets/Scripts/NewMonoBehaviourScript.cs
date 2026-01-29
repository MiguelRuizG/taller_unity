using UnityEngine;
using UnityEngine.SceneManagement;

public class NewMonoBehaviourScript : MonoBehaviour
{
	public float	moveForce;
	public float	jumpForce;
	
	public LayerMask	groundLayer;
	Rigidbody2D rb;

	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	void Update()
	{
		float playerMovenent = Input.GetAxis("Horizontal");
		rb.linearVelocity = new(playerMovenent * moveForce, rb.linearVelocity.y);
		if (Input.GetButtonDown("Jump") && IsGrounded()) 
		rb.AddForce(new(0, jumpForce), ForceMode2D.Impulse);
	}
	
	private bool IsGrounded()
	{
		//Lanza un rayo desde el jugador hacia abajo

		RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 2f, groundLayer);

		return hit.collider != null;
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Death"))
		{
			Debug.Log("Has muerto");
			//Time.timeScale = 0;
			SceneManager.LoadScene("SampleScene");
		}
	}
}
