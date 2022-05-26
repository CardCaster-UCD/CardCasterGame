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
    
    public ICard card1;
    private ICard card2;
    private ICard card3;
    private GameObject player;

    
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        //deckController = this.deck.GetComponent<DeckController>();
        //discardController = this.discardPile.GetComponent<DiscardController>();

        //TODO reaplace this with drawing
        card1 = ScriptableObject.CreateInstance<FireballCard>();
        card2 = ScriptableObject.CreateInstance<SpikeStormCard>();
        card3 = ScriptableObject.CreateInstance<FireballCard>();

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
            if(card1.GetSprite())
            {
                slot1.GetComponent<SpriteRenderer>().sprite = card1.GetSprite();
            }
        }

        if (!card2.GetIsActive()) {
            // The card is No Longer Active, so Send it to the DiscardPile.
            discardController.Add(card2);

            // Draw a new card from Deck.
            card2 = deckController.Draw();

            // Change sprite for slot.
            if(card2.GetSprite())
            {
                slot2.GetComponent<SpriteRenderer>().sprite = card2.GetSprite();
            }
        }

        if (!card3.GetIsActive()) {
            // The card is No Longer Active, so Send it to the DiscardPile.
            discardController.Add(card3);

            // Draw a new card from Deck.
            card3 = deckController.Draw();

            // Change sprite for slot.
            if(card3.GetSprite())
            {
                slot3.GetComponent<SpriteRenderer>().sprite = card3.GetSprite();
            }
        }
        
        // Handle inputs.
        // Call execute of card if input pressed.
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            this.card1.Execute(this.player);
            Debug.Log("1");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            this.card2.Execute(this.player);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            this.card3.Execute(this.player);
        }

    }
    
}