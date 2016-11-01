<Query Kind="Program" />

public enum ModalityType
{
    Phone = 1,
    Email = 2
}

void Main()
{	
	foreach (var mt in Enum.GetValues(typeof(ModalityType)))
	{
	    Console.WriteLine($"ID: {(int)mt} Name:{mt.ToString()}");
	}	
	//or
	var mts = Enum.GetValues(typeof(ModalityType)).Cast<ModalityType>().ToList();	
	mts.ForEach(mt => {
		Console.WriteLine($"ID: {(int)mt} Name:{mt.ToString()}");
	});
}


