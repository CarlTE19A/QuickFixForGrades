static class Game
{
	static public Item[] worldItems = 
	{	
		new Item("Juice Box", 0.2f),
		new Item("Book", 0.5f),
		new Item("Banana", 0.3f),
		new Item("T-Shirt", 0.8f),
		new Item("BK-Sauce", 0.1f),
		new Item("Cup", 0.6f),
		new Ammo("Normal Bullet", 0.1f, 1),
		new Ammo("Fire Bullet", 0.1f, 2),
		new DistanceWeapon("Handgun", 1, 1, 2, 12),
		new DistanceWeapon("AR-12", 4, 2, 4, 4),
		new DistanceWeapon("SKS", 4, 6, 8, 6),
		new MeleeWeapon("Hand Hatchet", 2, 1, 3),
		new MeleeWeapon("Fire Axe", 2, 2, 4),
		new MeleeWeapon("Frying Pan", 2, 1, 2)
	};
	static public Ammo[] ammoTypes = 
	{
		new Ammo("Normal Bullet", 0.1f, 1),
		new Ammo("Fire Bullet", 0.1f, 2)
	};
	public static Random random = new Random();
	public static void GamePart()
	{
		Player player = new Player(10);
		System.Console.WriteLine();
		System.Console.WriteLine("Now that you have seen some SpaceX info lets play a game");
		System.Console.WriteLine("Press any button to continue");
		Console.ReadKey();
		Console.Clear();

		bool hasFailed = false;
		while(hasFailed == false)
		{
			hasFailed = player.Turn();
			System.Console.WriteLine("Press any button to continue");
			Console.ReadKey();
			Console.Clear();
		}
	}
}