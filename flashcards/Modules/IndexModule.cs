using flashcards.domain;
using Nancy;
using System.Dynamic;

namespace flashcards.Modules
{
	public class IndexModule : NancyModule
	{
		public dynamic Model = new ExpandoObject();
		public IndexModule(ICardSetRepository cardSetRepo)
		{
			Get["/"] = parameters =>
			{
				Model.Sets = cardSetRepo.LoadAll();
				return View["index",Model];
			};
		}
	}
}