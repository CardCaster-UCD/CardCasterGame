using UnityEngine;
using System.Collections.Generic;

public class DeckController : MonoBehaviour
{
    private Stack<ICard> cards;
    public ICard Draw()
    {
        return cards.Pop();
    }
}