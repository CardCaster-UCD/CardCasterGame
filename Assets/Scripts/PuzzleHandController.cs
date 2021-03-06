using UnityEngine;
using UnityEngine.UIElements;

public class PuzzleHandController : MonoBehaviour
{
    private VisualElement slot1;
    private VisualElement slot2;
    private VisualElement slot3;
    
    public ICard card1;
    private ICard card2;
    private ICard card3;
    private GameObject player;
    private PlayerController player_ctrl;
    private bool initialized;
    private bool isBufferActive;
    private float maxBufferTime = 0.25f;
    private float curBufferTime;

    void OnEnable()
    {
        if(!initialized)
        {
            player = GameObject.FindWithTag("Player");
            player_ctrl = player.GetComponent<PlayerController>();
            var rootVisualElement = GetComponent<UIDocument>().rootVisualElement;
            
            // Cards needed to complete puzzle.
            card1 = ScriptableObject.CreateInstance<FireballCard>();
            card2 = ScriptableObject.CreateInstance<WindBlastCard>();
            
            // Third slot could be anything for this puzzle.
            card3 = ScriptableObject.CreateInstance<ShieldCard>();
            
            slot1 = rootVisualElement.Q<VisualElement>("Card-Slot1");
            slot2 = rootVisualElement.Q<VisualElement>("Card-Slot2");
            slot3 = rootVisualElement.Q<VisualElement>("Card-Slot3");
            
            initialized = true;
        }
        
        // Change the UI.
        this.SetSlot(1);
        this.SetSlot(2);
        this.SetSlot(3);
    }
    void Update()
    {  
        if (isBufferActive)
        {
            // Increment the amount of time the buffer has been active.
            curBufferTime += Time.deltaTime;
            if(curBufferTime >= maxBufferTime) {
                // Deactivate the buffer.
                isBufferActive = false;
                // Reset Buffer time.
                curBufferTime = 0.0f;
            }
        }

        // Handle inputs.
        // Call execute of card if input pressed.
        if (!isBufferActive)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1) && player_ctrl.GetCurMana() > card1.GetCost())
            {
                // Activate the Buffer.
                isBufferActive = true;
                // Pay the Mana for the Card.
                player_ctrl.SpendMana(card1.GetCost());
                // Activate the Card.
                card1.Execute(this.player);
            }
            if (Input.GetKeyDown(KeyCode.Alpha2) && player_ctrl.GetCurMana() > card1.GetCost())
            {
                // Activate the Buffer.
                isBufferActive = true;
                // Pay the Mana for the Card.
                player_ctrl.SpendMana(card2.GetCost());
                // Activate the Card.              
                card2.Execute(this.player);
            }
            if (Input.GetKeyDown(KeyCode.Alpha3) && player_ctrl.GetCurMana() > card1.GetCost())
            {
                // Activate the Buffer.
                isBufferActive = true;
                // Pay the Mana for the Card.
                player_ctrl.SpendMana(card3.GetCost());
                // Activate the Card.
                card3.Execute(this.player);
            }
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