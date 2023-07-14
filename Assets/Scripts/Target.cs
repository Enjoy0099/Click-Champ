using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetBody;

    private float minSpeed = 12f;
    private float maxSpeed = 16f;
    private float maxTorque = 10f;
    private float xRange = 4f;
    private float ySpawnPos = -3f;

    private void Awake()
    {
        targetBody = GetComponent<Rigidbody>();
        transform.position = RandomSpawnPos();
    }

    private void Start()
    {
        targetBody.AddForce(RandomForce(), ForceMode.Impulse);

        targetBody.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
    }
    
    void OnMouseDown()
    {
        Destroy(gameObject);
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
    }
}
