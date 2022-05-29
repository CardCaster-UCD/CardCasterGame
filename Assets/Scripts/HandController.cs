using UnityEngine;
using UnityEngine.UIElements;

public class HandController : MonoBehaviour
{
    //[SerializeField] private GameObject deck;
    //[SerializeField] private GameObject discardPile;
    // Remove this later
    [SerializeField] private Texture2D c;

    private VisualElement slot1;
    private VisualElement slot2;
    private VisualElement slot3;
    private DeckController deckController;
    private DiscardController discardController;
    
    public ICard card1;
    private ICard card2;
    private ICard card3;
    private GameObject player;

    
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        deckController = new DeckController();
        discardController = new DiscardController();
        deckController.Initialize(discardController);

        card1 = deckController.Draw();
        card2 = deckController.Draw();
        card3 = deckController.Draw();

        var rootVisualElement = GetComponent<UIDocument>().rootVisualElement;
        slot1 = rootVisualElement.Q<VisualElement>("Card-Slot1");
        this.SetSlot(1);
        slot2 = rootVisualElement.Q<VisualElement>("Card-Slot2");
        this.SetSlot(2);
        slot3 = rootVisualElement.Q<VisualElement>("Card-Slot3");
        this.SetSlot(3);
    }
    void Update()
    {
        // Check if needs to draw.
        if (!card1.GetIsActive()) {
            // The card is No Longer Active, so Send it to the DiscardPile.
            discardController.Add(card1);

            // Draw a new card from Deck.
            card1 = deckController.Draw();
            
            this.SetSlot(1);
        }

        if (!card2.GetIsActive()) {
            // The card is No Longer Active, so Send it to the DiscardPile.
            discardController.Add(card2);

            // Draw a new card from Deck.
            card2 = deckController.Draw();

           this.SetSlot(2);
        }

        if (!card3.GetIsActive()) {
            // The card is No Longer Active, so Send it to the DiscardPile.
            discardController.Add(card3);

            // Draw a new card from Deck.
            card3 = deckController.Draw();

            this.SetSlot(3);
        }
        
        // Handle inputs.
        // Call execute of card if input pressed.
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            this.card1.Execute(this.player);
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
    private void SetSlot(int slot)
    {
        switch(slot)
        {
            case 1:
                slot1.style.backgroundImage = card1.GetImage();
                break;
            case 2:
                slot2.style.backgroundImage = card2.GetImage();
                break;
            case 3:
                slot3.style.backgroundImage = card3.GetImage();
                break;
        }
    }
    
}