using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorMonedas : MonoBehaviour
{
    [SerializeField]
    private GameObject monedaPrefab;

    [SerializeField]
    private float rate;

    [SerializeField]
    private float maxtime;

    [SerializeField]
    private float destroyTime;

    [SerializeField]
    private Transform posToMove;

    [SerializeField]
    private bool instanciaRandom = false;

    [SerializeField]
    private Color randomColor;

    [SerializeField]
    private Color PositionColor;

    [SerializeField]
    private Vector3 limitesMaximos;

    [SerializeField]
    private Vector3 limitesMinimos;

    private List<GameObject> monedasList = new();

    private float initTime;

    private bool invoking = true;

    private bool destroying = false;


    private void Start()
    {
        initTime = Time.realtimeSinceStartup;
        InvokeRepeating(nameof(CreaMoneda), 0.0f, rate);
    }

    private void CreaMoneda()
    {
        GameObject moneda = Instantiate(monedaPrefab, transform);
        if (instanciaRandom)
        {
            Vector3 newPos = new Vector3();
            newPos.x = Random.Range(limitesMinimos.x, limitesMaximos.x);
            newPos.y = Random.Range(limitesMinimos.y, limitesMaximos.y);
            newPos.z = Random.Range(limitesMinimos.z, limitesMaximos.z);
            moneda.transform.position = newPos;
            moneda.GetComponent<Renderer>().material.color = randomColor;
        }
        else
        {
            moneda.transform.position = posToMove.position;
            moneda.GetComponent<Renderer>().material.color = PositionColor;
        }
        monedasList.Add(moneda);
    }

    private void ChangeColor()
    {
        foreach (var moneda in monedasList)
        {
            Color rndColor = new(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
            moneda.GetComponent<Renderer>().material.color = rndColor;
        }
    }

    private void Update()
    {
        if (invoking && Time.realtimeSinceStartup - initTime > maxtime)
        {
            invoking = false;
            CancelInvoke();
            InvokeRepeating(nameof(ChangeColor), 0, 1.0f);
        }

        if (!destroying &&  Time.realtimeSinceStartup - initTime > destroyTime)
        {
            invoking = true;
            destroying = true;
            foreach (GameObject moneda in monedasList)
            {
                Destroy(moneda);
            }
            monedasList.Clear();
            initTime = Time.realtimeSinceStartup;
            InvokeRepeating(nameof(CreaMoneda), 0.0f, rate);
        }
    }
}
