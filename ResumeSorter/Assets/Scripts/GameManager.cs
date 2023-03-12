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

    Dictionary<Sprite, int> resumes = new Dictionary<Sprite, int>();
    Dictionary<Sprite, int> yesPile = new Dictionary<Sprite, int>();
    Dictionary<Sprite, int> noPile = new Dictionary<Sprite, int>();

    public List<Sprite> resumesImg = new List<Sprite>();
    public List<int> values = new List<int>();
    public Dictionary<Sprite, int> availableResumes = new Dictionary<Sprite, int>();

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

        foreach (Sprite img in resumesImg)
        {
            availableResumes.Add(img, values.ElementAt(i));
            i++;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetCurrentPair(Sprite curSprite, int curPoints)
    {
        curResume = curSprite;
        curValue = curPoints;
        uiManager.UpdateResume(curResume);
    }

    public void StartGame()
    {
        round = 1;
        foreach (KeyValuePair<Sprite, int> resume in availableResumes)
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
        foreach (KeyValuePair<Sprite, int> yesDoc in yesPile)
        {
            resumes.Add(yesDoc.Key, yesDoc.Value);
        }
        round++;
    }

    public void RejectResume()
    {
        sortIndex++;
        noPile.Add(curResume, curValue);
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
        yesPile.Add(curResume, curValue);
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

        foreach (KeyValuePair<Sprite, int> remained in resumes)
        {
            totalScore += remained.Value;
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
