﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flashcards.domain
{
	public interface ICardSetRepository
	{
		IEnumerable<CardSet> LoadAll();

		CardSet Load(int id);
	}
}
