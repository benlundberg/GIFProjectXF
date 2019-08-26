using GifProjectXF.Core;
using System;
using System.Collections.Generic;

namespace GifProjectXF
{
    public class Bootstrapper
    {
        public static void RegisterTypes()
        {
            // Repositories
            ComponentContainer.Current.Register<IDatabaseRepository, DatabaseRepository>(singelton: true);

            // Helpers
            ComponentContainer.Current.Register<ITranslateHelper, TranslateHelper>();
            ComponentContainer.Current.Register<INetworkStatusHelper, NetworkStatusHelper>(singelton: true);

            // Services
            ComponentContainer.Current.Register<ITrendingService, TrendingService>();
            ComponentContainer.Current.Register<ISearchService, SearchService>();

            // Managers
            ComponentContainer.Current.Register<IGifManager, GifManager>(singelton: true);
        }

        public static void RegisterViews()
        {
            ViewContainer.Current.Register<HomeViewModel, HomePage>();
        }

        public static void CreateTables()
        {
            ComponentContainer.Current.Resolve<IDatabaseRepository>().CreateTablesAsync(new List<Type>()
            {
                typeof(GifItem)
            });
        }
    }
}
