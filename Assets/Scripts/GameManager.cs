using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    private float spawnRate = 1f;

    private void Start()
    {
        StartCoroutine(SpawnTarget());
    }

    private void Update()
    {
        Debug.Log(Input.mousePosition);
        Debug.Log(Camera.main.WorldToScreenPoint(transform.position));
        Debug.Log(Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position) + "/////////");
    }

    IEnumerator SpawnTarget()
    {
        yield return new WaitForSeconds(spawnRate);
        int index = Random.Range(0, targets.Count);
        Instantiate(targets[index]);
        StartCoroutine(SpawnTarget());
    }
}
