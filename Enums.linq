<Query Kind="Program">
  <Namespace>System.Collections.Generic</Namespace>
  <Namespace>System.ComponentModel</Namespace>
</Query>

//using System.ComponentModel;
//using System.Collections.Generic;
public enum ModalityType
{
    Phone = 1,
    Email = 2
}

public enum ContactStatusType
{
    [Description("Never Call")]
    NeverCall = 1,

    [Description("Never Email")]
    NeverEmail = 3,

    [Description("Hold Calls")]
    HoldCalls = 2,

    [Description("Hold Emails")]
    HoldEmails = 4,
	
    noDescription = 5,
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
	
	
	var cst = Enum.GetValues(typeof(ContactStatusType)).Cast<ContactStatusType>().ToList();	
	cst.ForEach(mt => {
		Console.WriteLine($"ID: {(int)mt} Name:{mt.ToString()} Description: {mt.Description()}");
	});
	
}

public static class EnumExtensions
{
	 public static string Description(this Enum value)  
	 {  
	      // variables  
	      var enumType = value.GetType();  
	      var field = enumType.GetField(value.ToString());  
	      var attributes = field.GetCustomAttributes(typeof(DescriptionAttribute), false);  
	   
	      // return  
	      return attributes.Length == 0 ? value.ToString() : ((DescriptionAttribute)attributes[0]).Description;  
	 }  
 } 
 
public static string GetDescription(Enum en)
{
    Type type = en.GetType();

    MemberInfo[] memInfo = type.GetMember(en.ToString());

    if (memInfo != null && memInfo.Length > 0)
    {
        object[] attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

        if (attrs != null && attrs.Length > 0)
        {
            return ((DescriptionAttribute)attrs[0]).Description;
        }
    }

    return en.ToString();
}


