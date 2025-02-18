using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabEmmiter : MonoBehaviour
{
    [SerializeField] float radius;
    [SerializeField] float frequency;
    [SerializeField] float life;
    [SerializeField] int maxparticles;
    [SerializeField] List<ParticlePrefab> pool;
    [SerializeField] GameObject particlePrefab;
    [SerializeField] Vector3 force;
    private void Start()
    {
        pool = new List<ParticlePrefab>();
        for (int i = 0; i < maxparticles; i++)
        {
            GameObject go = Instantiate(particlePrefab);
            go.transform.parent = transform;
            ParticlePrefab particle = go.GetComponent<ParticlePrefab>();
            particle.life = life;
            pool.Add(particle);
        }
        StartCoroutine(SpawnCoroutine());
    }
    private IEnumerator SpawnCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(frequency);
            Spawn();
        }
    }
    private void Spawn()
    {
        float r = radius * Mathf.Sqrt(Random.Range(0f, 1f));
        float theta = Random.Range(0f, 2 * Mathf.PI);
        float x = r * Mathf.Cos(theta);
        float y = r * Mathf.Sin(theta);
        Vector3 position = new Vector3(x, y, 0);
        for (int i = 0; i < maxparticles; i++)
        {
            if (pool[i].isAlive == false)
            {
                Rigidbody body = pool[i].GetComponent<Rigidbody>();
                pool[i].life = life;
                pool[i].isAlive = true;
                pool[i].transform.Rotate(new Vector3(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360)));
                pool[i].transform.localPosition = position;
                pool[i].gameObject.SetActive(true);
                body.isKinematic = true;
                body.isKinematic = false;
                body.AddForce(force);
                
                break;
            }
        }

    }
}
