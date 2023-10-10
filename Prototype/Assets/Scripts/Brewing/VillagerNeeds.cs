using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class VillagerNeeds : MonoBehaviour
{
    public ShopItem[] desiredPotions;

    public TextMeshProUGUI villagerTextBox;

    public string formatString = "0";
    public string message01 = "Hi there. I'm so fatigued after the town festival last week... What have you got that might restore my spirit?";
    public string message02 = "Fancy seeing you here! I fell down a ravine this morning, do you have anything that can help me?";
    public string message03 = "Thank you! That was exactly what I needed!";
    public string message04 = "Yuck, that isn't what I'm after!";

    private bool waitingForPotion = false;
    private int mostRecentPotion;
    private int choice;
    public int potionsReceived = 0;
    private bool hasChimed;

    private ShopItem currentPotionNeeded;

    public Inventory inv;
    public InventoryUI ui;

    private AudioSource successfulSale;
    private AudioSource unsuccessfulSale;

    private void Start()
    {
        choice = Random.Range(0, desiredPotions.Length);
        PickPotion(choice);

        successfulSale = GameObject.FindGameObjectWithTag("Music").GetComponent<BackgroundMusic>().potionGivenToVillagerSound;
        unsuccessfulSale = GameObject.FindGameObjectWithTag("Music").GetComponent<BackgroundMusic>().rejectionSound;
    }

    private void PickPotion(int choice)
    {
        mostRecentPotion = choice;

        switch (choice)
        {
            case 0:
                villagerTextBox.text = message01;
                currentPotionNeeded = desiredPotions[choice];
                break;

            case 1:
                villagerTextBox.text = message02;
                currentPotionNeeded = desiredPotions[choice];
                break;
        }

        waitingForPotion = true;
    }

    private void Update()
    {
        if (waitingForPotion == false)
        {
            while (mostRecentPotion == choice)
            {
                choice = Random.Range(0, desiredPotions.Length);
            }

            PickPotion(choice);
        }

        if (potionsReceived < 2)
        {
            ConsiderPotion();
        }

        else
        { // Display a grateful message
            villagerTextBox.text = message03;
        }
    }

    public void ConsiderPotion()
    {
        // If the player puts something in the Villager's inventory...
        if (inv.shopItems[0] != null)
        {
            // If the player gave the Villager what they wanted...
            if (inv.shopItems[0] == currentPotionNeeded)
            {
                // 'Delete' the potion
                inv.shopItems[0] = null;

                // Update the UIs of the 'deleted' potion
                ui.GetSlot(0).UpdateItem(inv.shopItems[0]);                

                // Set the Villager as not currently expecting a potion
                waitingForPotion = false;

                potionsReceived++;

                successfulSale.Play();

                return;
            }

            // If the player didn't give the Villager what they want then play an annoyed message
            else if (inv.shopItems[0] != currentPotionNeeded && hasChimed == false)
            {
                villagerTextBox.text = message04;
                unsuccessfulSale.Play();
                hasChimed = true;
                return;
            }
        }

        // If the Villager's inventory has nothing in it then display what they want
        else if (inv.shopItems[0] == null)
        {
            PickPotion(choice);
            hasChimed = false;

            return;
        }
    }
}
