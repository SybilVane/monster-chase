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

  void OnLevelDidLoad(Scene scene, LoadSceneMode mode)
  {

    if (scene.name == "Gameplay" && SelectedCharacter == "Player1")
    {
      Instantiate(characters[0]);
    }

    if (scene.name == "Gameplay" && SelectedCharacter == "Player2")
    {
      Instantiate(characters[1]);
    }
  }

}
