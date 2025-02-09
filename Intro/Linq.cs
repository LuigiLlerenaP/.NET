using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intro
{
	/*
	 ==========================================
	 📌 **LINQ en C#** (*Language Integrated Query*) 
	 ==========================================
	🔹 **¿Qué es LINQ?**  
		Es un conjunto de métodos y expresiones que permiten **consultar y 
			manipular colecciones** de manera declarativa, similar a SQL.
		Se puede usar con **listas, arreglos, bases de datos (Entity Framework), XML y más.**
	🔹 **Ventajas de LINQ**  
		✅ Permite realizar **ordenamientos, filtrados y agrupaciones** fácilmente.  
		✅ Funciona con **cualquier colección que implemente `IEnumerable<T>` o `IQueryable<T>`**.  
		✅ Puede trabajar con **datos en memoria** o con **fuentes externas** como bases de datos.  
		✅ Si no es una colección, podemos usar `.AsEnumerable()` para tratarlo como tal.  
	 */
	public static class Linq
	{
		private static List<string> names = [ 
		"Luigi" ,"Antho" , "Maria" , "Juan" , "Juana" , "Miguel"
		] ;


		/*
		 ==========================================
		 📌 **Seleccionar elementos (Proyección)**
		 ==========================================
		   - `Select(n => n * 2)` → Transforma cada elemento en otro valor.  
		   - Sintaxis de consulta:  
			 ```csharp
			 var resultado = from n in lista select n * 2;
			 ```
		   - No es necesario especificar el tipo en `ToList<T>()`, ya que el compilador lo infiere automáticamente.
		   -`ToList()` fuerza la ejecución inmediata de la consulta, almacenando los resultados en memoria.
			 ⚠️ Puede ser costoso si la colección tiene muchos elementos. 
		   - Si no usamos `ToList()`, la consulta se ejecutará solo,
			 cuando se itere sobre los datos (ej. con `foreach`), aprovechando la ejecución diferida de LINQ.
		 */

		public static List<string> NamesUperCase()
		{
			return (from n in names
							  select n.ToUpper()).ToList<string>();
		}
		public static List<string> namesLowerCase() 
		{ 
			return names.Select(n => n.ToLower()).ToList();
		}
		public static IEnumerable<string> namesWhitouSpace() 
		{ 
			return names.Select(n => n.Trim());
		}
		/*
		 ==========================================
		 📌 **Filtrar elementos con LINQ**
		 ==========================================
		   - Where nos permite filtrar datos con una condicion especifico
		   - `Where(n => n == 5)` → Filtra los elementos que sean iguales a 5.  
		   - `Where(n => n > 5)` → Filtra los elementos mayores a 5.  
		   
		 🔹 **Diferencia entre sintaxis de consulta y expresión lambda:**  
		   - En la **sintaxis de consulta** (`from ... where ...`), es obligatorio incluir `select` para definir qué datos devolver.  
		   - En la **expresión lambda** (`Where(n => condición)`), no es necesario un `select`, ya que el método devuelve directamente los elementos filtrados. 
		 */
		public static List<string> NamesWithStartL()
		{
			return (from n in names
					where n.StartsWith("L") 
					select n ).ToList();
		}
		public static IEnumerable<string> NamesWithLengthGreaterThan4()
		{
			return names.Where(name => name.Length > 4);
		}

		public static IEnumerable<string> NamesWithLengthGreaterThan4AndContainsA()
		{
			return names.Where(name => name.Length > 4 && name.Contains('A'));
		}

		/*
		 ==========================================
		 📌 **Ordenar elementos**
		 ==========================================
		   - `OrderBy(n => n)` → Orden ascendente.  
		   - `OrderByDescending(n => n)` → Orden descendente.  
		   - Sintaxis de consulta:  
			 ```csharp
			 var resultado = from n in lista orderby n select n; // Ascendente
			 var resultadoDesc = from n in lista orderby n descending select n; // Descendente
			 ```
		 */

		public static IEnumerable <string> NamesAsc() 
		{
			return (from n in names 
					orderby n 
					select n );
		}
		public static List<string> NamesDesc() { 
			return  names.OrderByDescending(n => n).ToList();
		}

		/*
		 ==========================================
		 📌 **Tomar y saltar elementos**
		 ==========================================
		   - `Take(n)` → Toma los primeros `n` elementos.  
		   - `Skip(n)` → Omite los primeros `n` elementos.  
		 */
		public static IEnumerable<string> NamesTakeTrhee() 
		{
			return (from n in names
					select n ).Take(3);
		}
		public static List<string> NamesTakeTwo() 
		{
			return names.Take(2).ToList(); 
		}

		public static IEnumerable<string> NamesSkipeOne() 
		{
			return names.Skip(1);
		}
		/*
		 ==========================================
		 📌 **Agrupar elementos**
		 ==========================================
		   - Permite organizar los datos en grupos según una clave específica.
		   - `GroupBy(n => n % 2 == 0 ? "Pares" : "Impares")` → Agrupa elementos según una clave.  
		   - Sintaxis de consulta:  
			 ```csharp
			 var grupos = from n in lista
						  group n by (n % 2 == 0 ? "Pares" : "Impares") into g
						  select g;
			 ```
		 */
		public static IEnumerable<IGrouping<char, string>>  NamesGrupingByLeter()
		{
			return (from name in names
					group name by name[0] into nameGrup
					select nameGrup);
		}

		public static List<(char, List<string>)> NamesGroupingByLastLetterList()
		{
			return names.GroupBy(name => name[name.Length - 1])
			.Select(g => (g.Key, g.ToList()))
			.ToList();
		}


		/*
		 ==========================================
		 📌 **Operaciones Útiles**
		 ==========================================
		   - `Any()` → Verifica si hay al menos un elemento que cumple una condición.  
		   - `All()` → Verifica si **todos** los elementos cumplen una condición.  
		   - `Count()` → Cuenta los elementos de la colección.   
		  */
		public static bool AnyNameStartsWithM()
		{
			return names.Any(name => name.StartsWith("M")); // true
		}
		public static bool AllNamesHaveMoreThanThreeCharacters()
		{
			return names.All(name => name.Length > 3); // true
		}
		public static int CountNamesWithFiveOrMoreCharacters()
		{
			return names.Count(name => name.Length >= 5); // 4
		}


	}
}
