using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour {

    public Canvas FinishMenu;
    public Canvas PauseMenu;

    public static MenuManager Instance;

    private CanvasGroup pauseMenuGroup;
    private CanvasGroup finishMenuGroup;

    void Awake()
    {
        //Check if instance already exists
        if (Instance == null)
        {
            //if not, set instance to this
            Instance = this;
        }
        //If instance already exists and it's not this:
        else if (Instance != this)
        {
            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);
        }

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);

        pauseMenuGroup = PauseMenu.GetComponent<CanvasGroup>();
        finishMenuGroup = FinishMenu.GetComponent<CanvasGroup>();
    }

    public void ShowBreakMenu()
    {
        pauseMenuGroup.alpha = 1;
    }

    public void HideBreakMenu()
    {
        pauseMenuGroup.alpha = 0;
    }

    public void ShowFinishMenu()
    {
        finishMenuGroup.alpha = 1;
    }

    public void HideFinishMenu()
    {
        finishMenuGroup.alpha = 0;
    }
}
