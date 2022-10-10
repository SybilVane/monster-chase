using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
  public static GameManager instance;

  [SerializeField]
  private GameObject[] characters;

  private string _selectedCharacter;
  public string SelectedCharacter
  {
    get { return _selectedCharacter; }
    set { _selectedCharacter = value; }
  }

  private void Awake()
  {
    if (instance == null)
    {
      instance = this;
      DontDestroyOnLoad(gameObject);
    }
    else Destroy(gameObject);

  }

  private void OnEnable()
  {
    SceneManager.sceneLoaded += OnLevelDidLoad;
  }

  private void OnDisable()
  {
    SceneManager.sceneLoaded -= OnLevelDidLoad;
  }

  int characterIndex;
  void OnLevelDidLoad(Scene scene, LoadSceneMode mode)
  {
    if (scene.name == "Gameplay")
    {
      for (int i = 0; i < characters.Length; i++)
      {
        if (characters[i].name == SelectedCharacter) characterIndex = i;
      }
      Instantiate(characters[characterIndex]);
    }
  }

}
