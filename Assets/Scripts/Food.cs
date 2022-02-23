using System;

public class Food
{
	private Position foodSpawnPoint;
	public Food()
	{
		this.foodSpawnPoint = GetNewSpawnPointPosition();
	}

	public Position FoodSpawnPoint
	{
		get
		{
			return this.foodSpawnPoint;
		}
		set
		{
			this.foodSpawnPoint = value;
		}
	}

	private Position GetNewSpawnPointPosition()
	{
		Random randomSpawnPosition = new Random();
		return new Position(randomSpawnPosition.Next(1,Console.WindowWidth), randomSpawnPosition.Next(1,Console.WindowHeight));

	}
}