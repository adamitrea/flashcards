using flashcards.domain;
using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace flashcards.Infrastructure
{
	public class PathProvider : IPathProvider
	{
		private IRootPathProvider _rootPathProvider;

		public PathProvider(IRootPathProvider rootPathProvider)
		{
			_rootPathProvider = rootPathProvider;
		}

		public string GetRootPath()
		{
			return _rootPathProvider.GetRootPath();
		}
	}
}