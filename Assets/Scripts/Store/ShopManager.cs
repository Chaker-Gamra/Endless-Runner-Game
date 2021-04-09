using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class ShopManager : MonoBehaviour
{
    public ShopElement[] characters;

    public int characterIndex;//0:Wheel, 1:Amy, 2:Michelle ...
    public GameObject[] shopCharacters;

    public GameObject rewardMenu;
    public TextMeshProUGUI rewardText;
    public GameObject mainMenu;

    public Button buyButton;
    public Button adButton;

    void Start()
    {
        //Load the isLocked data for each character
        foreach(ShopElement c in characters)
        {
            if (c.price != 0)
                c.isLocked = PlayerPrefs.GetInt(c.name, 1) == 1 ? true : false;
        }

        characterIndex = PlayerPrefs.GetInt("SelectedCharacter", 0);
        foreach (GameObject ch in shopCharacters)
        {
            ch.SetActive(false);
        }

        shopCharacters[characterIndex].SetActive(true);

        UpdateUI();
    }

   
    public void ChangeNextCharacter()
    {
        shopCharacters[characterIndex].SetActive(false);

        characterIndex++;
        if (characterIndex == characters.Length)
            characterIndex = 0;

        shopCharacters[characterIndex].SetActive(true);

        UpdateUI();

        bool isLocked = characters[characterIndex].isLocked;
        if (isLocked)
            return;

        PlayerPrefs.SetInt("SelectedCharacter", characterIndex);
    }

    public void ChangePreviousCharacter()
    {
        shopCharacters[characterIndex].SetActive(false);

        characterIndex--;
        if (characterIndex == -1)
            characterIndex = characters.Length - 1;

        shopCharacters[characterIndex].SetActive(true);

        UpdateUI();

        bool isLocked = characters[characterIndex].isLocked;
        if (isLocked)
            return;

        PlayerPrefs.SetInt("SelectedCharacter", characterIndex);
    }

    public void RewardWithAD()
    {
        if(characterIndex == 1)
        {
            characters[characterIndex].isLocked = false;
            PlayerPrefs.SetInt(characters[characterIndex].name, 0);
            PlayerPrefs.SetInt("SelectedCharacter", characterIndex);
        }
        else
        {
            int randomReward = Random.Range(100, 251);
            PlayerPrefs.SetInt("TotalGems", PlayerPrefs.GetInt("TotalGems") + randomReward);
            rewardText.text = "You Have Earned " + randomReward;
            rewardMenu.SetActive(true);
            mainMenu.SetActive(false);
        }
        UpdateUI();

    }

    public void UnlockWithGems()
    {
        ShopElement c = characters[characterIndex];
        if (PlayerPrefs.GetInt("TotalGems", 0) < c.price)
            return;

        int newGems = PlayerPrefs.GetInt("TotalGems", 0) - characters[characterIndex].price;
        PlayerPrefs.SetInt("TotalGems", newGems);

        c.isLocked = false;
        PlayerPrefs.SetInt(c.name, 0);
        PlayerPrefs.SetInt("SelectedCharacter", characterIndex);

        UpdateUI();
    }

    private void UpdateUI()
    {
        ShopElement c = characters[characterIndex];

        if (c.isLocked)
        {
            adButton.gameObject.SetActive(true);
            adButton.interactable = true;

            buyButton.gameObject.SetActive(true);
            buyButton.GetComponentInChildren<TextMeshProUGUI>().text = c.price + "";

            if (PlayerPrefs.GetInt("TotalGems", 0) < c.price)
                buyButton.interactable = false;
            else
                buyButton.interactable = true;
        }
        else
        {
            adButton.gameObject.SetActive(false);
            buyButton.gameObject.SetActive(false);
        }
            
    }
}
