using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    int sortIndex = 0;
    public static GameManager gameManager { get; private set; }
    int round = 0;

    Dictionary<int,Sprite> resumes = new Dictionary<int,Sprite>();
    Dictionary<int,Sprite> yesPile = new Dictionary<int,Sprite>();
    Dictionary<int,Sprite> noPile = new Dictionary<int,Sprite>();

    public List<Sprite> images = new List<Sprite>();
    public List<int> keys = new List<int>();
    public Dictionary<int,Sprite> availableResumes = new Dictionary<int,Sprite>();

    Sprite curResume;
    int curValue;

    [SerializeField] UIManager uiManager;
    [SerializeField] Timer timer;

    int totalScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (gameManager != null && gameManager != this)
        {
            Destroy(this);
        } else
        {
            gameManager = this;
        }
        DontDestroyOnLoad(gameObject);

        int i = 0;
        foreach (Sprite img in images)
        {
            keys.Add(i);
            availableResumes.Add(keys.ElementAt(i), img);
            i++;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetCurrentPair(int key, Sprite sprite)
    {
        curResume = sprite;
        curValue = key;
        uiManager.UpdateResume(curResume);
    }

    public void StartGame()
    {
        round = 1;
        foreach (KeyValuePair<int,Sprite> resume in availableResumes)
        {
            resumes.Add(resume.Key, resume.Value);
        }
        SceneManager.LoadScene("Game");
        Instantiate(uiManager.gameObject);
        Instantiate(timer.gameObject);

        SetCurrentPair(resumes.ElementAt(0).Key, resumes.ElementAt(0).Value);
    }

    public void ResetStack()
    {
        resumes.Clear();
        foreach (KeyValuePair<int,Sprite> yesDoc in yesPile)
        {
            resumes.Add(yesDoc.Key, yesDoc.Value);
        }
        round++;
    }

    public void RejectResume()
    {
        sortIndex++;
        noPile.Add(curValue, curResume);
        SetCurrentPair(resumes.ElementAt(sortIndex).Key, resumes.ElementAt(sortIndex).Value);

        if (sortIndex >= resumes.Count)
        {
            ResetStack();
            sortIndex = 0;
        }

        if (round > 3)
        {
            GoToResults();
            round = 0;
        }
    }

    public void AcceptResume()
    {
        sortIndex++;
        yesPile.Add(curValue, curResume);
        SetCurrentPair(resumes.ElementAt(sortIndex).Key, resumes.ElementAt(sortIndex).Value);
        
        if (sortIndex >= resumes.Count)
        {
            ResetStack();
            sortIndex = 0;
        }

        if (round > 3)
        {
            GoToResults();
            round = 0;
        }
    }

    public void GoToResults()
    {
        DestroyImmediate(uiManager.gameObject, true);
        DestroyImmediate(timer.gameObject, true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
