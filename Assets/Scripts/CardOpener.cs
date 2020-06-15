using System;
using UnityEngine;
using UnityEngine.UI;

public class CardOpener : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private GameObject _shirt;
    [SerializeField] private Text _name;
    [SerializeField] private Text _count;

    public bool IsClosed = true;

    private StepChecker _checker;

    private void Start()
    {
        _checker = FindObjectOfType<StepChecker>();
    }

    public void StartSwap()
    {
        IsClosed = !IsClosed;
        _animator.SetTrigger("Swap");
    }

    private void Swap()
    {
        _shirt.SetActive(IsClosed);
    }

    private void EndSwap()
    {
        _animator.ResetTrigger("Swap");
    }

    private void OnMouseUp()
    {
        if (_checker.IsPlay)
        {
            StartSwap();

            int prize = 0;
            switch (_name.text)
            {
                case "Currency1":
                    prize = 0;
                    break;
                case "Currency2":
                    prize = 1;
                    break;
                case "Material1":
                    prize = 2;
                    break;
                case "Material2":
                    prize = 3;
                    break;
                case "Material3":
                    prize = 4;
                    break;
                case "Spell1":
                    prize = 5;
                    break;
                case "Spell2":
                    prize = 6;
                    break;
                case "Spell3":
                    prize = 7;
                    break;
            }

            _checker.GetSwap(prize, Convert.ToInt32(_count.text));
        }
    }

}
