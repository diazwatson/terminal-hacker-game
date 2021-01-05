using UnityEngine;
using System.Linq;

public class HackerSp : MonoBehaviour
{
    // Game configuration data
    private const string menuHint = "Escribe `menu` para volver el menu.";
    string[] level1Passwords = {"libro", "lapiz", "estante", "estudiante", "cuaderno"};
    string[] level2Passwords = {"policia", "estacion", "alarma", "ladron", "pistola"};
    string[] level3Passwords = {"gobierno", "inteligencia", "agencia", "terrorismo", "conspiracion"};

    int level;

    enum Screen
    {
        MainMenu,
        Password,
        Win
    };

    Screen currentScreen;
    string password;

    // Start is called before the first frame update
    void Start()
    {
        ShowMainMenu("Hello Raul");
    }

    void ShowMainMenu(string greeting = null)
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("Que quieres hackear?");
        Terminal.WriteLine("");
        Terminal.WriteLine("Escribe 1 para la biblioteca local");
        Terminal.WriteLine("Escribe 2 estacion de policia");
        Terminal.WriteLine("Escribe 3 para CNI");
        Terminal.WriteLine("");
        Terminal.WriteLine("Selecciona una opcion: ");
    }

    void OnUserInput(string input)
    {
        if (input == "menu")
        {
            ShowMainMenu();
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }
    }

    void CheckPassword(string input)
    {
        if (input == password)
        {
            DisplayWinScreen();
        }
        else
        {
            Terminal.WriteLine("Invalid password, please try again");
            AskForPassword();
        }
    }

    void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
    }

    void ShowLevelReward()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine("Felicidades, has desbloqueado");
                Terminal.WriteLine("un libro secreto!");
                Terminal.WriteLine(@"
      ______ ______
    _/      Y      \_
   // ~~ ~~ | ~~ ~  \\
  // ~ ~ ~~ | ~~~ ~~ \\
 //________.|.________\\
`----------`-'----------'
");
                break;
            case 2:
                Terminal.WriteLine(@"
Felicidades, super pistola desbloqueada!
 +--^-----,-------,----,--------^-,
 | |||||   `------'     |         O
 `+---------------------^---------|
   `\_,----,--------,-------------'
     / XXXX /'|       /'
    / XXXX /  `\    /'
   / XXXX /`-------'
  (______(                
   `----' 
");
                break;
            case 3:
                Terminal.WriteLine(@"
Felicidades!
 ___,___,____,____ 
|  ...|//./|'|    \ 
|  ...|/.///||     |
|   ____________   |
|  |:::SECRET:::|  |
|  |:::FILES::::|  |
|  |____________|  |
||_|            |  |
!__|____________|__!  
");
                break;
            default:
                Debug.LogError("Invalid level reached");
                break;
        }
        Terminal.WriteLine(menuHint);
    }

    void RunMainMenu(string input)
    {
        string[] swering = {"fuck", "shit", "ssshole", "dick", "bitch", "twat"};

        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3");

        if (isValidLevelNumber)
        {
            level = int.Parse(input);
            AskForPassword();
        }
        else if (swering.Contains(input))
        {
            Terminal.WriteLine("[Warning] Swearing will activate all ");
            Terminal.WriteLine("the alarms and you will be prosecuted!.");
        }
        else if (input == "007")
        {
            Terminal.WriteLine("Please select a level Mr Bond!");
        }
        else
        {
            Terminal.WriteLine("Please select a valid level");
        }
    }

    void AskForPassword()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        SetRandomPassword();
        Terminal.WriteLine("Enter your password, hint: " + password.Anagram());
        Terminal.WriteLine(menuHint);

    }

    void SetRandomPassword()
    {
        switch (level)
        {
            case 1:
                password = level1Passwords[Random.Range(0, level1Passwords.Length)];
                break;
            case 2:
                password = level2Passwords[Random.Range(0, level2Passwords.Length)];
                break;
            case 3:
                password = level3Passwords[Random.Range(0, level3Passwords.Length)];
                break;
            default:
                Debug.LogError("Invalid level number.");
                break;
        }
    }
}