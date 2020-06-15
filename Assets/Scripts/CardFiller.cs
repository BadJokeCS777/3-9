using UnityEngine;
using UnityEngine.UI;

public class CardFiller : MonoBehaviour
{
    [SerializeField] private Text _prize;
    [SerializeField] private Text _count;

    public void Fill(PrizeData prize)
    {
        _prize.text = prize.Name;
        _count.text = prize.Count.ToString();
    }
}
