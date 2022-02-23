public class AI
{
	private Player pl;
	private Food fd;

	public AI(Player player, Food food)
	{
		this.pl = player;
		this.fd = food;
	}

	public Player Player
	{
		get
		{
			return this.pl;
		}
	}

	public void GetDirection()
	{
		if (this.pl.NewPlayerHead.X < this.fd.FoodSpawnPoint.X && 
		this.pl.NewPlayerHead.X - 1 != this.pl.CurrentPlayerHead.X)
		{
			this.pl.CurrentDirection = "right";
		}
		else
		{
			if (this.pl.NewPlayerHead.X == this.fd.FoodSpawnPoint.X)
			{
				if (this.pl.NewPlayerHead.Y < this.fd.FoodSpawnPoint.Y)
				{
					this.pl.CurrentDirection = "down";
				}
				else if(this.pl.NewPlayerHead.Y > this.fd.FoodSpawnPoint.Y)
				{
					this.pl.CurrentDirection = "up";
				}
				else
				{
					this.fd = this.pl.PlayerFood = new Food();
				}
				return;
			}
			this.pl.CurrentDirection = "left";

		}
	}
}