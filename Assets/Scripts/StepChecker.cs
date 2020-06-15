using UnityEngine;

public class StepChecker : MonoBehaviour
{
    [SerializeField] private Inventory _inventory;

    public bool IsPlay = true;

    private CardOpener[] _cardOpeners;
    private int _buysCount = 0;
    private int _cost = 0;

    public void GetSwap(int prize, int count)
    {
        if (_buysCount < 3)
        {
            _buysCount++;
        }
        else if (_buysCount == 3)
        {
            _buysCount++;
            _cost = 1;
        }
        else if (_buysCount == 4)
        {
            _buysCount++;
            _cost = 3;
        }

        _inventory.Pay(prize, count, _cost);

        if (_cost == 3)
        {
            IsPlay = false;
            Reset();
        }
    }

    private void Reset()
    {
        _buysCount = 0;
        _cost = 0;
        IsPlay = true;

        _cardOpeners = FindObjectsOfType<CardOpener>();

        foreach (var opener in _cardOpeners)
            if (opener.IsClosed == false)
                opener.StartSwap();
    }

}
