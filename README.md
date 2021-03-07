# Introduction
Contains two simple dependency injection factories and two chains to check or save something you want.

# Factory injection

## Manual injection
```csharp
Register<MyselfChecker>("MYER");	//CheckOrSaveBusiness.Factories.CheckerFactory.Register()
Register<MyselfSaver>("MYER");		//CheckOrSaveBusiness.Factories.SaverFactory.Register()
```

## Injection automatically with attribute
```csharp
[CheckerName("MYER")]
public class MyelfChecker : IChecker { //... }

[SaverName("MYER")]
public class MyelfSaver : ISaver { //... }
```

# Create chain and run
```csharp
CheckerChain checker = new CheckerChain("MYER", "TEST1");
CheckerChain anotherChecker = new CheckerChain("YOUR", "TEST2");
checker.SetNext(anotherChecker);
checker.Check();

SaverChain saver = new SaverChain("MYER", "TEST1");
SaverChain anotherSaver = new SaverChain("YOUR", "TEST2");
saver.SetNext(anotherSaver);
saver.Save();

//Or create from a string
string config = "MYER:TEST1;YOUR:TEST2;";
CheckerChain checker = CheckerChain.CreateChainFromConfig(config);
checker.Check();
SaverChain saver = SaverChain.CreateChainFromConfig(config);
saver.Save();
```