using UnityEngine;
using System.Collections.Generic;

public class DiscardController
{
    private List<ICard> cards;
    public DiscardController()
    {
        cards = new List<ICard>();
    }
    public void Add(ICard card)
    {
        cards.Add(card);
    }

    public List<ICard> GetPile()
    {        
        // Return contents of discard pile.
        // Will be emptied in the shuffle method.
        return cards;
    }
}