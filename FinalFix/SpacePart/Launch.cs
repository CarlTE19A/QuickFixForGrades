using RestSharp;
using System.Text.Json;
class Launch
{
	public string name{get; set;}
	public string date_utc{get; set;}
	public string rocket{get; set;}
	public string rocketName;
	public string[] payloads{get; set;}

	public async void Display()
	{	
		if(rocket == "5e9d0d95eda69955f709d1eb")
		{
			rocketName = "Falcon 1";
		}
		else if(rocket == "5e9d0d95eda69973a809d1ec")
		{
			rocketName = "Falcon 9";
		}
		else if(rocket == "5e9d0d95eda69974db09d1ed")
		{
			rocketName = "Falcon Heavy";
		}
		else if(rocket == "5e9d0d96eda699382d09d1ee")
		{
			rocketName = "Starship";
		}
		else
		{
			rocket = "UFO";
		}
		System.Console.WriteLine("Mission Name : " + name);
		System.Console.WriteLine("Launch UTC : " + date_utc);
		System.Console.WriteLine("Rocket Type : " + rocketName);
	}
}