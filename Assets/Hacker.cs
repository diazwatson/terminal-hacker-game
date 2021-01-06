using UnityEngine;
using System.Linq;

public class Hacker : MonoBehaviour
{
    // Game configuration data
    const string MenuHint = "You may type `menu` at any time.";
    const string MenuHintSp = "Escribe `menu` para volver al menú.";
    readonly string[] _level1Passwords = {"book", "pen", "shelve", "student", "notebook"};
    readonly string[] _level2Passwords = {"police", "station", "alarm", "thief", "gun"};
    readonly string[] _level3Passwords = {"government", "intelligence", "agency", "terrorism", "conspiracy"};
    readonly string[] _level1PasswordsSp = {"libro", "lapiz", "estante", "estudiante", "cuaderno"};
    readonly string[] _level2PasswordsSp = {"policia", "estacion", "alarma", "ladron", "pistola"};
    readonly string[] _level3PasswordsSp = {"gobierno", "inteligencia", "agencia", "terrorismo", "conspiracion"};

    int _level;
    string _language;

    enum Screen
    {
        Welcome,
        Language,
        MainMenu,
        Password,
        Win
    };

    Screen _currentScreen;
    string _password;

    // Start is called before the first frame update
    void Start()
    {
        ShowWelcomeScreen();
    }

    void ShowWelcomeScreen()
    {
        _currentScreen = Screen.Welcome;
        Terminal.ClearScreen();
        Terminal.WriteLine(@"
          ._________________.
          | _______________ |
          | I             I |
          | I             I |
          | I             I |
          | I             I |
          | I_____________I |
          !_________________!
             ._[_______]_.
         .___|___________|___.
         |::: ____ TERMINAL  |
         |    ~~~~ [HACKER]  |
         !___________________!
");
        Terminal.WriteLine("Type `start` to start the game");
    }

    void ShowLanguageMenu()
    {
        _currentScreen = Screen.Language;
        Terminal.ClearScreen();

        Terminal.WriteLine("Select your language:");
        Terminal.WriteLine("");
        Terminal.WriteLine("Press 1 for English");
        Terminal.WriteLine("Presione 2 para Español");
    }

    void ShowMainMenu()
    {
        _currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        if (_language == "en")
        {
            Terminal.WriteLine("What would you like to hack into?");
            Terminal.WriteLine("");
            Terminal.WriteLine("Press 1 for Local Library");
            Terminal.WriteLine("Press 2 for Police Station");
            Terminal.WriteLine("Press 3 for MI5");
            Terminal.WriteLine("");
            Terminal.WriteLine("Enter your selection: ");
        }
        else if (_language == "es")
        {
            Terminal.WriteLine("Que te gustaria hackear?");
            Terminal.WriteLine("");
            Terminal.WriteLine("Escribe 1 para la Biblioteca");
            Terminal.WriteLine("Escribe 2 para la Estación de Policía");
            Terminal.WriteLine("Escribe 3 para la Sede de Gobierno");
            Terminal.WriteLine("");
            Terminal.WriteLine("Introduce tu selección: ");
        }
    }

    void OnUserInput(string input)
    {
        if (input == "start" && _currentScreen == Screen.Welcome)
        {
            ShowLanguageMenu();
        }
        else if (_currentScreen == Screen.Language)
        {
            if (input == "1")
            {
                _language = "en";
                ShowMainMenu();
            }
            else if (input == "2")
            {
                _language = "es";
                ShowMainMenu();
            }
        }
        else if (_currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (_currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }

        if (input == "menu")
        {
            ShowMainMenu();
        }

        if (input == "quit" || input == "exit" || input == "close" || input == "salir" || input == "quitar")
        {
            Terminal.ClearScreen();
            if (_language == "en")
            {
                Terminal.WriteLine("Terminal session ended");
                Terminal.WriteLine("Close this tab to finish.");
            }
            else if (_language == "es")
            {
                Terminal.WriteLine("Finalizada la sesión de terminal");
                Terminal.WriteLine("Cierre esta pestaña para terminar.");
            }
            Application.Quit();
        }
    }

    void CheckPassword(string input)
    {
        if (input == _password)
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
        _currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
    }

    void ShowLevelReward()
    {
        if (_language == "en")
        {
            switch (_level)
            {
                case 1:
                    Terminal.WriteLine("Congratulations, you have unlocked");
                    Terminal.WriteLine("a Secret Book!");
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
Special Gun Unlocked, You Win!
 +--^-----,-------,----,--------^-,
 | |||||   `------'     |         O
 `+---------------------^---------|
   `\_,----,--------,-------------'
    / XXXX /  `\    /'
   / XXXX /`-------'
  (______(                
   `----' 
");
                    break;
                case 3:
                    Terminal.WriteLine(@"
Unlocked Secret Files, You Win!
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

            Terminal.WriteLine(MenuHint);
        }
        else if (_language == "es")
        {
            switch (_level)
            {
                case 1:
                    Terminal.WriteLine("Desbloqueado un libro secreto!");
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
Super arma, desbloqueada!
 +--^-----,-------,----,--------^-,
 | |||||   `------'     |         O
 `+---------------------^---------|
   `\_,----,--------,-------------'
    / XXXX /  `\    /'
   / XXXX /`-------'
  (______(                
   `----' 
");
                    break;
                case 3:
                    Terminal.WriteLine(@"
Desbloqueado Archivos Secretos!
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

            Terminal.WriteLine(MenuHintSp);
        }
    }

    void RunMainMenu(string input)
    {
        string[] swering = {"fuck", "shit", "ssshole", "dick", "bitch", "twat"};

        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3" && _currentScreen == Screen.MainMenu);

        if (isValidLevelNumber)
        {
            _level = int.Parse(input);
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
        _currentScreen = Screen.Password;
        Terminal.ClearScreen();
        SetRandomPassword();
        if (_language == "en")
        {
            Terminal.WriteLine("Enter your password, hint: " + _password.Anagram());
            Terminal.WriteLine(MenuHint);
        }
        else if (_language == "es")
        {
            Terminal.WriteLine("Decifra la contraseña: " + "(" + _password.Anagram() + ")");
            Terminal.WriteLine("");
            Terminal.WriteLine("");
            Terminal.WriteLine("");
            Terminal.WriteLine(MenuHintSp);
        }
    }

    void SetRandomPassword()
    {
        if (_language == "en")
        {
            switch (_level)
            {
                case 1:
                    _password = _level1Passwords[Random.Range(0, _level1Passwords.Length)];
                    break;
                case 2:
                    _password = _level2Passwords[Random.Range(0, _level2Passwords.Length)];
                    break;
                case 3:
                    _password = _level3Passwords[Random.Range(0, _level3Passwords.Length)];
                    break;
                default:
                    Debug.LogError("Invalid level number.");
                    break;
            }
        }
        else if (_language == "es")
        {
            switch (_level)
            {
                case 1:
                    _password = _level1PasswordsSp[Random.Range(0, _level1PasswordsSp.Length)];
                    break;
                case 2:
                    _password = _level2PasswordsSp[Random.Range(0, _level2PasswordsSp.Length)];
                    break;
                case 3:
                    _password = _level3PasswordsSp[Random.Range(0, _level3PasswordsSp.Length)];
                    break;
                default:
                    Debug.LogError("Nivel Inválido.");
                    break;
            }
        }
    }
}