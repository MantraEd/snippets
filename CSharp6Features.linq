<Query Kind="Program" />

void Main()
{

//string interpolation
var foo = 34;
var bar = 42;

// String interpolation notation (new style)
Console.WriteLine($"The foo is {foo}, and the bar is {bar}.");

//Null progation
Coordinate c = new Coordinate();
Console.WriteLine(c.Manny?.Length);

}

//Auto-property initializers
public class Coordinate
{ 
    public int X { get; set; } = 34; // get or set auto-property with initializer

    public int Y { get; } = 89;      // read-only auto-property with initializer
           
    public int Z { get; }            // read-only auto-property with no initializer
                                     // so it has to be initialized from constructor    
	public string Manny{get;}

    public Coordinate()              // constructor
    {
        Z = 42;
    }
}
