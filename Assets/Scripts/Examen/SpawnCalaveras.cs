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
        print(totalTargets.Count);

        if (Input.anyKey)
        {
            if (Input.GetKeyDown(actionKey))
            {
                Spawn();
            }
        }
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
