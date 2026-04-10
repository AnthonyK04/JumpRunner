using UnityEngine;

public class Obstacle : MonoBehaviour
{
    //
    void Update()
    {
        //moves obstacle left every frame
        transform.Translate(Vector2.left * GameManager.Instance.gameSpeed * Time.deltaTime);
        //destroy obstacle if it goes off screen
        if (transform.position.x < -15f)
            Destroy(gameObject);
    }
}