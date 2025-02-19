using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public float leftBoundary = -3f;



    private void moverObtacles()
    {
        transform.position += Vector3.left * gameManager.instance.getGameSpeed() * Time.deltaTime;
        if (transform.position.x < leftBoundary)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        moverObtacles();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))


        {
            gameManager.instance.gameOver();
        }
    }
}
