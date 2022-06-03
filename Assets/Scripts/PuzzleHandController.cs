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
    private bool initialized;

    void OnEnable()
    {
        if(!initialized)
        {
            player = GameObject.FindWithTag("Player");
            var rootVisualElement = GetComponent<UIDocument>().rootVisualElement;
            
            // Cards needed to complete puzzle.
            card1 = ScriptableObject.CreateInstance<FireballCard>();
            card2 = ScriptableObject.CreateInstance<WindBlastCard>();
            card3 = ScriptableObject.CreateInstance<HealUpCard>();
            // card3 = ScriptableObject.CreateInstance<ShieldCard>();
            // card3 = ScriptableObject.CreateInstance<AttackUpCard>();
            //card3 = ScriptableObject.CreateInstance<SpeedupCard>();
            
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