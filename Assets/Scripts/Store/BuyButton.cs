using UnityEngine;
using UnityEngine.UI;

public class BuyButton : MonoBehaviour
{
    public string characterName;
    public int index;
    public int price;

    private void Update()
    {
        int isUnlocked = PlayerPrefs.GetInt(characterName, 0);//0:false , 1:true
        if (isUnlocked == 0)
        {
            gameObject.SetActive(true);
            if (PlayerPrefs.GetInt("Coins", 0) < price)
                GetComponent<Button>().interactable = false;
            else
                GetComponent<Button>().interactable = true;
        }else
            gameObject.SetActive(false);
    }

    public void Unlock()
    {
        if (PlayerPrefs.GetInt("Coins",0) < price)
            return;

        PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins",0) - price);
        PlayerPrefs.SetInt(characterName, 1);
        PlayerPrefs.SetInt("SelectedCharacter", index);
    }
}
