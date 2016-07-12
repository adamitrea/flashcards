using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flashcards.domain
{
	public class CardSet
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

		public List<Card> Cards { get; set; }
	}
}
