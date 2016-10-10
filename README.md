# Samples.MEF

In diesem Repository finden sich einfache Beispiele zur Verwendung des Managed Extensibility Framework (MEF).
MEF ist Teil des .NET Framework. Es ist ein Mechanismus zur Erweiterbarkeit von Anwendungen.
Erweiterungen werden zur Laufzeit über einen gemeinsamen Contract gefunden und geladen.

## Samples.MEF.Simple

Das Projekt beinhaltet ein einfaches Beispiel für MEF.
Über das Export- 
```csharp
            [Export(typeof(IQuackBehaviour))]
```
bzw. Import-Attribut
```csharp
            [Import(typeof(IQuackBehaviour))]
```

wird mit ComposeParts das zugehörige Behaviour geladen.
In diesem einfachem Beispiel reicht es, in der aktuellen Assembly nach ComposableParts zu suchen
```csharp
            var assemblyCatalog = new AssemblyCatalog(Assembly.GetCallingAssembly());

            var catalog = new AggregateCatalog();
            catalog.Catalogs.Add(assemblyCatalog);

            var container = new CompositionContainer(catalog);
```

und danach die Komposition mit dem übergebenen Objekt durchzuführen.
```csharp
            container.ComposeParts(attributedPart);
```

Die Komposition funktioniert auch, wenn die Import-Eigenschaft private ist.
Wenm mehr als ein Export des angegebenen Typs gefunden wird, wird eine Fehlermeldung geworfen.

## Samples.MEF.ManyDelegates

In diesem Beispiel wird gezeigt, wie eine Menge an Exporten importiert werden kann.
Der Import wird dann mit 
```csharp
            [ImportMany("TestRun")]
```

angegeben.

Das Beispiel zeigt auch, dass auch Func oder Action als Typ eines Import angegeben werden können.
Das Export-Attribut wird dann direkt über der Methode angegeben. Der Contract ist als string anzugeben.
```csharp
            [Export("TestRun")]
            public void GreenTest()
            {
              ...
            }
```

## Samples.MEF.ConstructorInjection

In diesem Beispiel wird gezeigt, wie Konstruktor-Injektion mit MEF gelöst werden kann.
Als Erstes werden alle Assemblies nach Imports und Exports durchsucht
```csharp
            var directoryCatalog = new DirectoryCatalog(Directory.GetCurrentDirectory());
            var aggregateCatalog = new AggregateCatalog(directoryCatalog);
            var assemblyCatalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());
            aggregateCatalog.Catalogs.Add(assemblyCatalog);

            var container = new CompositionContainer(aggregateCatalog);
            container.ComposeParts(aggregateCatalog);
```
Danach wird wieder die Komposition durchgeführt.
```chsarp
            container.ComposeParts(this);
```

Fur das zu erstellende Objekt wird ein sogenannter ImportingConstructor erstellt
```chsarp
            [ImportingConstructor]
            public Pizza(
                [Import(typeof(IDough))] IDough dough,
                [Import(typeof(ITopping))] ITopping topping)
            {
              ...
            }
```

Die Exports werden wie üblich an den jeweiligen Objekten definiert. Sind mehrere Parameter vom selben Typ,
kann der Contract wieder mit Namen angegeben werden.


## Weitere Informationen

https://msdn.microsoft.com/de-de/library/dd460648(v=vs.110).aspx

https://stefanhenneken.wordpress.com/category/managed-extensibility-framework/
