using System;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

public class Main_Window
{
	private static Encoding cp437 = Encoding.GetEncoding(437);

	public static int game_Speed;
	public static bool gameOver = false;
	public static void Main()
	{
		while (true)
		{
			Console.Clear();
			Console.Title = "Snake Game";
			Console.WindowHeight = 40;
			Console.WindowWidth = 80;

			Console.BufferWidth = Console.WindowWidth;

			Console.BackgroundColor = ConsoleColor.Black;


			Player player = new Player();
			AI ai = new AI(player, player.PlayerFood);

			game_Speed = 100;
			while (!gameOver)
			{
				Draw(player);
				Draw(player, player.PlayerFood.FoodSpawnPoint);
				player.UpdatePosition(player.PlayerElements, player.CurrentDirection);

				ai.GetDirection();

				// if (Console.KeyAvailable)
				//{
				//ConsoleKeyInfo ci = Console.ReadKey(true);
				//if (ci.Key == ConsoleKey.D)
				//{
				//	player.CurrentDirection = "right";
				//}
				//if (ci.Key == ConsoleKey.A)
				//{
				//player.CurrentDirection = "left";
				//}
				//if (ci.Key == ConsoleKey.W)
				//{
				//	player.CurrentDirection = "up";
				//	}
				//if (ci.Key == ConsoleKey.S)
				//{
				//	player.CurrentDirection = "down";
				//}
				//}

			}
			Console.Clear();
			Console.WriteLine("Game Over!");
			Console.WriteLine("Your score is: " + Score.PlayerScore);
			Console.WriteLine("Press any key to restart the game... ");
			Console.ReadKey();
			gameOver = false;
		}
	}

	public static void Draw(Player player)
	{
		foreach (var position in player.PlayerElements)
		{
			byte[] symbol_Player = new byte[1];
			symbol_Player[0] = 220;
			Console.CursorVisible = false;
			Console.ForegroundColor = ConsoleColor.Green;
			Console.SetCursorPosition(position.X, position.Y);
			Console.Write(cp437.GetString(symbol_Player));
		}

		Thread.Sleep(game_Speed);
	}
	public static void Draw(Player player, Position food)
	{
		Console.Clear();
		byte[] symbol_Food = new byte[1];
		symbol_Food[0] = 254;
		Console.SetCursorPosition(player.PlayerFood.FoodSpawnPoint.X, player.PlayerFood.FoodSpawnPoint.Y);
		Console.ForegroundColor = ConsoleColor.Red;
		Console.Write(cp437.GetString(symbol_Food));

	}
}