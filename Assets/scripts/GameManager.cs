using UnityEditor;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;              //Static instance of GameManager which allows it to be accessed by any other script.
    public Canvas Menu;

    public int Level { get; private set; }


    //Awake is always called before any Start functions
    void Awake()
    {
        //Check if instance already exists
        if (instance == null)
        {
            //if not, set instance to this
            instance = this;
        }
        //If instance already exists and it's not this:
        else if (instance != this)
        {
            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);
        }

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);

        //Get a component reference to the attached BoardManager script

        //Call the InitGame function to initialize the first level 
        InitGame();
    }

    //Initializes the game for each level.
    void InitGame()
    {

    }
    
    //Update is called every frame.
    void Update()
    {

    }

    public void ShowMenu()
    {
        var canvasGroup = Menu.GetComponent<CanvasGroup>();
        var panel = Menu.GetComponent<RectTransform>();

        CreateNextLevelButton(panel);

        canvasGroup.alpha = 1;   
    }

    public void ShowFinishMenu()
    {
        //var canvasGroup = Menu.GetComponent<CanvasGroup>();
        //var panel = Menu.GetComponent<RectTransform>();
        //var text = panel.GetComponentInChildren<Text>();

        //text.text = "Yay, Finish!";
        
        //CreateMainMenuButton(panel);
        //CreateNextLevelButton(panel);

        //canvasGroup.alpha = 1;
    }

    public void HideMenu()
    {
        var canvasGroup = Menu.GetComponent<CanvasGroup>();

        canvasGroup.alpha = 0;
    }

    private void CreateMainMenuButton(RectTransform menu)
    {
        var mainMenuButton = menu.gameObject.AddComponent<Button>();
        
        mainMenuButton.GetComponentInChildren<Text>().text = "Main Menu";
        mainMenuButton.onClick.AddListener(ShowMainMenu);
        mainMenuButton.transform.position = new Vector3(0f, 0f, 0f);  
    }

    private void CreateNextLevelButton(RectTransform menu)
    {
        GameObject buttonObject = new GameObject();
        var nextLevelButton = buttonObject.AddComponent<Button>();

        nextLevelButton.GetComponentInChildren<Text>().text = "Next Level";
        nextLevelButton.onClick.AddListener(StartNextLevel);
        nextLevelButton.transform.position = new Vector3(0f, -55f, 0f); 

    }

    private void StartNextLevel()
    {
        Level++;
        Application.LoadLevel("level");
    }

    public void ShowMainMenu()
    {
        Application.LoadLevel("menu");
    }
}
