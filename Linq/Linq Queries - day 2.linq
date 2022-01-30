<Query Kind="Expression" />

void Main()
{
	//Program IDE
	//you can have multiple queries written in this IDE environment
	//this environment works "like" a console application

	//This allows one to pret-test complete components that can
	//		be move directly into your backend application (class library)

	//IMPORTANT
	//queries in this environmet MUST be written useing the
	//		C# language grammar for a statement. This means that
	//		each statement must end in a semi-colon
	//results MUST be placed in a receiving variable
	//to display the results, use the Linqpad method .Dump()

	//query syntax
	//query: Find all albums released in 2000. Display the entire
	//			album record
	var paramyear = 1990; //simulates the invoming method parameter
	var resultsq = GetAllQ(paramyear);
	resultsq.Dump();


	//method syntax
	paramyear = 2000; //simulates the invoming method parameter
	var resultsm = GetAllM(paramyear);
	resultsm.Dump();

}

// You can define other methods, fields, classes and namespaces here

//imagine this is a method in your BLL service
public List<Albums> GetAllQ(int paramyear)
{
	var resultsq = from x in Albums
				   where x.ReleaseYear == paramyear
				   select x;
	return resultsq.ToList();
}

public List<Albums> GetAllM(int paramyear)
{
	var resultsm = Albums
				   .Where(x => (x.ReleaseYear == paramyear))
				   .Select(x => x);
	return resultsm.ToList();

	//Statements IDE

	//you can have multiple queries written in this IDE environment
	//you can execute a query individually by highlighting
	//	the desired query first
	//BY DEFAULT executing a file in this environment executes
	//		ALL queries, top to bottom

	//IMPORTANT
	//queries in this environmet MUST be written useing the
	//		C# language grammar for a statement. This means that
	//		each statement must end in a semi-colon
	//results MUST be placed in a receiving variable
	//to display the results, use the Linqpad method .Dump()

	//query syntax
	//query: Find all albums released in 2000. Display the entire
	//			album record
	var paramyear = 1990;
	var resultsq = from x in Albums
				   where x.ReleaseYear == paramyear
				   select x;
	//resultsq.Dump();


	//method syntax
	Albums
	   .Where(x => (x.ReleaseYear == 2000))
	   .Select(x => x)
	   .Dump();


	//Where
	//filter method
	//the conditions are setup as you would in C#
	//beware that Linqpad may NOT like some C# syntax (DateTime)
	//beware that Linq is converted to SQL which may not
	//	like certain C# syntax because SQL could not convert

	//syntax
	//Notice that the method syntax makes uses of Lambda expressions. 
	//Lambdas are common when performing LINQ with the Method syntax.
	//.Where(LambDa expression)
	//.Where(x => condition [logical orperator condition2 ...])

	//Find all albums released in 2000. Display the entire
	//			album record
	Albums
	   .Where(x => (x.ReleaseYear == 2000))
	   .Select(x => x)

//Find all albums released in the 90s (1990 -1999)
//Display the entire album record

	Albums
	.Where(x => x.ReleaseYear >= 1990
			&& x.ReleaseYear < 2000)
	.Select(x => x)

//Find all the albums of the artist Queen.
//concern: the artist name is in another table
//			in an sql Select query you would be using an inner Join
//			in Linq you DO NOT need to specific your inner Joins
//			instead use the "navigational properties" of your entity
//				to generate the relationship

	//.Equals() is an exact match, in sql = (like 'string')
	//.Contains() is a string match, in sql like '%' + string + '%'
	Albums
	.Where(a => a.Artist.Name.Contains("Queen"))
	.Select(x => x)


//Find all albums where the producer (Label) is unknown (null)

	Albums
	.Where(x => x.ReleaseLabel == null)
	.Select(x => x)

