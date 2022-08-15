using UnityEngine;

public class ScreenBounds : MonoBehaviour
{
    #region Field Declarations

    public static Vector2 bounds;
    private static float spriteBorder = .5f;

    public static float left { get { return -bounds.x + spriteBorder; } }
    public static float right { get { return bounds.x - spriteBorder; } }
    public static float top { get { return bounds.y - spriteBorder; } }
    public static float bottom { get { return -bounds.y + spriteBorder; } }

    #endregion
    private void Start()
    {
        bounds = GetScreenBounds();
    }
    private static Vector2 GetScreenBounds()
    {
        Vector2 screenVector = new Vector2(Screen.width, Screen.height);

        return Camera.main.ScreenToWorldPoint(screenVector);
    }

    public static Vector2 RandomBottomPosition()
    {
        float horizontalPosition = Random.Range(left, right);
        return new Vector2(horizontalPosition, bottom);
    }

    public static Vector2 GetRandomPosition()
    {
        float targetVerticalPos = Random.Range(-bounds.y + (spriteBorder * 2), bounds.y - spriteBorder);
        float targetHorizontalPos = Random.Range(-bounds.x + spriteBorder, bounds.x - spriteBorder);

        return new Vector2(targetHorizontalPos, targetVerticalPos);
    }
    public static Vector2 GetRandomPositionFullScreen()
    {
        float targetVerticalPos = Random.Range(-bounds.y, bounds.y);
        float targetHorizontalPos = Random.Range(-bounds.x, bounds.x);

        return new Vector2(targetHorizontalPos, targetVerticalPos);
    }

    public static bool OutOfBounds(Vector2 position)
    {
        float x = Mathf.Abs(position.x);
        float y = Mathf.Abs(position.y);

        return (x > bounds.x || y > bounds.y);
    }
}
