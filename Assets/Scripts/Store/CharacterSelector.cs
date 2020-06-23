using UnityEngine;

public class CharacterSelector : MonoBehaviour
{
    private int characterIndex;//0:Wheel, 1:Amy, 2:Michelle
    public GameObject[] characters;

    void Start()
    {
        characterIndex = PlayerPrefs.GetInt("SelectedCharacter", 0);
        foreach(GameObject ch in characters)
        {
            ch.SetActive(false);
        }
        characters[characterIndex].SetActive(true);
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
                if(PlayerPrefs.GetInt("Amy",0) == 1)
                    PlayerPrefs.SetInt("SelectedCharacter", characterIndex);
                break;
            case 2:
                if (PlayerPrefs.GetInt("Michelle", 0) == 1)
                    PlayerPrefs.SetInt("SelectedCharacter", characterIndex);
                break;
        }
    }
}
