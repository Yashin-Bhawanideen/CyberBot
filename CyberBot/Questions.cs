using System.Text.RegularExpressions;

namespace CyberBot
{
    class Questions : TypingEffect
    {
        public static void Part1Questions()
        {


            //set questions
            string[] greeting = { "How are you?", "how are you?", "how are you", "how are u", "how are u?" };
            string[] question1 = { "What is your purpose", "What can I ask you about" };

            //extra code of mine
            string[] thanks = { "thank you", "thanks", "thank you very much", "thanks a lot", "thank you so much" };


            //dictionary to store the questions and answers + if the user doesn't understand further explaination is added
            // (geek4geeks, 2025)
            /*geek4geeks, 2025. C# ListDictionary Class. [Online] 
            Available at: https://www.geeksforgeeks.org/c-sharp-listdictionary-class/
            */
            Dictionary<string, string> keywordResponses = new Dictionary<string, string>()
            {
                {"password", "A string of characters used to verify the identity of a user during the authentication process" },
                {"scam","A dishonest plan for making money or getting an advantage, especially one that involves tricking people" },
                {"privacy","Computer privacy, also known as data privacy or information privacy, refers to the control an individual or organization has over their personal information and data, especially in the digital realm." },
                {"safe browsing","Safe browsing refers to online practices and technologies that help protect users from various web-related threats like malware, phishing, and malicious websites." }

            };



            //phishing tips
            /* (geek4geeks, 2025)
             * geek4geeks, 2025. C# List Class. [Online] 
               Available at: https://www.geeksforgeeks.org/c-sharp-list-class/
             */


            List<string> phishingTips = new List<string>()
            {
                "Add spam filters to your email.",
                "Be cautious of unsolicited emails and messages.",
                "Verify the sender's email address before clicking on links.",
                "Avoid sharing personal information over email.",
                "Use two-factor authentication for added security."
            };


            //sentiment
            List<string> emotion = new List<string>()
            {
                "worried","concerned", "scared", "nervous", "anxious", "afraid", "uneasy"

            };

            //add tasks
            List<string> addTask = new List<string>()
            {
                "Add task", "Add a task", "Add a new task", "Add new task"
            };

            string[] availabletask = { "1. Setup two factor authentication", "2. Review privacy settings", "3. Change password" };
            List<string> addedTask = new List<string>();

            //show tasks added
            List<string> showTask = new List<string>()
            {
                "Show tasks", "Show added tasks", "Show added task", "show me added tasks"
            };


            //reminder
            List<string> reminder = new List<string>()
                { "Set a reminder", "Remind me","set reminder" };

           
            //activity log
            List<string> activityLog = new List<string>();


            //looping
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow; // Make it look cooler

                //changed user input as required by lecturer ("Trim()" ) function
                //Trim was added when user enters extra spaces as input, the "trim" cuts out those extra spaces between and after and before user input
                Console.WriteLine();
                string userInput = Regex.Replace(Console.ReadLine().Trim(), @"\s+", " ");
                
                
                //adds everything that the user asks 
                activityLog.Add(userInput);
                Console.ResetColor(); // Reset the color to default


                //exit or empty value
                Console.ForegroundColor = ConsoleColor.Cyan;
                if (string.IsNullOrWhiteSpace(userInput))
                {
                    ShowTyping("Bot: Please enter a message or question.", ConsoleColor.Cyan); // Prompt user to enter a message
                    continue;
                }
                if (userInput == "exit" || userInput == "quit")
                {
                    ShowTyping("Bot: Goodbye, stay safe online", ConsoleColor.Cyan);
                    break;
                }

                bool matched = false;


                //greeting
                foreach (string greet in greeting)
                {
                    if (userInput.ToLower() == greet.ToLower())
                    {

                        ShowTyping("\nBot: I am doing well, thank you for asking. How can I assist you today?", ConsoleColor.Cyan);



                        Console.WriteLine();
                        matched = true;

                    }
                }

                //thanking prompt
                /*(w3schools, 2025)
                 * w3schools, 2025. Java For Each Loop. [Online] 
                    Available at: https://www.w3schools.com/java/java_foreach_loop.asp

                 */
                foreach (string thank in thanks)
                {
                    if (userInput.ToLower() == thank.ToLower())
                    {


                        ShowTyping("\nBot: You're welcome! If you need to ask anything else I am still here to help", ConsoleColor.Cyan);

                        matched = true;

                    }
                }


                //user input for what's your purpose

                if (userInput.ToLower() == question1[0].ToLower())
                {


                    ShowTyping("\nBot: I'm here to assist you in, undestanding various ways to which you can protect yourself from cyber threats" +
                                         "\nBot: Various factors like the use of passwords, phishing and safe browsing can be dicussed." + "\n", ConsoleColor.Cyan);



                    matched = true;

                }
                else if (userInput.ToLower() == question1[1].ToLower())
                {

                    ShowTyping("\nBot: I can give you summarised explainations, anything related to cyber security.", ConsoleColor.Cyan);
                    matched = true;
                }


                //user input for keyword responses to dictionary list
                foreach (string keyword in keywordResponses.Keys)
                {

                    if (userInput.ToLower().Contains(keyword.ToLower()))
                    {

                        ShowTyping("\nBot: " + keywordResponses[keyword], ConsoleColor.Cyan);


                        matched = true;


                    }

                }

                //understanding more, if user is confused
                if (userInput.Contains("don't understand") || userInput.Contains("please explain"))
                {

                    ShowTyping("\nBot: What do you not understand: " + "\nPasswords " + "\nScams" + "\nSafe browsing" + "\nPrivacy", ConsoleColor.Cyan);

                    Console.ForegroundColor = ConsoleColor.DarkYellow; // Make it look cooler
                    string followUp = Console.ReadLine().ToLowerInvariant().Trim();
                    Console.ResetColor(); // Reset the color to default

                    switch (followUp)
                    {
                        case "passwords":
                            ShowTyping("\nBot: Passwords are to protect personal information", ConsoleColor.Cyan);

                            break;


                        case "scams":
                            ShowTyping("\nBot: Scammers are always looking to separate you from your money in business transactions", ConsoleColor.Cyan);

                            break;


                        case "safe browsing":
                            ShowTyping("\nBot: Protect users from malicious activities over the internet", ConsoleColor.Cyan);

                            break;


                        case "privacy":
                            ShowTyping("\nBot: Privacy is used to protect the user's personal information from being shared or used", ConsoleColor.Cyan);

                            break;
                        default:
                            ShowTyping("Invalid selection", ConsoleColor.DarkRed);

                            break;



                    }
                    matched = true;
                }



                //sentiment
                foreach (string emo in emotion)
                {
                    if (userInput.Contains(emo.ToLower()))
                    {

                        ShowTyping("\nBot: It's understandable to feel that way. I can share tips of how to stay safe online. ", ConsoleColor.Cyan);

                        matched = true;

                    }
                }

                //phishing tips

                if (userInput.Contains("phishing tip"))
                {


                    //chooses a random response to display
                    Random rand = new Random();

                    int randomIndex = rand.Next(phishingTips.Count);

                    ShowTyping("\nBot: " + phishingTips[randomIndex], ConsoleColor.Cyan);


                    matched = true;

                }



                //add tasks

                foreach (var tsk in addTask)
                {
                    if (userInput.Contains(tsk.ToLower()))
                    {
                        ShowTyping("\nBot: Please enter the task you would like to add: (choose the number)", ConsoleColor.Cyan);

                        //show all tasks
                        foreach (var available in availabletask)
                        {
                            ShowTyping(available, ConsoleColor.Cyan);
                        }

                        Console.ForegroundColor = ConsoleColor.DarkYellow; // Make it look cooler
                        string taskNo = Console.ReadLine().ToLowerInvariant().Trim();
                        Console.ResetColor(); // Reset the color to default


                        switch (taskNo)
                        {
                            case "1":
                                ShowTyping("\nBot: Two factor authentication task successfully added", ConsoleColor.Cyan);
                                //adds task to the list that was declared above
                                addedTask.Add("Set-up two factor authentication");
                                break;
                            case "2":
                                ShowTyping("\nBot: Review privacy settings task successfully added", ConsoleColor.Cyan);
                                addedTask.Add("Review privacy settings");
                                break;
                            case "3":
                                ShowTyping("\nBot: Change password task successfully added", ConsoleColor.Cyan);
                                addedTask.Add("Change password");
                                break;

                            default:
                                ShowTyping("Invalid selection", ConsoleColor.DarkRed);

                                break;
                        }
                        matched = true;
                    }
                }
               
                //show task added
                foreach (var shwTask in showTask)
                {
                    if (userInput.Contains(shwTask.ToLower()))
                    {
                        //if addedTask has items, show them (COUNT>0) shows if there are no items like a count is smaller the zero the theres nothing
                        if (addedTask.Count > 0)
                        {
                            ShowTyping("\nBot: Here are your added tasks:", ConsoleColor.Cyan);
                            foreach (var taskItem in addedTask)
                            {
                                ShowTyping(taskItem, ConsoleColor.Cyan);
                               
                            }
                            matched = true;
                        }
                        else
                        {
                            ShowTyping("\nBot: You have no added tasks yet.", ConsoleColor.Cyan);
                            matched = true;
                        }

                    }

                }
                //the time for reminder
                string ExtractTimePhrase(string input)
                {
                    // Example patterns – expand this as needed
                    string[] timeIndicators = new[] { "in ", "at ", "on ", "tomorrow", "next ", "after ", "in a ", "in an " };

                    foreach (var indicator in timeIndicators)
                    {
                        int index = input.ToLower().IndexOf(indicator);
                        if (index != -1)
                        {
                            // Get the phrase starting from the indicator
                            string timePhrase = input.Substring(index).Trim();
                            // Optional: stop at a period or comma
                            int stopIndex = timePhrase.IndexOfAny(new[] { '.', ',' });
                            if (stopIndex > 0)
                                timePhrase = timePhrase.Substring(0, stopIndex);

                            return timePhrase;
                        }
                    }

                    return "an unspecified time"; // fallback
                }


                //set a reminder
                //show if user wants to see added tasks

                foreach (var rmd in reminder)
                {

                    string date = ExtractTimePhrase(userInput);


                    if (userInput.Contains(rmd.ToLower()))
                    {
                        if(userInput.Contains("two factor authentication") || userInput.Contains("setup two factor authentication"))
                        {
                            ShowTyping("\nBot: A reminder was set for 'set-up two factor authentication' at "+date, ConsoleColor.Cyan);
                            matched = true;
                        }
                        else if (userInput.Contains(rmd.ToLower()) && userInput.Contains("privacy settings"))
                        {
                            ShowTyping("\nBot: A reminder was set for 'review privacy settings' at " + date, ConsoleColor.Cyan);
                            matched = true;
                        }
                        else if (userInput.Contains(rmd.ToLower()) && userInput.Contains("change password") || userInput.Contains("password"))
                        {
                            ShowTyping("\nBot: A reminder was set for 'change password' at " + date, ConsoleColor.Cyan);
                            matched = true;
                        }
                        else
                        {
                            ShowTyping("\nBot: Please specify a task to set a reminder for.", ConsoleColor.DarkRed);
                            matched = true;
                        }

                    }
                   
                }

                //quiz
                if (userInput.Contains("quiz"))
                {
                    ShowTyping("\nBot: Sure thing, let's start the quiz." + "\nAre you ready...[Yes] or [No]", ConsoleColor.Cyan);
                    matched = true;

                }
                else if (userInput.Contains("yes") || userInput.Contains("ready"))
                {

                    quizQuestions();
                    matched = true;
                }
                else if (userInput.Contains("no"))
                {
                    ShowTyping("\nBot: No problem, let me know if you change your mind.", ConsoleColor.Cyan);

                    matched = true;
                }

                //activity log
                if(userInput.Contains("activity") || userInput.Contains("log"))
                {
                    actLog(activityLog);
                    matched = true;
                }


                if (!matched)
                {
                    ShowTyping("Bot: I did not quite understand that. Could you please rephrase?", ConsoleColor.DarkRed);

                    Console.WriteLine();

                }




            }
        }

