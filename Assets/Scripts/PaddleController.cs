using UnityEngine;
using UnityEngine.InputSystem;

public class PaddleController : MonoBehaviour
{
    public InputAction moveUp;
    public InputAction moveDown;
    public Rigidbody2D body2D;

    public float moveSpeed = 5f;

    public float minYLimit = -4f;
    public float maxYLimit = 4f;

    public void OnEnable()
    {
        moveUp.Enable();
        moveDown.Enable();
    }

    public void OnDisable()
    {
        moveUp?.Disable();
        moveDown?.Disable();
    }

    private void Update()
    {

        if (moveDown.IsPressed() || moveUp.IsPressed())
        {
            if (moveUp.IsPressed())
                body2D.linearVelocityY = moveSpeed;
            else
                body2D.linearVelocityY = -moveSpeed;
        }
        else
        {

            body2D.linearVelocityY = 0f;
        }

        Vector3 pos = transform.position;

        if (pos.y < minYLimit)
        {
            pos.y = minYLimit;
        }
        else if (pos.y > maxYLimit)
        {
            pos.y = maxYLimit;
        }

        transform.position = pos;
    }
}
