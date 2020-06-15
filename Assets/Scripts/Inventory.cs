using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    [SerializeField] private List<Text> _prizeTexts;
    [SerializeField] private Text _leveltext;

    private int[] _items = new int[8];
    private int _level;

    public enum Prize { Currency1, Currency2, Material1, Material2, Material3, Spell1, Spell2, Spell3 }

    public bool Pay(int prize, int count, int cost)
    {
        if (_items[(int)Prize.Currency1] - cost > 0)
        {
            _items[(int)Prize.Currency1] -= cost;
            AddItem(prize, count);
            return true;
        }
        else
        {
            return false;
        }
    }

    public void AddItem(int prize, int count)
    {
        if (prize < (int)Prize.Material2)
        {
            _items[prize] += count * _level;
        }
        else if (prize == (int)Prize.Material2)
        {
            if (_level % 2 == 0)
            {
                _items[prize] += count * (_level / 2);
            }
            else
            {
                _items[prize] += count * (_level / 2 + 1);
            }
        }
        else
        {
            _items[prize] += count;
        }

        _prizeTexts[(int)Prize.Currency1].text = _items[(int)Prize.Currency1].ToString();
        _prizeTexts[prize].text = _items[prize].ToString();
    }

    private void Start()
    {
        _items[(int)Prize.Currency1] = 250;
        _prizeTexts[(int)Prize.Currency1].text = _items[(int)Prize.Currency1].ToString();
        _level = Random.Range(1, 11);
        _leveltext.text = _level.ToString();
    }
}
