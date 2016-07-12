using Nancy;

namespace flashcards.Modules
{
	public class CardSetModule : NancyModule
	{
		public CardSetModule() : base("/cardset")
		{
			Get["/{id}/learn"] = parameters =>
			{
				return View["learn"];
			};

			Post["/{id}/learn"] = parameters =>
			{
				return View["learn"];
			};
		}
	}
}
