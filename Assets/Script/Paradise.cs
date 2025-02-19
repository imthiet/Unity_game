using UnityEngine;

public class Paradise : MonoBehaviour
{
    private Material material;
    [SerializeField]
    private float paradisefactor = 0.01f;
    private float offset;

    public float gameSpeed = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        material = GetComponent<Renderer>().material;


    }

    // Update is called once per frame
    void Update()
    {
        paradiseScroll();

    }


    private void paradiseScroll()
    {
        float speed = gameManager.instance.getGameSpeed() * paradisefactor;
        offset += Time.deltaTime * speed;
        material.SetTextureOffset("_MainTex", Vector2.right * offset);
    }
}
