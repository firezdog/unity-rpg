using UnityEngine;

public class PlayerController : MonoBehaviour
{

	[SerializeField] Animator playerAnimator;
	[SerializeField] float moveSpeed;
	[SerializeField] Rigidbody2D playerBody;

	public static PlayerController instance;
	string from = "start";
	// for use with portal elements.
	public string getFrom() { return from; }
	public void setFrom(string value) { from = value; }

	// Use this for initialization
	void Start()
	{
		loadPlayer();
	}

	void loadPlayer()
	{
		if (instance == null)
		{
			instance = this;
		}
		else { Destroy(gameObject); }
		DontDestroyOnLoad(gameObject);
	}

	// Update is called once per frame
	void Update()
	{
		animatePlayer();
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
