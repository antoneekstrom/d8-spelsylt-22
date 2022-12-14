using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class FieldRandomizer : MonoBehaviour
{
    public Sprite[] decorations;
    public Alpacka alpackaPrefab;
    public Enclosure enclosurePrefab;
    public Goblin goblinPrefab;
    public EnclosureManager enclosureManager;
    public float goblinFrequency = 1f;
    public float goblinInterval = 1;
    public int numberOfEnclosures = 1;
    public int numberOfDecorations = 7;
    public int numberOfAlpackasPerEnclosure = 5;

    private float goblinTimer = 0;

    private void Start()
    {
        enclosureManager.OnAllFull.AddListener(() => enabled = false);
    }

    private void Update()
    {
        goblinTimer += Time.deltaTime;

        if (goblinTimer >= goblinInterval)
        {
            goblinTimer = 0;
            if (Random.value <= goblinFrequency)
                InstantiateGoblin();
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
        enabled = true;
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

    private Goblin InstantiateGoblin()
    {
        Goblin goblin = Instantiate(goblinPrefab);
        goblin.transform.position = Random.insideUnitCircle * 30;
        goblin.transform.SetParent(transform);
        return goblin;
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
        enclosure.transform.position = RandomPoint() * 0.5f;
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
