class Player
{
	private Stack<Item> items = new Stack<Item>();
	private float maxWeight;
	private Item equippeditem;

	float itemsWeight = 0;
	
	public Player(float _maxWeight)
	{
		maxWeight = _maxWeight;
	}
	public bool Turn()
	{	
		itemsWeight = 0;
		foreach (Item item in items)
		{
			itemsWeight += item.weight;
		}
		Console.Clear();
		System.Console.WriteLine("If you go over your max weight you will be crushed to death");
		System.Console.WriteLine($"Current weight : {itemsWeight} / {maxWeight}");
		if(equippeditem != null)
		{
			System.Console.WriteLine($"Equipped item : {equippeditem.name}");
		}
		else
		{
			System.Console.WriteLine($"Equipped item : None");
		}
		if(items.Count > 0)
		{
			System.Console.WriteLine($"Top item : {items.Peek().name}");
			System.Console.WriteLine("----------------------------------------");
			System.Console.WriteLine("You can only reach the thing at the top of your bag so what do you want to do with it?");
			System.Console.WriteLine("Press the number corresponding to the thing you want to do");
			System.Console.WriteLine("1. Find new item");
			System.Console.WriteLine("2. Equip it");
			System.Console.WriteLine("3. Attack with your equipped item");
			System.Console.WriteLine("4. Drop it");
			System.Console.WriteLine("5. Put it in your equipped item");
			System.Console.WriteLine("6. Exit the game");
			switch (Console.ReadKey().KeyChar)
			{
				case '1':
					Console.Clear();
					return FindItem();

				case '2':
					Console.Clear();
					EquipItem();
					break;
				case '3':
					Console.Clear();
					if(equippeditem != null)
					{
						if(equippeditem.GetType().IsSubclassOf(typeof(Weapon)))
						{
							Weapon tempWeapon = (Weapon)equippeditem;
							System.Console.WriteLine(tempWeapon.Attack());
							equippeditem = tempWeapon;
						}
						else
						{
							System.Console.WriteLine("Silly you, that is not a weapon");
						}
					}
					else
					{
						System.Console.WriteLine("Silly you, those are your bare hands, that may hurt you too");
					}
					break;
				case '4':
					Console.Clear();
					DropItem();
					break;

				case '5':
					Console.Clear();
					if(equippeditem != null)
					{
						if(items.Peek().GetType() == typeof(Ammo) && equippeditem.GetType() == typeof(DistanceWeapon))
						{
							System.Console.WriteLine("You added a bullet to you gun");
							DistanceWeapon tempWeapon = (DistanceWeapon)equippeditem;
							tempWeapon.Reload((Ammo)items.Pop());
							equippeditem = tempWeapon;
						}
						else if(items.Peek().GetType() == typeof(Ammo))
						{
							System.Console.WriteLine("Silly you, that is not a gun, cant put a bullet something else");
						}
						else if(equippeditem.GetType() == typeof(DistanceWeapon))
						{
							System.Console.WriteLine("Silly you cant put that in your gun");
						}
						else
						{
							System.Console.WriteLine("Silly you that is nither a bullet or a gun to put it in");
						}
					}
					else
					{
						System.Console.WriteLine("Silly you dont have anything in your hands, you dont have guns for hands");
					}
					break;

				case '6':
					Console.Clear();
					return true;

				default:
				System.Console.WriteLine("Hey that is not the correct input, try pressing [1 - 5]");
				System.Console.WriteLine("Try again");
				break;
			}
			return false;
		}
		else
		{
			System.Console.WriteLine($"Top item : No items in bag");
			System.Console.WriteLine("You have to search for something then");
			return FindItem();
		}	
	}
	private bool FindItem()
	{
		Item tempItem = Game.worldItems[Game.random.Next(0, Game.worldItems.Length)];
		System.Console.WriteLine($"You found a {tempItem.name}");
		items.Push(tempItem);
		itemsWeight += tempItem.weight;
		if(itemsWeight >= 10)
		{
			System.Console.WriteLine("YOU DIED, you are to greedy");
			return true;
		}
		return false;
	}
	private void EquipItem()
	{	
		equippeditem = items.Pop();
	}
	private void DropItem()
	{
		System.Console.WriteLine($"You dropped {items.Pop().name}");
	}
}