using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetBody;
    private GameManager gameManager_Script;

    private float minSpeed = 12f;
    private float maxSpeed = 16f;
    private float maxTorque = 10f;
    private float xRange = 4f;
    private float ySpawnPos = -3f;

    public ParticleSystem[] explosionParticle;
    public int pointValue;

    private void Awake()
    {
        targetBody = GetComponent<Rigidbody>();
        gameManager_Script = FindObjectOfType<GameManager>();

        transform.position = RandomSpawnPos();
    }

    private void Start()
    {
        targetBody.AddForce(RandomForce(), ForceMode.Impulse);

        targetBody.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
    }
    
    void OnMouseDown()
    {
        if(gameManager_Script.isGameActive)
        {
            Destroy(gameObject);
            int randomColor = Random.Range(0, explosionParticle.Length); 
            Instantiate(explosionParticle[randomColor], transform.position, explosionParticle[randomColor].transform.rotation);
            gameManager_Script.UpdateScore(pointValue);
        }
    }

    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }

    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if(!gameObject.CompareTag(NameManager.BAD_TAG))
        {
            gameManager_Script.GameOver();
        }
    }
}
