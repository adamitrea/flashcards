using flashcards.domain;
using Nancy;
using System.Dynamic;
using System.Linq;

namespace flashcards.Modules
{
	public class CardSetModule : NancyModule
	{
		public dynamic Model = new ExpandoObject();

		public CardSetModule(ICardSetRepository cardSetRepo) : base("/cardset")
		{
			Get["/{id}/learn"] = parameters =>
			{
				CardSet cardSet = cardSetRepo.Load(parameters.id);
				Model.Card = cardSet.Cards.First();
				Model.Set = cardSet;

				return View["learn", Model];
			};

			Post["/{id}/learn"] = parameters =>
			{
				int cardId = int.Parse(Request.Form.cardId);
				bool correctAnswer = Request.Form.answerCorrect == "1";
				int setId = parameters.id;

				CardSet cardSet = cardSetRepo.Load(parameters.id);
				int nextCardId = int.Parse(this.Request.Form.cardid) + 1;

				//chose next card
				Model.Set = cardSet;
				Model.Card = cardSet.Cards.FirstOrDefault(card => card.Id == nextCardId) ?? cardSet.Cards.First();

				return View["learn", Model];
			};
		}
	}
}
