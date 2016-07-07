using Nancy;

namespace flashcards.Modules
{
	public class CardSetModule : NancyModule
	{
		public CardSetModule() : base("/cardset")
		{
			Get["/learn"] = parameters =>
			{
				return View["learn"];
			};

			Post["/learn"] = parameters =>
			{
				return View["learn"];
			};
		}
	}
}
