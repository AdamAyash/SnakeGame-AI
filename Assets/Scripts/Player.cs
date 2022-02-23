using System;
using System.Collections;
using System.Collections.Generic;

public class Player
{
	private Food playerFood;

	private Queue<Position> playerElements;
	private Position currentPlayerHead;
	private Position newPlayerHead;

	private int playerElementsNumber;

	private string[] directions;
	private string currentDirection;

	public Player()
	{
		this.playerFood = new Food();
		this.directions = new string[] { "right", "left", "up", "down" };
		this.playerElements = new Queue<Position>();
		this.currentDirection = this.directions[0];
		this.playerElementsNumber = 10;

		InitializePlayer();
	}

	public Food PlayerFood
	{
		get
		{
			return this.playerFood;
		}
		set
		{
			this.playerFood = value;
		}
	}

	public Queue<Position> PlayerElements
	{
		get
		{
			return this.playerElements;
		}
		private set { }
	}
	public string[] Directions
	{
		get
		{
			return this.directions;
		}
		set
		{
			this.directions = value;
		}
	}

	public string CurrentDirection
	{
		get
		{
			return this.currentDirection;
		}
		set
		{
			this.currentDirection = value;
		}
	}

	public int PlayerElementsNumber
	{
		get
		{
			return this.playerElementsNumber;
		}
		set
		{
			this.playerElementsNumber = value;
		}
	}

	public Position CurrentPlayerHead
	{
		get
		{
			return this.currentPlayerHead;
		}
	}

	public Position NewPlayerHead
	{
		get
		{
			return this.newPlayerHead;
		}
	}

	private void InitializePlayer()
	{
		for (int i = 0; i < this.playerElementsNumber; i++)
		{
			this.playerElements.Enqueue(new Position(i, 0));
			this.currentPlayerHead.X = i;
			this.currentPlayerHead.Y = 0;
		}
	}

	private void CheckPlayerHeadPosition(Queue<Position> playerElements, Position newPlayerHead)
	{

		foreach (Position currentElement in this.playerElements)
		{
			if ((currentElement.X == newPlayerHead.X) && (currentElement.Y == newPlayerHead.Y))
			{
					Main_Window.gameOver = true;
			}

		}
	}

	public void UpdatePosition(Queue<Position> playerElements, string direction)
	{
		if (direction == directions[0])
		{
			this.newPlayerHead = new Position(currentPlayerHead.X + 1, currentPlayerHead.Y);
			if (newPlayerHead.X >= Console.WindowWidth)
			{
				for (int i = 1; i <= this.playerElements.Count; i++)
				{
					this.playerElements.Dequeue();
					this.playerElements.Enqueue(new Position(i, newPlayerHead.Y));
					Main_Window.Draw(this);
					currentPlayerHead = new Position(i, newPlayerHead.Y);
					CheckPlayerHeadPosition(this.playerElements, this.newPlayerHead);
					AddElement(currentPlayerHead);

				}
			}
			else
			{
				CheckPlayerHeadPosition(this.playerElements, this.newPlayerHead);
				this.playerElements.Enqueue(this.newPlayerHead);
				this.playerElements.Dequeue();
				currentPlayerHead = newPlayerHead;
				AddElement();
			}
			

		}

		if (direction == directions[1])
		{
			this.newPlayerHead = new Position(currentPlayerHead.X - 1, currentPlayerHead.Y);
			if (newPlayerHead.X <= 0)
			{
				for (int i = Console.WindowWidth - 1; i >= Console.WindowWidth - this.playerElements.Count - 1; i--)
				{
					this.playerElements.Dequeue();
					this.playerElements.Enqueue(new Position(i, newPlayerHead.Y));
					Main_Window.Draw(this);
					currentPlayerHead = new Position(i, newPlayerHead.Y);
					CheckPlayerHeadPosition(this.playerElements, this.newPlayerHead);
					AddElement(currentPlayerHead);


				}
			}
			else
			{
				CheckPlayerHeadPosition(this.playerElements, this.newPlayerHead);
				this.playerElements.Enqueue(this.newPlayerHead);
				this.playerElements.Dequeue();
				currentPlayerHead = newPlayerHead;
				AddElement();
			}
		}
		if (direction == directions[2])
		{
			this.newPlayerHead = new Position(currentPlayerHead.X, currentPlayerHead.Y - 1);
			if (this.newPlayerHead.Y <= 0)
			{
				for (int i = Console.WindowHeight - 1; i >= Console.WindowHeight - this.playerElements.Count - 1; i--)
				{
					this.playerElements.Dequeue();
					this.playerElements.Enqueue(new Position(newPlayerHead.X, i));
					currentPlayerHead = new Position(newPlayerHead.X, i);
					Main_Window.Draw(this);
					CheckPlayerHeadPosition(this.playerElements, this.newPlayerHead);
					AddElement(currentPlayerHead);
				}
			}
			else
			{
				CheckPlayerHeadPosition(this.playerElements, this.newPlayerHead);
				this.playerElements.Enqueue(this.newPlayerHead);
				this.playerElements.Dequeue();
				currentPlayerHead = newPlayerHead;
				AddElement();
			}
		}
		if (direction == directions[3])
		{
			this.newPlayerHead = new Position(currentPlayerHead.X, currentPlayerHead.Y + 1);
			if (newPlayerHead.Y >= Console.WindowHeight)
			{
				for (int i = 1; i < this.playerElements.Count; i++)
				{
					this.playerElements.Dequeue();
					this.playerElements.Enqueue(new Position(newPlayerHead.X, i));
					currentPlayerHead = new Position(newPlayerHead.X, i);
					Main_Window.Draw(this);
					CheckPlayerHeadPosition(this.playerElements, this.newPlayerHead);
					AddElement(currentPlayerHead);
				}
			}
			else
			{
				CheckPlayerHeadPosition(this.playerElements, this.newPlayerHead);
				this.playerElements.Enqueue(this.newPlayerHead);
				this.playerElements.Dequeue();
				currentPlayerHead = newPlayerHead;
				AddElement();
			}
		}
	}

	private void AddElement()
	{
		if (this.newPlayerHead.X == this.playerFood.FoodSpawnPoint.X && 
			this.newPlayerHead.Y == this.playerFood.FoodSpawnPoint.Y)
		{
			Console.Beep();
			Score.PlayerScore++;
			Main_Window.game_Speed -= 1;
			this.playerElements.Enqueue(new Position(playerFood.FoodSpawnPoint.X, playerFood.FoodSpawnPoint.Y));
			this.playerFood = new Food();

		}
	}

	private void AddElement(Position currentPlayerHead)
	{
		if (this.currentPlayerHead.X == this.playerFood.FoodSpawnPoint.X &&
			this.currentPlayerHead.Y == this.playerFood.FoodSpawnPoint.Y)
		{
			Console.Beep();
			Score.PlayerScore++;
			Main_Window.game_Speed -= 1;
			this.playerElements.Enqueue(new Position(playerFood.FoodSpawnPoint.X, playerFood.FoodSpawnPoint.Y));
			this.playerFood = new Food();

		}
	}
}
