//The Network part of this mini project
using RestSharp;
using System.Text.Json;
static class Network
{
	public static async Task SpacePart()
	{
		string content = "";

		System.Console.WriteLine("Do you want the latest SpaceX launch or their Next Upcoming Launch");
		System.Console.WriteLine("[1] for latest [2] for upcoming");
		char value = Console.ReadKey().KeyChar;
		while(value != '1' && value != '2')
		{
			Console.Clear();
			System.Console.WriteLine("Sorry that input was incorrect press 1 or 2 on your keyboard");
			System.Console.WriteLine("Do you want the latest SpaceX launch or their Next Upcoming Launch");
			System.Console.WriteLine("[1] for latest [2] for upcoming");	
			value = Console.ReadKey().KeyChar;
		}
		Console.Clear();
		if(value == '1')
		{
			await GetRequest("launches/latest");
			try
			{
				PastLaunch launch = JsonSerializer.Deserialize<PastLaunch>(content);
				System.Console.WriteLine("Latest launch");
				System.Console.WriteLine("----------------------");
				launch.Display();
			}
			catch
			{
				exitError("Most likely Incomplete Info resulting in Deserializeation Error", 1	);
			}
		}
		else if(value == '2')
		{
			await GetRequest("launches/next");
			try
			{
				Launch launch = JsonSerializer.Deserialize<Launch>(content);
				System.Console.WriteLine("Next launch");
				System.Console.WriteLine("----------------------");
				launch.Display();
			}
			catch
			{
				exitError("Incomplete Info, the next launch is not that prepared and the basic information is not yet public knowledge", 13);
			}
		}
		else
		{
			exitError("Achivement Unlocked : How did we get here (like dude how, tell me)", 1);
		}
		async Task GetRequest(string requestString)	//Create a request to the spacex api
		{
			RestClient client = new RestClient("https://api.spacexdata.com/v4/");
			RestRequest request = new RestRequest(requestString);
			RestResponse result = await client.GetAsync(request);

			content = result.Content;

			if(result.StatusCode == System.Net.HttpStatusCode.NotFound)
			{
				exitError("Request was not found", 2);
			}
		}

		static void exitError(string error, int errorCode)
		{
			System.Console.WriteLine("Error : " + error);
			System.Threading.Thread.Sleep(1000);
			System.Console.WriteLine("The program will now shut down");
			System.Threading.Thread.Sleep(1000);
			Environment.Exit(2);
		}
	}
}