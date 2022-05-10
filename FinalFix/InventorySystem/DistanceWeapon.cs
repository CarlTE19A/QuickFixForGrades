class DistanceWeapon : Weapon
{
	private Queue<Ammo> ammo = new Queue<Ammo>();

	private int maxAmmo;
	public DistanceWeapon(string _name, float _weight, float _minDamage, float _maxDamage, int _maxAmmo) : base(_name, _weight, _minDamage, _maxDamage)
	{
		maxAmmo = _maxAmmo;
	}
	override public float Attack()
	{
		System.Console.WriteLine("long range attack");
		if(ammo.Count > 0)
		{
			float damage = Game.random.Next((int)(damageRange.X*10), (int)(damageRange.Y*10)) / 10;
			Ammo shootbullet = ammo.Dequeue();
			damage *= shootbullet.damageMultiplier;
			return damage;
		}
		else
		{
			return 0;
		}
	}
	public void Reload(Ammo bullet)
	{
		ammo.Enqueue(bullet);
	}
}