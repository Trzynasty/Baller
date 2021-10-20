using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour
{
    [SerializeField] Vector2 launchVelocity = new Vector2(2f, 10f);
    [Range(0,1f)][SerializeField] float randomFactor = 0.2f;
    [SerializeField] Paddle paddle1;
	bool hasStarted = false;
	Vector3 paddleToBallVector;

	void Start ()
    {
		paddle1 = FindObjectOfType<Paddle>();
		paddleToBallVector = transform.position - paddle1.transform.position;
	}

  void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2(
            Random.Range(0f, randomFactor),
            Random.Range(0f, randomFactor)
        );

        if (hasStarted)
        {
            GetComponent<AudioSource>().Play();
            GetComponent<Rigidbody2D>().velocity += velocityTweak;
        }
    }
    
    void Update()
    {
        if (!hasStarted)
        {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }
    }

    private void LockBallToPaddle()
    {
        transform.position = paddle1.transform.position + paddleToBallVector;
    }

    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            GetComponent<Rigidbody2D>().velocity = launchVelocity;
        }
    }
}
