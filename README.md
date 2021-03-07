# CheckOrSaveBusiness Introduction
Contains two simple dependency injection factories and two chains to check or save something you want.

# Factory Injection

## Manual injection
```csharp
Register<MyselfChecker>("MYER");	//CheckOrSaveBusiness.Factories.CheckerFactory.Register()
Register<MyselfSaver>("MYER");		//CheckOrSaveBusiness.Factories.SaverFactory.Register()
```

## Injection automatically with attribute
```cahsrp
[CheckerName("MYER")]
public class MyelfChecker : IChecker
{
	public void Init(string config)
	{
		//...
	}

	public Result Check()
	{
		//...
		return Result.Success();
	}
}

[SaverName("MYER")]
public class MyelfSaver : ISaver
{
	public void Init(string config)
	{
		//...
	}

	public Result Save()
	{
		//...
		return Result.Success();
	}
}
```

# Create Chain And Run
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