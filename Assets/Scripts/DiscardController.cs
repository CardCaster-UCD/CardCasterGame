using UnityEngine;
using System.Collections.Generic;

public class DiscardController : MonoBehaviour
{
    // TODO Decided whether this should be stack or list.
    private Stack<ICard> cards;
    public void Add(ICard card)
    {
        cards.Push(card);
    }

    public void Transfer(DeckController deckController)
    {

    }
}