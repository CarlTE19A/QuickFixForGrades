using System.Numerics;
class Weapon : Item
{
	protected Vector2 damageRange;

	public Weapon(string _name, float _weight, float _minDamage, float _maxDamage) : base(_name, _weight)
	{
		damageRange = new Vector2(_minDamage, _maxDamage);
	}
	virtual public float Attack()
	{
		System.Console.WriteLine("nothing should be just a weapon, why are you here");
		return 0.0f;
	}
}