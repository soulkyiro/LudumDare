using UnityEngine;
using System.Collections;

public class Astronaut : MonoBehaviour {
    
    private bool facingLeft = true;
	private float fuel;
    private float rocketForce = 1000.0f;
    private float horizontalForce = -1000.0f;

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
		Move();
	}

	void Move ()
	{
        if (Input.GetKey("a"))
        {
			FlyLeft();
		}
		if (Input.GetKey("d"))
        {
			FlyRight();
		}
        if (Input.GetKey("w"))
        {
            FlyUP();
        }
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
