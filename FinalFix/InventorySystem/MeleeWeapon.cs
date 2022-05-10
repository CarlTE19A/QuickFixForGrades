class MeleeWeapon : Weapon
{
	public MeleeWeapon(string _name, float _weight, float _minDamage, float _maxDamage) : base(_name, _weight, _minDamage, _maxDamage)
	{

	}
	override public float Attack()
	{
		System.Console.WriteLine("Melee attack");
		return Game.random.Next((int)(damageRange.X*10), (int)(damageRange.Y*10)) / 10;
	}
}