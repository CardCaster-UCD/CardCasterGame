using UnityEngine;
using System.Collections.Generic;

public class DeckController
{
    private Stack<ICard> cards;
    private DiscardController discard;
    public ICard Draw()
    {
        // If no more cards, refill from discard pile and shuffle.
        if(cards.Count == 0)
        {
            Shuffle(discard.GetPile());
        }
        return cards.Pop();
    }

    public void Initialize(DiscardController discard)
    {
        cards = new Stack<ICard>();
        this.discard = discard;
        
        var tempCards = new List<ICard>{
            ScriptableObject.CreateInstance<FireballCard>(),
            ScriptableObject.CreateInstance<FireStormCard>(),
            ScriptableObject.CreateInstance<SpeedupCard>(),
            ScriptableObject.CreateInstance<WindBlastCard>(),
            ScriptableObject.CreateInstance<HealUpCard>(),
            ScriptableObject.CreateInstance<ShieldCard>(),
            ScriptableObject.CreateInstance<AttackUpCard>()
    };

        Shuffle(tempCards);
    }

    public void Shuffle(List<ICard> newCards)
    {
        while(newCards.Count > 0)
        {
            var cardIndex = Random.Range(0, newCards.Count);


            // Reactivate card before putting it back in draw pile.
            newCards[cardIndex].SetActive();
            
            // Add random card from list to top of deck
            cards.Push(newCards[cardIndex]);

            // Remove reference from list
            newCards.RemoveAt(cardIndex);
        }
    }
}