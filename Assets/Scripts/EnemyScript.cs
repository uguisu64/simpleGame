using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public GameObject enemyBar;
    public GameObject particle;

    private float speed = 2.0f;

    private void Start()
    {
        StartCoroutine(SelfDestroy());
        particle.GetComponent<ParticleSystem>().Play();
    }

    // Update is called once per frame
    void Update()
    {
        enemyBar.transform.localPosition += Vector3.back * speed * Time.deltaTime;
    }

    private IEnumerator SelfDestroy()
    {
        yield return new WaitForSeconds(10.0f);
        Destroy(gameObject);
    }
}