        //method for activity log
        public static void actLog(List<string> activityLog)
        {
            if (activityLog.Count > 0)
            {
                ShowTyping("\nBot: Here's a summary of what you've asked so far:", ConsoleColor.Cyan);
                foreach (var entry in activityLog)
                {
                    ShowTyping("- " + entry, ConsoleColor.Cyan);
                }
            }
            else
            {
                ShowTyping("\nBot: You haven't asked anything yet.", ConsoleColor.Cyan);
            }


        }
        //method for quiz
        public static void quizQuestions()
        {
            int score = 0;

            Console.WriteLine();
            ShowTyping("Bot: Let's begin the Cybersecurity Quiz!", ConsoleColor.Cyan);
            Console.WriteLine();

            // MULTIPLE CHOICE QUESTIONS 
            List<(string question, string[] options, string answer)> mcQuestions = new List<(string, string[], string)>()
            {
                ("1. What is phishing?", new string[] {
                    "A) A type of firewall",
                    "B) A cyber attack that tricks users into revealing personal info",
                    "C) A secure method of encryption",
                    "D) A software update"
                }, "b"),

                ("2. What is a strong password made of?", new string[] {
                    "A) Only lowercase letters",
                    "B) Your birthdate",
                    "C) A mix of letters, numbers, and symbols",
                    "D) Your name"
                }, "c"),

                ("3. What does two-factor authentication do?", new string[] {
                    "A) Encrypts files automatically",
                    "B) Connects two devices",
                    "C) Adds an extra step to login for security",
                    "D) Removes viruses"
                }, "c"),

                ("4. Which one is a sign of a phishing email?", new string[] {
                    "A) Proper grammar",
                    "B) Unknown sender asking for sensitive data",
                    "C) Secure https link",
                    "D) Known contact with attachment"
                }, "b"),

                ("5. What is malware?", new string[] {
                    "A) A software update",
                    "B) A type of antivirus",
                    "C) Malicious software designed to harm your device",
                    "D) Encrypted traffic"
                }, "c")
            };

            foreach (var (question, options, correctAnswer) in mcQuestions)
            {
                ShowTyping($"\n{question}", ConsoleColor.Cyan);
                foreach (var option in options)
                {
                    Console.WriteLine(option);
                }

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("\nYour answer (A, B, C, or D): ");
                string userAnswer = Console.ReadLine().ToLowerInvariant().Trim();
                Console.ResetColor();

                if (userAnswer == correctAnswer)
                {
                    ShowTyping("Bot: Correct!", ConsoleColor.Green);
                    score++;
                }
                else
                {
                    ShowTyping($"Bot: Wrong. The correct answer was {correctAnswer.ToUpper()}.", ConsoleColor.Red);
                }
            }

            // TRUE/FALSE QUESTIONS 
            List<(string question, bool answer)> tfQuestions = new List<(string, bool)>()
            {
                ("6. True or False: It’s safe to click links in emails from unknown senders.", false),
                ("7. True or False: Public Wi-Fi is always secure for online banking.", false),
                ("8. True or False: Antivirus software should be updated regularly.", true),
                ("9. True or False: Cybersecurity is only the responsibility of IT professionals.", false),
                ("10. True or False: Using the same password for multiple accounts is unsafe.", true)
            };

            foreach (var (question, correctAnswer) in tfQuestions)
            {
                ShowTyping($"\n{question}", ConsoleColor.Cyan);
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("Your answer (true/false): ");
                string userAnswer = Console.ReadLine().ToLowerInvariant().Trim();
                Console.ResetColor();

                bool parsed;
                if (bool.TryParse(userAnswer, out parsed))
                {
                    if (parsed == correctAnswer)
                    {
                        ShowTyping("Bot: Correct!", ConsoleColor.Green);
                        score++;
                    }
                    else
                    {
                        ShowTyping($"Bot: Wrong. The correct answer was {correctAnswer}.", ConsoleColor.Red);
                    }
                }
                else
                {
                    ShowTyping("Bot: Please answer with 'true' or 'false'.", ConsoleColor.DarkRed);

                }
            }

            // Final Score
            ShowTyping($"\nBot: Quiz complete! You scored {score}/10.", ConsoleColor.Cyan);
            Console.WriteLine();



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

 
