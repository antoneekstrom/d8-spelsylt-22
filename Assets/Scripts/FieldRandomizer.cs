using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class FieldRandomizer : MonoBehaviour
{
    public bool generateOnStart = false;
    public GameObject[] decorations;
    public Alpacka alpackaPrefab;
    public Enclosure enclosurePrefab;
    public int numberOfEnclosures = 1;
    public int numberOfDecorations = 7;
    public int numberOfAlpackas = 5;

    private void Start()
    {
        if (generateOnStart)
        {
            Clear();
            Generate();
        }
    }

    public void Clear()
    {
        foreach (Transform t in transform)
        {
            Destroy(t.gameObject);
        }
    }

    public void Generate()
    {
        GenerateAlpackas();
        GenerateEnclosures();
    }

    private void GenerateAlpackas()
    {
        for (int i = 0; i < numberOfAlpackas; i++)
            InstantiateAlpacka();
    }

    private void GenerateEnclosures()
    {
        for (int i = 0; i < numberOfEnclosures; i++)
            InstantiateEnclosure();
    }

    private Enclosure InstantiateEnclosure()
    {
        Enclosure enclosure = Instantiate(enclosurePrefab);
        enclosure.transform.position = RandomPoint();
        enclosure.transform.SetParent(transform);
        return enclosure;
    }

    private Alpacka InstantiateAlpacka()
    {
        Alpacka alpacka = Instantiate(alpackaPrefab);
        alpacka.transform.position = RandomPoint();
        alpacka.transform.SetParent(transform);
        return alpacka;
    }

    private Vector2 RandomPoint()
    {
        Rect area = ((RectTransform)transform).rect;
        return new Vector2(Random.Range(area.xMin, area.xMax), Random.Range(area.yMin, area.yMax));
    }
}
