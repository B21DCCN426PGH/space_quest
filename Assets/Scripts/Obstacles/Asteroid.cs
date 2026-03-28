using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Asteroid : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    [SerializeField] private Sprite[] sprites;

    private Material defaultMaterial;
    [SerializeField] private Material whiteMaterial;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        defaultMaterial = spriteRenderer.material;
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer.sprite = sprites[Random.Range(0, sprites.Length)];  
        float pushX = Random.Range(-1f, 0);
        float pushY = Random.Range(-1f, 1f);
        rb.linearVelocity = new Vector2(pushX, pushY);
    }

    private void Update()
    {
        float moveX = GameManager.Instance.worldSpeed * PlayerController.Instance.boost * Time.deltaTime;
        transform.position += new Vector3(-moveX, 0);
        if (transform.position.x < -11)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            spriteRenderer.material = whiteMaterial;
            StartCoroutine("ResetMaterial");
        }
    }
    IEnumerable ResetMaterial()
    {
        yield return new WaitForSeconds(0.2f);
        spriteRenderer.material = defaultMaterial;
    }
}
