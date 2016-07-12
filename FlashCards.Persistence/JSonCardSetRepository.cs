using flashcards.domain;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace flashcards.persistance
{
	public class JSonCardSetRepository : ICardSetRepository
	{
		private IPathProvider _rootPathProvider;
		private static IEnumerable<CardSet> _cache;

		public JSonCardSetRepository(IPathProvider rootPathProvider)
		{
			_rootPathProvider = rootPathProvider;
			_cache = Preload();
		}

		public IEnumerable<CardSet> LoadAll()
		{
			return _cache;
		}

		public CardSet Load(int id)
		{
			return _cache.Single(set => set.Id == id);
		}

		private IEnumerable<CardSet> Preload()
		{
			var dataFolderPath = Path.Combine(_rootPathProvider.GetRootPath(), "Data");

			return new DirectoryInfo(dataFolderPath).EnumerateFiles("*.json")
				.Select(file =>
				{
					using (var streamReder = new StreamReader(file.OpenRead()))
					{
						var content = new StreamReader(file.OpenRead()).ReadToEnd();
						return JsonConvert.DeserializeObject<CardSet>(content);
					}
				}).ToList();
		}
	}
}
