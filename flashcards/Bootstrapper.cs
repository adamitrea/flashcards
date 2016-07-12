using flashcards.domain;
using flashcards.Infrastructure;
using flashcards.persistance;
using Nancy;
using Nancy.TinyIoc;

namespace flashcards
{
	public class Bootstrapper : DefaultNancyBootstrapper
	{
		// The bootstrapper enables you to reconfigure the composition of the framework,
		// by overriding the various methods and properties.
		// For more information https://github.com/NancyFx/Nancy/wiki/Bootstrapper

		protected override void ConfigureApplicationContainer(TinyIoCContainer container)
		{
			// We don't call "base" here to prevent auto-discovery of
			// types/dependencies
		}

		protected override void ConfigureRequestContainer(TinyIoCContainer container, NancyContext context)
		{
			// Here we register our user mapper as a per-request singleton.
			// As this is now per-request we could inject a request scoped
			// database "context" or other request scoped services.
			base.ConfigureRequestContainer(container, context);

			container.Register<IPathProvider, PathProvider>();
			container.Register<ICardSetRepository, JSonCardSetRepository>();

		}
	}
}