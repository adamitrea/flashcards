using flashcards.domain;
using Nancy;
using System;
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
				int nextCardIndex = (int) Math.Floor(new Random().NextDouble()*(cardSet.Cards.Count()));

				//chose next card
				Model.Set = cardSet;
				Model.Card = cardSet.Cards.Skip(nextCardIndex).FirstOrDefault();

				return View["learn", Model];
			};
		}
	}
}
