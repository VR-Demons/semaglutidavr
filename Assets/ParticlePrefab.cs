using System.Collections;
using UnityEngine;

public class ParticlePrefab : MonoBehaviour
{
    [SerializeField] public bool isAlive = false;
    [SerializeField] public float life;
    [SerializeField] public bool grabbed {  get; set; }
    
    private void OnEnable()
    {
        StartCoroutine(LifeCoroutine());
    }
    private void OnDisable()
    {
        StopCoroutine(LifeCoroutine());
    }
    private IEnumerator LifeCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(life);
            while (grabbed)
                yield return null;
            GetComponent<Animator>().SetTrigger("Die");
            yield return new WaitForSeconds(0.5f);
            isAlive = false;
            gameObject.SetActive(false);
        }
    }
}
