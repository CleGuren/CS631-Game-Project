using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine.UI;
public class Login : MonoBehaviour
{
    [SerializeField] private AK.Wwise.Event current;
    // button login
    public InputField UsernameInput;
    public InputField PasswordInput;
    public Button LoginButton;

    private GameObject mainObject;
    private string user_id = "";
    private string password = "";
    private MessageQueue msgQueue;
    private ConnectionManager cManager;

    void Awake()
    {
        mainObject = GameObject.Find("Network Manager");
        cManager = mainObject.GetComponent<ConnectionManager>();
        msgQueue = mainObject.GetComponent<MessageQueue>();
        msgQueue.AddCallback(Constants.SMSG_LOGIN, ResponseLogin);
    }

    // Use this for initialization
    void Start()
    {
        LoginButton.onClick.AddListener(() =>
        {
            user_id = UsernameInput.text;
            password = PasswordInput.text;
            LoginButtonClick();
        });
    }

    private void OnDestroy()
    {
        msgQueue.RemoveCallback(Constants.SMSG_LOGIN);
    }

    public void LoginButtonClick()
    {
        var theThing = GameObject.FindGameObjectWithTag("GameMenuMusic");
        Debug.Log("The other game event is: " + theThing + ".");
        Debug.Log("The stored event is: " + GameManager.startMainMusicEvent + ".");
        Destroy(theThing);
        
        user_id = user_id.Trim();
        password = password.Trim();
        if (user_id.Length == 0)
        {
            Debug.Log("User ID Required");
        }
        else if (password.Length == 0)
        {
            Debug.Log("Password Required");
        }
        else
        {
            cManager.send(requestLogin(user_id, password));
        }
    }

    public RequestLogin requestLogin(string username, string password)
    {
        RequestLogin request = new RequestLogin();
        request.send(username, password);
        print(username + ", " + password);
        return request;
    }

    public void ResponseLogin(ExtendedEventArgs eventArgs)
    {
        ResponseLoginEventArgs args = eventArgs as ResponseLoginEventArgs;
        if (args.status == 0)
        {
            Constants.USER_ID = args.player_id;

            Debug.Log("Successful Login response : " + args);
            // EditorUtility.DisplayDialog("Login Successful", "You have successfully logged in." +
            //                                                  "\nClick Ok to continue execution and see responses on console", "Ok");
            //SceneManager.LoadScene("Tutorial");
             //SceneManager.LoadScene("Battle Scene");
             Debug.Log("Current game object: " + gameObject + ".");
             current.Stop(gameObject);
            SceneManager.LoadScene("Town Hub");
           //SceneManager.LoadScene("Test Shop");
        }
        else
        {
            Debug.Log("Login Failed");
        }
    }
}