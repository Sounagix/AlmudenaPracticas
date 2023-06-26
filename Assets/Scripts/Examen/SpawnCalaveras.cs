using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCalaveras : MonoBehaviour
{
    [SerializeField]
    private GameObject[] calaverasPrefab;

    [SerializeField]
    private KeyCode actionKey;

    private List<GameObject> totalTargets = new();

    private void Update()
    {
        if (Input.anyKey)
        {
            if (Input.GetKeyDown(actionKey))
            {
                StartCoroutine(SpawnTargets());
            }
        }
    }

    private IEnumerator SpawnTargets()
    {
        for (int i = 0; i < 5; i++)
        {
            float t = Random.Range(1.0f, 2.0f);
            StartCoroutine(WaitTime(t));
        }
        yield return null;
    }

    private IEnumerator WaitTime(float _t)
    {
        yield return new WaitForSecondsRealtime(_t);
        Spawn();
    }

    private void Spawn()
    {
        int choice = Random.Range(0, calaverasPrefab.Length);
        GameObject actualCalavera = Instantiate(calaverasPrefab[choice], transform);
        actualCalavera.GetComponent<TargetBase>().Init(this);
        actualCalavera.transform.position = transform.position;
        totalTargets.Add(actualCalavera);
    }

    public void OnCalaveraDestroy(GameObject _actualCalaveraDestruida)
    {
        totalTargets.Remove(_actualCalaveraDestruida);
    }
}
