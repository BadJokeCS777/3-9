using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardCreator : MonoBehaviour
{
    [SerializeField] private List<PrizeData> _prizes;
    [SerializeField] private GameObject _cardPrefab;
    [SerializeField] private CardFiller _filler;

    private Vector3[] _positions = new Vector3[]
    {
        new Vector3(0,0,0),
        new Vector3(500,0,0),
        new Vector3(0,450,0),
        new Vector3(500,450,0),
        new Vector3(-500,0,0),
        new Vector3(0,-450,0),
        new Vector3(-500,-450,0),
        new Vector3(-500,450,0),
        new Vector3(500,-450,0)
    };

    private void Start()
    {
        Create();
    }

    private void Create()
    {
        Shuffle(_positions);

        for (int i = 0; i < _prizes.Count; i++)
        {
            _filler.Fill(_prizes[i]);

            Instantiate(_cardPrefab, transform).transform.localPosition = _positions[i];
        }
    }

    private void Shuffle(Vector3[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            int j = Random.Range(0, i + 1);
            var temp = array[j];
            array[j] = array[i];
            array[i] = temp;
        }
    }
}