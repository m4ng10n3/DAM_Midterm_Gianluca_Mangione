using UnityEngine;

public class GoalZone : MonoBehaviour
{
    public enum GoalSide { Left, Right }
    public GoalSide side;

    private void OnTriggerEnter2D(Collider2D other)
    {
        BallController ball = other.GetComponent<BallController>();
        if (ball == null) return;

        ball.ResetPositionAndLaunch();

        ScoreManager scoreManager = FindFirstObjectByType<ScoreManager>();
        if (scoreManager == null) return;

        if (side == GoalSide.Left)
        {
            scoreManager.AddPointToRight();
        }
        else
        {
            scoreManager.AddPointToLeft();
        }
    }
}
