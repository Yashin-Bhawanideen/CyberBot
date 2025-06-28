using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using NAudio.Wave;

namespace CyberBotGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string userName = "";
        private bool askedName = false;

        // Quiz and logging data
        private List<string> activityLog = new();
        private List<string> addedTasks = new();
        private string[] greeting = { "How are you?", "how are you?", "how are you", "how are u", "how are u?" };
        private string[] availableTasks = { "1. Setup two factor authentication", "2. Review privacy settings", "3. Change password" };
        private string[] addTask = { "add task", "add a task", "add new task" };
        private string[] showTask = { "show tasks", "show added tasks", "show me added tasks" };
        private string[] reminder = { "remind me", "set a reminder", "set reminder" };

        private string[] thanks = { "thank you", "thanks", "thank you very much", "thanks a lot", "thank you so much" };
        private string[] question1 = { "what is your purpose", "what can i ask you about" };
        private string[] emotion = { "worried", "concerned", "scared", "nervous", "anxious", "afraid", "uneasy" };


        //keywords

        //dictionary to store the questions and answers + if the user doesn't understand further explaination is added
        // (geek4geeks, 2025)
        /*geek4geeks, 2025. C# ListDictionary Class. [Online] 
        Available at: https://www.geeksforgeeks.org/c-sharp-listdictionary-class/
        */
        private Dictionary<string, string> keywordResponses = new()
        {
            {"password", "A string of characters used to verify identity during authentication."},
            {"scam", "A dishonest plan to trick people and steal their money or info."},
            {"privacy", "Control over who can access your personal data."},
            {"safe browsing", "Practices that help you avoid online threats like phishing or malware."}
        };

       

        //phishing tips

        /* (geek4geeks, 2025)
         * geek4geeks, 2025. C# List Class. [Online] 
           Available at: https://www.geeksforgeeks.org/c-sharp-list-class/
         */
        private List<string> phishingTips = new()
        {
            "Add spam filters to your email.",
            "Verify email senders before clicking links.",
            "Use two-factor authentication.",
            "Avoid sharing info over email.",
            "Be cautious of unsolicited messages."
        };

        //main window interaction
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Load;
        }

        //plays the audio file
        private async void MainWindow_Load(object sender, RoutedEventArgs e)
        {
            PlayAudio(@"C:\Users\Yashin\Documents\Modules\year 2\Prog C#\ChatBot_POE\CyberBot\CyberBot\bin\Debug\net8.0\Bot.wav");

            await TypeBotText("Hello, Welcome to the Cyber Security Awareness Bot. I'm here to help you stay safe online.");
            await TypeBotText("Bot: Before we begin, I would like to know your Name. Please enter your Name below: ");
            askedName = true;
        }


        private async void SendButton_Click(object sender, RoutedEventArgs e)
        {
            string input = UserInput.Text.Trim();
            UserInput.Clear();

            if (string.IsNullOrWhiteSpace(input)) return;

            AppendText($"You: {input}\n");

            if (askedName && string.IsNullOrEmpty(userName))
            {
                userName = input;
                await TypeBotText($"\nIt is a pleasure to meet you, {userName}.\n");
                await TypeBotText("I am open to any question that you would like to ask...\nType 'quit' or 'exit' to end the conversation.\n");
            }
            else
            {
                await ProcessInput(input);
            }
        }

        //method handles all input prompts
        private async Task ProcessInput(string userInput)
        {
            userInput = Regex.Replace(userInput.Trim(), @"\s+", " ");
            activityLog.Add(userInput);

            if (string.IsNullOrWhiteSpace(userInput))
            {
                await TypeBotText("Bot: Please enter a message or question.\n");
                return;
            }
            if (userInput.Equals("exit", StringComparison.OrdinalIgnoreCase) || userInput.Equals("quit", StringComparison.OrdinalIgnoreCase))
            {

                await TypeBotText("Bot: Goodbye, stay safe online!\n");
                Application.Current.Shutdown();
                return;
            }

            bool matched = false;

            //thanking 
            foreach (string thank in thanks)
            {
                if (userInput.Equals(thank, StringComparison.OrdinalIgnoreCase))
                {
                    await TypeBotText("Bot: You're welcome! If you need to ask anything else I am still here to help.\n");
                    matched = true;
                    break;
                }
            }
            // Purpose question
            if (!matched && userInput.Equals(question1[0], StringComparison.OrdinalIgnoreCase))
            {
                await TypeBotText("Bot: I'm here to assist you in understanding various ways to protect yourself from cyber threats.\n");
                await TypeBotText("Bot: You can ask me about passwords, phishing, privacy, or safe browsing.\n");
                matched = true;
            }
            else if (!matched && userInput.Equals(question1[1], StringComparison.OrdinalIgnoreCase))
            {
                await TypeBotText("Bot: I can give you summarized explanations about cyber security topics.\n");
                matched = true;
            }
            // Keyword dictionary responses
            foreach (string keyword in keywordResponses.Keys)
            {
                if (userInput.ToLower().Contains(keyword.ToLower()))
                {
                    await TypeBotText($"Bot: {keywordResponses[keyword]}\n");
                    matched = true;
                    break;
                }
            }
            // If user doesn't understand
            if (!matched && (userInput.Contains("don't understand", StringComparison.OrdinalIgnoreCase) ||
                             userInput.Contains("please explain", StringComparison.OrdinalIgnoreCase)))
            {
                await TypeBotText("Bot: What would you like me to explain?\n- Passwords\n- Scams\n- Safe browsing\n- Privacy\n");

                // Prompt follow-up via input box
                var explanationPrompt = Microsoft.VisualBasic.Interaction.InputBox("What topic do you want explained?", "Need Clarification", "passwords");

                string followUp = explanationPrompt.ToLower().Trim();

                switch (followUp)
                {
                    case "passwords":
                        await TypeBotText("Bot: Passwords are used to protect personal information. Always use strong, unique ones.\n");
                        break;
                    case "scams":
                        await TypeBotText("Bot: Scammers try to trick you into giving up money or data. Be cautious of unknown requests.\n");
                        break;
                    case "safe browsing":
                        await TypeBotText("Bot: Safe browsing helps you avoid malware and dangerous websites.\n");
                        break;
                    case "privacy":
                        await TypeBotText("Bot: Privacy keeps your personal information secure and out of the wrong hands.\n");
                        break;
                    default:
                        await TypeBotText("Bot: Sorry, I couldn't recognize that option.\n");
                        break;
                }
                matched = true;
            }
            // Sentiment/emotion handling
            foreach (string emo in emotion)
            {
                if (userInput.ToLower().Contains(emo.ToLower()))
                {
                    await TypeBotText("Bot: It's understandable to feel that way. I can share tips on staying safe online if you’d like.\n");
                    matched = true;
                    break;
                }
            }
            // Phishing tip (randomized)
            if (!matched && userInput.ToLower().Contains("phishing tip"))
            {
                Random rand = new Random();
                int index = rand.Next(phishingTips.Count);
                await TypeBotText($"Bot: {phishingTips[index]}\n");
                matched = true;
            }

            //greeting
            foreach (string greet in greeting)
            {
                if (userInput.Equals(greet, StringComparison.OrdinalIgnoreCase))
                {
                    await TypeBotText("Bot: I am doing well, thank you for asking. How can I assist you today?\n");
                    return;
                }
            }
           
            
           
            // Add Task
            if (!matched && addTask.Any(tsk => userInput.Contains(tsk, StringComparison.OrdinalIgnoreCase)))
            {
                await TypeBotText("Bot: Please enter the number of the task you would like to add:\n");

                for (int i = 0; i < availableTasks.Length; i++)
                {
                    await TypeBotText($"{availableTasks[i]}\n");
                }

                string taskNo = Microsoft.VisualBasic.Interaction.InputBox("Enter task number (1-3):", "Add Task", "1").Trim();

                switch (taskNo)
                {
                    case "1":
                        await TypeBotText("Bot: Two-factor authentication task added.\n");
                        addedTasks.Add("Set-up two factor authentication");
                        break;
                    case "2":
                        await TypeBotText("Bot: Privacy settings task added.\n");
                        addedTasks.Add("Review privacy settings");
                        break;
                    case "3":
                        await TypeBotText("Bot: Password change task added.\n");
                        addedTasks.Add("Change password");
                        break;
                    default:
                        await TypeBotText("Bot: Invalid selection.\n");
                        break;
                }
                matched = true;
            }

            // Show Tasks
            if (!matched && showTask.Any(shw => userInput.Contains(shw, StringComparison.OrdinalIgnoreCase)))
            {
                if (addedTasks.Count > 0)
                {
                    await TypeBotText("Bot: Here are your added tasks:\n");
                    foreach (var task in addedTasks)
                    {
                        await TypeBotText($"- {task}\n");
                    }
                }
                else
                {
                    await TypeBotText("Bot: You have no added tasks yet.\n");
                }
                matched = true;
            }
            // Reminder
            if (!matched && reminder.Any(r => userInput.Contains(r, StringComparison.OrdinalIgnoreCase)))
            {
                string date = ExtractTimePhrase(userInput);

                if (userInput.Contains("two factor authentication", StringComparison.OrdinalIgnoreCase))
                {
                    await TypeBotText($"Bot: Reminder set for 'set-up two factor authentication' at {date}.\n");
                }
                else if (userInput.Contains("review privacy settings", StringComparison.OrdinalIgnoreCase))
                {
                    await TypeBotText($"Bot: Reminder set for 'review privacy settings' at {date}.\n");
                }
                else if (userInput.Contains("change password", StringComparison.OrdinalIgnoreCase) ||
                         userInput.Contains("password", StringComparison.OrdinalIgnoreCase))
                {
                    await TypeBotText($"Bot: Reminder set for 'change password' at {date}.\n");
                }
                else
                {
                    await TypeBotText("Bot: Please specify which task to set a reminder for.\n");
                }

                matched = true;
            }

            // Quiz
            if (!matched && userInput.Contains("quiz"))
            {
                await TypeBotText("Bot: Sure thing, let's start the quiz. Are you ready? Type 'yes' to start or 'no' to cancel.\n");
                matched = true;
            }
            else if (!matched && (userInput.Contains("yes") || userInput.Contains("ready")))
            {
                await RunQuiz();
                matched = true;
            }
            else if (!matched && userInput.Contains("no"))
            {
                await TypeBotText("Bot: No problem, let me know if you change your mind.\n");
                matched = true;
            }

            // Activity log
            if (!matched && (userInput.Contains("activity") || userInput.Contains("log")))
            {
                await ShowActivityLog();
                matched = true;
            }


            // If nothing matched
            if (!matched)
            {
                await TypeBotText("Bot: I did not quite understand that. Could you please rephrase?\n");
            }



        }

                    /*
             References


            Phuzi, 2022. C# Beginner, trying to change a fixed background color of a form with text in a textbox. [Online] 
            Available at: https://stackoverflow.com/questions/71018921/c-sharp-beginner-trying-to-change-a-fixed-background-color-of-a-form-with-text
            geek4geeks, 2025. C# List Class. [Online] 
            Available at: https://www.geeksforgeeks.org/c-sharp-list-class/
            geek4geeks, 2025. C# ListDictionary Class. [Online] 
            Available at: https://www.geeksforgeeks.org/c-sharp-listdictionary-class/


 
             */

        //quiz method
        private async Task RunQuiz()
        {
            int score = 0;

            //multiple questions
            var mcQuestions = new List<(string question, string[] options, string answer)>
    {
        ("1. What is phishing?", new[] { "A) A firewall", "B) A cyber attack that tricks users", "C) Encryption", "D) Software update" }, "b"),
        ("2. What is a strong password made of?", new[] { "A) Lowercase only", "B) Birthdate", "C) Mix of letters/numbers/symbols", "D) Your name" }, "c"),
        ("3. What does 2FA do?", new[] { "A) Encrypts", "B) Connects devices", "C) Adds extra login step", "D) Removes viruses" }, "c"),
        ("4. Sign of phishing email?", new[] { "A) Grammar", "B) Unknown sender requesting info", "C) HTTPS", "D) Known contact" }, "b"),
        ("5. What is malware?", new[] { "A) Update", "B) Antivirus", "C) Harmful software", "D) Encrypted traffic" }, "c")
    };

            foreach (var (question, options, correct) in mcQuestions)
            {
                await TypeBotText($"\n{question}\n");
                foreach (var option in options)
                    await TypeBotText(option + "\n");

                string answer = Microsoft.VisualBasic.Interaction.InputBox("Your answer (A-D):", "Quiz", "").ToLower();
                if (answer == correct)
                {
                    await TypeBotText("Bot: Correct!\n");
                    score++;
                }
                else
                {
                    await TypeBotText($"Bot: Wrong. Correct answer was {correct.ToUpper()}.\n");
                }
            }

            //list for true or false questions
            var tfQuestions = new List<(string question, bool answer)>
    {
        ("6. True/False: It's safe to click links from unknown senders.", false),
        ("7. True/False: Public Wi-Fi is safe for banking.", false),
        ("8. True/False: Antivirus should be updated regularly.", true),
        ("9. True/False: Cybersecurity is only IT’s job.", false),
        ("10. True/False: Reusing passwords is unsafe.", true)
    };

            foreach (var (question, answer) in tfQuestions)
            {
                await TypeBotText($"\n{question}\n");
                string response = Microsoft.VisualBasic.Interaction.InputBox("Your answer (true/false):", "Quiz", "").ToLower();

                if (bool.TryParse(response, out bool userAnswer) && userAnswer == answer)
                {
                    await TypeBotText("Bot: Correct!\n");
                    score++;
                }
                else
                {
                    await TypeBotText($"Bot: Wrong. Correct answer is {answer}.\n");
                }
            }

            await TypeBotText($"\nBot: Quiz complete! You scored {score}/10.\n");
        }

        //activity log method
        private async Task ShowActivityLog()
        {
            if (activityLog.Count == 0)
            {
                await TypeBotText("Bot: You haven’t asked anything yet.\n");
                return;
            }

            await TypeBotText("Bot: Here's your activity log:\n");
            foreach (var entry in activityLog)
            {
                await TypeBotText($"- {entry}\n");
            }
        }

        // Extract time phrase from user input
        private string ExtractTimePhrase(string input)
        {
            string[] timeIndicators = new[] { "in ", "at ", "on ", "tomorrow", "next ", "after ", "in a ", "in an " };

            foreach (var indicator in timeIndicators)
            {
                int index = input.ToLower().IndexOf(indicator);
                if (index != -1)
                {
                    string timePhrase = input.Substring(index).Trim();
                    int stopIndex = timePhrase.IndexOfAny(new[] { '.', ',' });
                    if (stopIndex > 0)
                        timePhrase = timePhrase.Substring(0, stopIndex);

                    return timePhrase;
                }
            }

            return "an unspecified time";
        }

        //typing effect for bot text
        private async Task TypeBotText(string text)
        {
            foreach (char c in text)
            {
                BotOutput.Text += c;
                await Task.Delay(30);
                ChatScrollViewer.ScrollToEnd();
            }
        }
        private void AppendText(string text)
        {
            BotOutput.Text += text;
            ChatScrollViewer.ScrollToEnd();
        }
        private void PlayAudio(string path)
        {
            try
            {
                var audioFile = new AudioFileReader(path);
                var outputDevice = new WaveOutEvent();
                outputDevice.Init(audioFile);
                outputDevice.Play();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error playing audio: " + ex.Message);
            }
        }

    }

}
/*

References
Aluan, 2023. Delay function in C#. [Online] 
Available at: https://stackoverflow.com/questions/46107252/delay-function-in-c-sharp
codecademy, 2023. .ToLower(). [Online]
Available at: https://www.codecademy.com/resources/docs/c-sharp/strings/tolower
Phuzi, 2022.C# Beginner, trying to change a fixed background color of a form with text in a textbox. [Online] 
Available at: https://stackoverflow.com/questions/71018921/c-sharp-beginner-trying-to-change-a-fixed-background-color-of-a-form-with-text
w3Schools, 2025.C# Foreach Loop. [Online] 
Available at: https://www.w3schools.com/cs/cs_foreach_loop.php

geek4geeks, 2025. C# List Class. [Online] 
Available at: https://www.geeksforgeeks.org/c-sharp-list-class/
geek4geeks, 2025. C# ListDictionary Class. [Online] 
Available at: https://www.geeksforgeeks.org/c-sharp-listdictionary-class/


*/

