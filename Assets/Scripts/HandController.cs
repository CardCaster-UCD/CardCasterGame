using UnityEngine;

public class HandController : MonoBehaviour
{
    [SerializeField] private GameObject deck;
    [SerializeField] private GameObject discardPile;
    [SerializeField] private GameObject slot1;
    [SerializeField] private GameObject slot2;
    [SerializeField] private GameObject slot3;
    private DeckController deckController;
    private DiscardController discardController;
    
    private ICard card1;
    private ICard card2;
    private ICard card3;
    private GameObject player;

    void Start()
    {
        this.player = GameObject.FindWithTag("Player");
        deckController = this.deck.GetComponent<DeckController>();
        discardController = this.discardPile.GetComponent<DiscardController>();
    }
    void Update()
    {
        // Check if needs to draw.
        if (!card1.GetIsActive()) {
            // The card is No Longer Active, so Send it to the DiscardPile.
            discardController.Add(card1);

            // Draw a new card from Deck.
            card1 = deckController.Draw();
            
            // Change sprite for slot.
            slot1.GetComponent<SpriteRenderer>().sprite = card1.GetSprite();
        }

        if (!card2.GetIsActive()) {
            // The card is No Longer Active, so Send it to the DiscardPile.
            discardController.Add(card2);

            // Draw a new card from Deck.
            card2 = deckController.Draw();

            // Change sprite for slot.
            slot2.GetComponent<SpriteRenderer>().sprite = card2.GetSprite();
        }

        if (!card3.GetIsActive()) {
            // The card is No Longer Active, so Send it to the DiscardPile.
            discardController.Add(card3);

            // Draw a new card from Deck.
            card3 = deckController.Draw();

            // Change sprite for slot.
            slot3.GetComponent<SpriteRenderer>().sprite = card3.GetSprite();
        }
        
        // Handle inputs.
        // Call execute of card if input pressed.
        if (Input.GetButtonDown("1"))
        {
            this.card1.Execute(this.player);
        }
        if (Input.GetButtonDown("2"))
        {
            this.card2.Execute(this.player);
        }
        if (Input.GetButtonDown("3"))
        {
            this.card3.Execute(this.player);
        }

    }
}