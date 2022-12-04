using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class FieldRandomizer : MonoBehaviour
{
    public bool generateOnStart = false;
    public Sprite[] decorations;
    public Alpacka alpackaPrefab;
    public Enclosure enclosurePrefab;
    public Goblin goblinPrefab;
    public EnclosureManager enclosureManager;
    public int numberOfEnclosures = 1;
    public int numberOfDecorations = 7;
    public int numberOfAlpackasPerEnclosure = 5;

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
        enclosureManager.enclosures.Clear();

        foreach (Transform t in transform)
        {
            Destroy(t.gameObject);
        }
    }

    public void Generate()
    {
        GenerateAlpackas();
        GenerateEnclosures();
        GenerateDecorations();
    }

    private void GenerateDecorations()
    {
        for (int i = 0; i < numberOfDecorations; i++)
            InstantiateRandomDecoration();
    }

    private void GenerateAlpackas()
    {
        for (int i = 0; i < numberOfAlpackasPerEnclosure * numberOfEnclosures; i++)
            InstantiateAlpacka();
    }

    private void GenerateEnclosures()
    {
        for (int i = 0; i < numberOfEnclosures; i++)
        {
            Enclosure enclosure = InstantiateEnclosure();
            enclosure.capacity = numberOfAlpackasPerEnclosure;
            enclosureManager.AddEnclosure(enclosure);
        }
    }

    private GameObject InstantiateRandomDecoration()
    {
        Sprite decoration = decorations[Random.Range(0, decorations.Length)];
        SpriteRenderer obj = Instantiate(new GameObject().AddComponent<SpriteRenderer>());
        obj.sprite = decoration;
        obj.transform.position = RandomPoint();
        return obj.gameObject;
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
