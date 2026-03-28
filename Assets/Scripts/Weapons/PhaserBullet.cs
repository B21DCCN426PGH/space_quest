using UnityEngine;
using UnityEngine.SceneManagement;

public class PhaserBullet : MonoBehaviour
{

    void Update()
    {
        transform.position += new Vector3(PhaserWeapon.Instance.speed * Time.deltaTime, 0f);
        if (transform.position.x > 11)
            {
                Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject) ;
        }
    }

}
