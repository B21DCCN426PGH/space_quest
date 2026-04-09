using UnityEngine;

public class Beetlemorph : Enemy
{
    [SerializeField] private Sprite[] sprites;
    private float timer;
    private float frequency;
    private float amplitude;
    private float centerY;

    public override void OnEnable()
    {
        base.OnEnable();
        centerY = transform.position.y;
        frequency = Random.Range(0.3f, 1f);
        amplitude = Random.Range(0.8f, 1.5f);
        timer = transform.position.y;
    }

    public override void Start()
    {
        base.Start();
        GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Length)];
        destroyEffectPool = GameObject.Find("BeetlePopPool").GetComponent<ObjectPooler>();
        hitSound = AudioManager.Instance.beetleHit;
        destroySound = AudioManager.Instance.beetleDestroy;
        speedX = Random.Range(-0.8f, -1.5f);
    }

    public override void Update()
    {
        base.Update();

        timer += Time.deltaTime;
        float sine = Mathf.Sin(timer * frequency) * amplitude ;
        transform.position = new Vector3(transform.position.x, centerY + sine); 
    }

}
