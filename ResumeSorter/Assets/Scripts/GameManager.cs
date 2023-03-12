using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager { get; private set; }

    Dictionary<Sprite, int> resumes = new Dictionary<Sprite, int>();
    Dictionary<Sprite, int> yesPile = new Dictionary<Sprite, int>();
    Dictionary<Sprite, int> noPile = new Dictionary<Sprite, int>();

    public List<Sprite> resumesImg = new List<Sprite>();
    public Dictionary<Sprite, int> availableResumes;

    [SerializeField] UIManager uiManager;

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
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        foreach (KeyValuePair<Sprite, int> resume in availableResumes)
        {
            resumes.Add(resume.Key, resume.Value);
        }
        SceneManager.LoadScene("Game");
        Instantiate(uiManager);
    }

    public void RejectResume()
    {

    }

    public void AcceptResume()
    {

    }
}
