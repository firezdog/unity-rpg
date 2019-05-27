using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerController : MonoBehaviour
{
	[SerializeField] Animator playerAnimator;
	[SerializeField] float moveSpeed;
	[SerializeField] Rigidbody2D playerBody;

	public static PlayerController instance;
	
	// for use with portal elements.
	private string from = "start";
	public string getFrom() { return from; }
	public void setFrom(string value) { from = value; }

	private bool canMove = true;
	public void SetCanMove(bool option) { canMove = option; }

	private Vector3 mapMin;
	private Vector3 mapMax;

	public void setBounds(Vector3 mapMinValue, Vector3 mapMaxValue) {
		mapMin = mapMinValue + new Vector3(1f, 1f, 0);
		mapMax = mapMaxValue - new Vector3(1f, 1f, 0);
	}

	// make sure this is set for other scripts
	void Awake()
	{
		setInstance();
	}

	private void setInstance()
	{
		if (instance == null)
		{
			instance = this;
		}
		else { Destroy(gameObject); }
		DontDestroyOnLoad(gameObject);
	}

	private void clampPlayer()
	{
		gameObject.transform.position = new Vector3(
			Mathf.Clamp(gameObject.transform.position.x, mapMin.x, mapMax.x),
			Mathf.Clamp(gameObject.transform.position.y, mapMin.y, mapMax.y),
			gameObject.transform.position.z
		);
	}

	// Update is called once per frame
	void Update()
	{
		if (canMove) {
			animatePlayer();
			clampPlayer();
		}
	}

	private void animatePlayer()
	{
		playerBody.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * moveSpeed;
		playerAnimator.SetFloat("moveX", playerBody.velocity.x);
		playerAnimator.SetFloat("moveY", playerBody.velocity.y);
		if (playerBody.velocity != new Vector2(0, 0))
		{
			playerAnimator.SetBool("stopped", false);
			playerAnimator.SetFloat("facingX", playerBody.velocity.x);
			playerAnimator.SetFloat("facingY", playerBody.velocity.y);
		}
		else
		{
			playerAnimator.SetBool("stopped", true);
		}
	}

}
