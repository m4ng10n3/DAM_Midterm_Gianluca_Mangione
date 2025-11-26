using UnityEngine;

public class BallController : MonoBehaviour
{
    public Rigidbody2D body2D;
    public float speed = 8f;

    private void Start()
    {
        ResetPositionAndLaunch();
    }

    public void ResetPositionAndLaunch()
    {
        transform.position = Vector3.zero;
        body2D.linearVelocity = Vector2.zero;

        int dirX = Random.value < 0.5f ? -1 : 1;
        int dirY = Random.value < 0.5f ? -1 : 1;

        Vector2 direction = new Vector2(dirX, dirY).normalized;
        body2D.linearVelocity = direction * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.collider.CompareTag("Paddle"))
        {
            if (body2D.linearVelocity.sqrMagnitude > 0.001f)
            {
                Vector2 dir = body2D.linearVelocity.normalized;
                body2D.linearVelocity = dir * speed;
            }
            return;
        }


        Transform paddleTransform = collision.collider.transform;
        float paddleHeight = collision.collider.bounds.size.y;

        Vector2 contactPoint = collision.GetContact(0).point;


        float hitY = contactPoint.y - paddleTransform.position.y;


        float normalizedY = hitY / (paddleHeight / 2f);
        normalizedY = Mathf.Clamp(normalizedY, -1f, 1f);
        float dirX;

        if (transform.position.x < paddleTransform.position.x)
            dirX = -1f;
        else
            dirX = 1f;

        Vector2 newDirection = new Vector2(dirX, normalizedY).normalized;
        body2D.linearVelocity = newDirection * speed;
    }
}
