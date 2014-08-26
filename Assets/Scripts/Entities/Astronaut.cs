using UnityEngine;
using System.Collections;

public class Astronaut : MonoBehaviour {
    
    private bool facingLeft = true;
	private float fuel;
    private float rocketForce = 1000.0f;
    private float horizontalForce = -1000.0f;
	private bool isFlying = false;
	public GameObject trail;

    public float RocketForce
    {
        get { return rocketForce; }
        set { rocketForce = value; }
    }

    public float HorizontalForce
    {
        get { return horizontalForce; }
        set { horizontalForce = value; }
    }

	void Update() {
		trail.GetComponent<AstronautParticleEmiterController>().Enable(Move());
	}

	private bool Move ()
	{
		bool flyChecker = false;
        if (Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow))
        {
			FlyLeft();
			flyChecker = true;
		}
        if (Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow))
        {
			FlyRight();
			flyChecker = true;
		}
        if (Input.GetKey("w") || Input.GetKey(KeyCode.UpArrow))
        {
            FlyUP();
			flyChecker = true;
		}
        if (Input.GetKey("s") || Input.GetKey(KeyCode.DownArrow))
        {
            FlyDown();
            flyChecker = true;
        }
		return flyChecker;
	}

    private void FlyDown()
    {
        gameObject.transform.rigidbody2D.AddForce(Vector2.up * -rocketForce);
    }

    private void FlyUP()
    {
        gameObject.transform.rigidbody2D.AddForce(Vector2.up * rocketForce);
    }
	
	void FlyLeft ()
	{
        gameObject.transform.rigidbody2D.AddForce(Vector2.right * horizontalForce);
        if (!facingLeft) Flip();
	}

	void FlyRight ()
	{
        gameObject.transform.rigidbody2D.AddForce(Vector2.right * -horizontalForce);
        if (facingLeft) Flip();
	}

    void Flip()
    {
        facingLeft = !facingLeft;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
