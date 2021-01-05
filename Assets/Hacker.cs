using UnityEngine;
using System.Linq;

public class Hacker : MonoBehaviour
{
    // Game configuration data
    const string menuHint = "You may type `menu` at any time.";
    const string menuHintSp = "Escribe `menu` para volver al menú.";
    string[] level1Passwords = {"book", "pen", "shelve", "student", "notebook"};
    string[] level2Passwords = {"police", "station", "alarm", "thief", "gun"};
    string[] level3Passwords = {"government", "intelligence", "agency", "terrorism", "conspiracy"};
    string[] level1PasswordsSp = {"libro", "lapiz", "estante", "estudiante", "cuaderno"};
    string[] level2PasswordsSp = {"policia", "estacion", "alarma", "ladron", "pistola"};
    string[] level3PasswordsSp = {"gobierno", "inteligencia", "agencia", "terrorismo", "conspiracion"};

    int level;
    string language;

    enum Screen
    {
        Welcome,
        Language,
        MainMenu,
        Password,
        Win
    };

    Screen currentScreen;
    string password;

    // Start is called before the first frame update
    void Start()
    {
        ShowWelcomeScreen();
    }

    void ShowWelcomeScreen()
    {
        currentScreen = Screen.Welcome;
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
        currentScreen = Screen.Language;
        Terminal.ClearScreen();

        Terminal.WriteLine("Select your language:");
        Terminal.WriteLine("");
        Terminal.WriteLine("Press 1 for English");
        Terminal.WriteLine("Presione 2 para Español");
    }

    void ShowMainMenu(string greeting = null)
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        if (language == "en")
        {
            Terminal.WriteLine("What would you like to hack into?");
            Terminal.WriteLine("");
            Terminal.WriteLine("Press 1 for Local Library");
            Terminal.WriteLine("Press 2 for Police Station");
            Terminal.WriteLine("Press 3 for MI5");
            Terminal.WriteLine("");
            Terminal.WriteLine("Enter your selection: ");
        }
        else if (language == "es")
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
        if (input == "start" && currentScreen == Screen.Welcome)
        {
            ShowLanguageMenu();
        }
        else if (currentScreen == Screen.Language)
        {
            if (input == "1")
            {
                language = "en";
                ShowMainMenu();
            }
            else if (input == "2")
            {
                language = "es";
                ShowMainMenu();
            }
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
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
            if (language == "en")
            {
                Terminal.WriteLine("Terminal session ended");
                Terminal.WriteLine("Close this tab to finish.");
            }
            else if (language == "es")
            {
                Terminal.WriteLine("Finalizada la sesión de terminal");
                Terminal.WriteLine("Cierre esta pestaña para terminar.");
            }
            Application.Quit();
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
        if (language == "en")
        {
            switch (level)
            {
                case 1:
                    Terminal.WriteLine("Congratulations, you have unlocked");
                    Terminal.WriteLine("a secret book!");
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
Congratulations, you win!
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
Congratulations, you win!
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
        else if (language == "es")
        {
            switch (level)
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
Desbloqueado archivos secretos!
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

            Terminal.WriteLine(menuHintSp);
        }
    }

    void RunMainMenu(string input)
    {
        string[] swering = {"fuck", "shit", "ssshole", "dick", "bitch", "twat"};

        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3" && currentScreen == Screen.MainMenu);

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
        if (language == "en")
        {
            Terminal.WriteLine("Enter your password, hint: " + password.Anagram());
            Terminal.WriteLine(menuHint);
        }
        else if (language == "es")
        {
            Terminal.WriteLine("Decifra la contraseña: " + "(" + password.Anagram() + ")");
            Terminal.WriteLine("");
            Terminal.WriteLine("");
            Terminal.WriteLine("");
            Terminal.WriteLine(menuHintSp);
        }
    }

    void SetRandomPassword()
    {
        if (language == "en")
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
        else if (language == "es")
        {
            switch (level)
            {
                case 1:
                    password = level1PasswordsSp[Random.Range(0, level1PasswordsSp.Length)];
                    break;
                case 2:
                    password = level2PasswordsSp[Random.Range(0, level2PasswordsSp.Length)];
                    break;
                case 3:
                    password = level3PasswordsSp[Random.Range(0, level3PasswordsSp.Length)];
                    break;
                default:
                    Debug.LogError("Nivel Inválido.");
                    break;
            }
        }
    }
}