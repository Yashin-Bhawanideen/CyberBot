using CyberBot;
using NAudio.Wave;

internal class Program : TypingEffect
{
    private static void Main(string[] args)
    {
        string[] art = new string[]
        {
           "     [^_^]        ",
           "    /|___|\\      ",
           "     |   |        ",
           "     |_|_|        ",

        };


        // Print the bot face  
        Console.ForegroundColor = ConsoleColor.Green; // Make it look cooler  
        foreach (string line in art)
        {
            Console.WriteLine(line);
        }



        //audio of welcoming

        // Bot message to type
        string message = "\nHello, Welcome to the Cyber Security Awareness Bot. I'm here to help you stay safe online.";

        //changed the path to the audio file as (.wav), audio now stored in (.bin) as lecturer required
        string audioFilePath = @"C:\Users\Yashin\Documents\Modules\year 2\Prog C#\ChatBot_POE\CyberBot\CyberBot\bin\Debug\net8.0\Bot.wav";

        // Play the audio file and type the message
        using (var audioFile = new AudioFileReader(audioFilePath))
        using (var outputDevice = new WaveOutEvent())
        {
            outputDevice.Init(audioFile);
            outputDevice.Play();

            //start typing while audio is playing
            foreach (char c in message)
            {
                Console.Write(c);
                Thread.Sleep(84); // Adjust typing speed (in milliseconds)
            }

            // Ensure audio finishes before ending the program
            while (outputDevice.PlaybackState == PlaybackState.Playing)
            {
                Thread.Sleep(100);
            }

            Console.WriteLine();

        }

        // Welcome user
        ShowTyping("\nBot: Before we begin, I would like to know your Name. Please enter your Name below: ", ConsoleColor.Green);


        Console.ForegroundColor = ConsoleColor.DarkYellow; // Make it look cooler
        string name = Console.ReadLine().Trim();
        Console.ResetColor(); // Reset the color to default

        // bot welcome
        ShowTyping("Bot: It is a pleasure to meet you " + name + ".", ConsoleColor.Cyan);

        ShowTyping("\nBot: I am open to any question that you would like to ask..." + "\nBot: Type 'quit' or 'exit' to end the conversation", ConsoleColor.Cyan);


        // Use the class name to call the static method  

        Questions.Part1Questions();



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
