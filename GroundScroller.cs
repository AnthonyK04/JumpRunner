using UnityEngine;

public class GroundScroller : MonoBehaviour
{
    public float tileWidth = 20f;
    public Transform[] tiles;
    private float spawnX;

    void Start()
    {
        spawnX = tiles[tiles.Length - 1].position.x;
    }
//moves each tile left so that it looks like the character is moving and not on a treadmill
    void Update()
    {
        foreach (Transform tile in tiles)
        {
            tile.Translate(Vector2.left * GameManager.Instance.gameSpeed * Time.deltaTime);

            if (tile.position.x < -tileWidth)
            {
                tile.position = new Vector3(spawnX, tile.position.y, tile.position.z);
            }
        }
    }
}