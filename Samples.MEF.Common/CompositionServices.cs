using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Reflection;

namespace Samples.MEF.Common
{
    public class CompositionServices
    {
        /// <summary>
        /// Führt die Komposition mit dem übergebenen Objekt und der ausführenden Assembly durch
        /// </summary>
        /// <param name="attributedPart"></param>
        public static void ComposeParts(object attributedPart)
        {
            var assemblyCatalog = new AssemblyCatalog(Assembly.GetCallingAssembly());

            var catalog = new AggregateCatalog();
            catalog.Catalogs.Add(assemblyCatalog);

            var container = new CompositionContainer(catalog);

            try
            {
                container.ComposeParts(attributedPart);
            }
            catch (CompositionException compositionException)
            {
                Console.WriteLine(compositionException.ToString());
            }
        }

        /// <summary>
        /// Führt die Komposition mit allen Imports und Exports aller Assemblies im aktuellen Verzeichnis durch
        /// </summary>
        public static CompositionContainer ComposeAll()
        {
            var directoryCatalog = new DirectoryCatalog(Directory.GetCurrentDirectory());
            var aggregateCatalog = new AggregateCatalog(directoryCatalog);
            var assemblyCatalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());
            aggregateCatalog.Catalogs.Add(assemblyCatalog);

            var container = new CompositionContainer(aggregateCatalog);
            container.ComposeParts(aggregateCatalog);

            return container;
        }
    }
}
