using UnityEngine.UI;
using UnityEngine;

public class CharacterSelector : MonoBehaviour
{
    private int characterIndex;//0:Wheel, 1:Amy, 2:Michelle
    public GameObject[] characters;

    public Button amyButton;
    public Button michelleButton;

    void Start()
    {
        characterIndex = PlayerPrefs.GetInt("SelectedCharacter", 0);
        foreach(GameObject ch in characters)
        {
            ch.SetActive(false);
        }
        characters[characterIndex].SetActive(true);

        UpdateBuyButtons();
    }
    
    public void ChangeNextCharacter()
    {
        characters[characterIndex].SetActive(false);

        characterIndex++;
        if (characterIndex == 3)
            characterIndex = 0;

        characters[characterIndex].SetActive(true);

        switch (characterIndex)
        {
            case 0:
                PlayerPrefs.SetInt("SelectedCharacter", characterIndex);
                break;
            case 1:
                if(PlayerPrefs.GetInt("IsAmyUnlocked",0) == 1)
                {
                    amyButton.gameObject.SetActive(false);
                    PlayerPrefs.SetInt("SelectedCharacter", characterIndex);
                    
                }else
                    amyButton.gameObject.SetActive(true);
                
                break;
            case 2:
                if (PlayerPrefs.GetInt("IsMichelleUnlocked", 0) == 1)
                {
                    michelleButton.gameObject.SetActive(false);
                    PlayerPrefs.SetInt("SelectedCharacter", characterIndex);

                }
                else
                    michelleButton.gameObject.SetActive(true);
                break;

        }

    }
    public void UpdateBuyButtons()
    {
        if (PlayerPrefs.GetInt("IsAmyUnlocked", 0) == 0)
        {
            amyButton.gameObject.SetActive(true);
            if (PlayerPrefs.GetInt("Coins", 0) >= 500)
                amyButton.interactable = true;
            else
                amyButton.interactable = false;
        }else
            amyButton.gameObject.SetActive(false);

        if (PlayerPrefs.GetInt("IsMichelleUnlocked", 0) == 0)
        {
            michelleButton.gameObject.SetActive(true);
            if (PlayerPrefs.GetInt("Coins", 0) >= 800)
                michelleButton.interactable = true;
            else
                michelleButton.interactable = false;
        }
        else
            michelleButton.gameObject.SetActive(false);

    }

    public void UnlockAmy()
    {
        PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - 500);
        PlayerPrefs.SetInt("IsAmyUnlocked", 1);
        amyButton.gameObject.SetActive(false);
        PlayerPrefs.SetInt("SelectedCharacter", 1);
    }

    public void UnlockMichelle()
    {
        PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - 800);
        PlayerPrefs.SetInt("IsMichelleUnlocked", 1);
        michelleButton.gameObject.SetActive(false);
        PlayerPrefs.SetInt("SelectedCharacter", 2);
    }
}
