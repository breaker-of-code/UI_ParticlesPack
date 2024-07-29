using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> _2dItemsToSpawn;
    [SerializeField] private List<GameObject> _3dItemsToSpawn;
    [SerializeField] private List<GameObject> _uiItemsToSpawn;

    [Space] [SerializeField] private TMP_Text _headingText;
    [SerializeField] private TMP_Text _counterText;

    private GameObject prevItem;
    private int count = 1;

    private void Start()
    {
        StartCoroutine(nameof(Spawn2dParticles));
    }

    private IEnumerator Spawn2dParticles()
    {
        yield return new WaitForSeconds(1f);
        prevItem = null;

        _headingText.text = "2D Particles";
        _counterText.text = count.ToString();
        
        yield return new WaitForSeconds(1f);

        foreach (var item in _2dItemsToSpawn)
        {
            if (prevItem is not null)
                Destroy(prevItem);

            count++;
            prevItem = Instantiate(item, transform.position, Quaternion.identity);
            _counterText.text = count.ToString();

            yield return new WaitForSeconds(1.5f);
        }

        StartCoroutine(nameof(Spawn3dParticles));
    }

    private IEnumerator Spawn3dParticles()
    {
        yield return new WaitForSeconds(0.25f);

        count = 1;
        Destroy(prevItem);
        prevItem = null;
        
        _headingText.text = "3D Particles";
        _counterText.text = count.ToString();

        yield return new WaitForSeconds(0.75f);

        foreach (var item in _3dItemsToSpawn)
        {
            if (prevItem is not null)
                Destroy(prevItem);

            count++;
            prevItem = Instantiate(item, transform.position, Quaternion.identity);
            _counterText.text = count.ToString();

            yield return new WaitForSeconds(1.55f);
        }

        StartCoroutine(nameof(SpawnUiParticles));
    }

    private IEnumerator SpawnUiParticles()
    {
        yield return new WaitForSeconds(0.25f);

        count = 1;
        Destroy(prevItem);
        prevItem = null;
        
        _headingText.text = "UI Particles";
        _counterText.text = count.ToString();
        
        yield return new WaitForSeconds(0.75f);

        foreach (var item in _uiItemsToSpawn)
        {
            if (prevItem is not null)
                Destroy(prevItem);

            count++;
            prevItem = Instantiate(item, transform.position, Quaternion.identity);
            _counterText.text = count.ToString();

            yield return new WaitForSeconds(1.25f);
        }
    }
}