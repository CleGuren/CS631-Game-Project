using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine.UI;
public class Registration : MonoBehaviour
{
    // button login
    public InputField UsernameInput;
    public InputField PasswordInput;
    public Button RegisterButton;

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
        msgQueue.AddCallback(Constants.SMSG_REGISTER, ResponseRegistration);
    }

    // Use this for initialization
    void Start()
    {
        RegisterButton.onClick.AddListener(() =>
        {
            user_id = UsernameInput.text;
            password = PasswordInput.text;
            RegistrationButtonClick();
        });
    }

    private void OnDestroy()
    {
        msgQueue.RemoveCallback(Constants.SMSG_REGISTER);
    }

    public void RegistrationButtonClick()
    {
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
            cManager.send(requestRegistration(user_id, password));
        }
    }

    public RequestRegistration requestRegistration(string username, string password)
    {
        RequestRegistration request = new RequestRegistration();
        request.send(username, password);
        return request;
    }

    public void ResponseRegistration(ExtendedEventArgs eventArgs)
    {
        ResponseRegistrationEventArgs args = eventArgs as ResponseRegistrationEventArgs;
        if (args.status == 1) // status needs to be changed to reflect that the user cannot be created
                              // 1 for fail, 0 for success
        {
            Debug.Log("Unsuccessful Registration response : " + args);
            // EditorUtility.DisplayDialog("Registration unsuccessful", "Sorry, please try another username." +
            //                                                  "\nClick Ok to continue execution and see responses on console", "Ok");
        }
        else
        {
            // send the request to the backend for creation of a new user and password
            // TODO 
            Debug.Log("Registration Successful");
            SceneManager.LoadScene("LoginScene");
        }
    }
}
