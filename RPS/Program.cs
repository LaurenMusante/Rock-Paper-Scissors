using System;
using PlayerNS;

public class Program 
{
    static void Main()
    {
        Console.WriteLine("Enter Player 1's name");
        string InputString = Console.ReadLine();
        Player Player1 = new Player(InputString);
        Console.WriteLine("Enter Player 2's name");
        InputString = Console.ReadLine();
        Player Player2 = new Player(InputString);
        bool playing = true;
        string playAgain = "";

        while(playing)
        {
            do
            {
                Console.Clear();
                Console.WriteLine($"\n{Player2.Name} look away \n{Player1.Name} Enter (Rock, Paper, or Scissors):");
                Player1.RPSChoice = Console.ReadLine();
            }
            while(!IsValid(Player1.RPSChoice));
            
            do
            {
                Console.Clear();
                Console.WriteLine($"{Player1.Name} look away \n{Player2.Name} Enter (Rock, Paper, or Scissors):");
                Player2.RPSChoice = Console.ReadLine();
            }
            while(!IsValid(Player2.RPSChoice));
            
            Console.WriteLine(RPSCheck(Player1, Player2));
            Console.WriteLine($"\n{Player1.Name} has {Player1.Stats[0]} Wins, {Player1.Stats[1]} Ties, {Player1.Stats[2]} Losses.");
            Console.WriteLine($"{Player2.Name} has {Player2.Stats[0]} Wins, {Player2.Stats[1]} Ties, {Player2.Stats[2]} Losses.");

            Console.WriteLine("Would you like to play again? (y/n)");
            playAgain = Console.ReadLine();
            if(playAgain == "n")
            {
                playing = false;
            }
        }
    }

    static string RPSCheck(Player player1, Player player2)
    {
        string output = "Stalemate";
        if (player1.RPSChoice == "scissors")
        {
            if (player2.RPSChoice == "rock") 
            {   
                output = $"{player2.Name} is the winner!";
                player2.Stats[0]++;
                player1.Stats[2]++;
            }      
            else if(player2.RPSChoice == "paper") 
            {
                output = $"{player1.Name} is the winner!";
                player1.Stats[0]++;
                player2.Stats[2]++;
            }
        }
        else if (player1.RPSChoice == "rock")
        {
            if (player2.RPSChoice == "scissors") 
            {
                output = $"{player1.Name} is the winner!";
                player1.Stats[0]++;
                player2.Stats[2]++;
            }   
            else if(player2.RPSChoice == "paper") 
            {
                output = $"{player2.Name} is the winner!";
                player2.Stats[0]++;
                player1.Stats[2]++;
            }           
        }
        else if (player1.RPSChoice == "paper")
        {
            if (player2.RPSChoice == "rock") 
            {
                output = $"{player1.Name} is the winner!";
                player1.Stats[0]++;
                player2.Stats[2]++;
            }
            else if(player2.RPSChoice == "scissors") 
            {
                output = $"{player2.Name} is the winner!";
                player2.Stats[0]++;
                player1.Stats[2]++;
            }
        } 
        if(player1.RPSChoice == player2.RPSChoice)
        {
            player1.Stats[1]++;
            player2.Stats[1]++;
        }
        
        return output;
    }

    static bool IsValid(string play)
    {
        bool validMove = false;
        if(play.ToLower() == "rock" || play.ToLower() == "paper" || play.ToLower() == "scissors")
        {
            validMove = true;
        }

        return validMove;
    }
}