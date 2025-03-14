using System.Collections;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public GameObject[] objects;
    public float spawnTimer = 0f;
    void Start() {Spawn();}
    void Update() {
        if (Timer.Instance.isTiming)
        {
            if (transform.childCount == 0) {
                spawnTimer += Time.deltaTime;
                if (spawnTimer > 1.5f) {
                    Spawn();
                    spawnTimer = 0f;
                }
            }
        }
    }

    public void Spawn () {
        int objectIndex = GetRandomObjectIndex();
        GameObject spawnedObject = Instantiate(objects[objectIndex], transform.position, Quaternion.identity, transform);
        StartCoroutine(ShrinkObject(spawnedObject, 3f));
        Destroy(spawnedObject, 6f);
    }

    private IEnumerator ShrinkObject(GameObject spawnedObject, float v) {
        yield return new WaitForSeconds(v);
        if (spawnedObject != null) {
            spawnedObject.transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }

    private int GetRandomObjectIndex() {
        float randomValue = Random.value;
        if (randomValue < 0.8f) return 0;
        else if (randomValue < 0.9f) return 1;
        else return 2;
    }
}
