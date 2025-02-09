/*
  ====================
   C# 
  ====================
  - Descripción: Es un lenguaje multiparadigma, compilado y de tipado fuerte. 
    También admite tipado dinámico, aunque funciona de manera diferente a JavaScript.

  - Objetos: El paradigma más fuerte en C# es la Programación Orientada a Objetos (POO), 
    aunque es posible combinar otros paradigmas.

  - Clase: Es un molde o estructura que permite definir un objeto concreto basado en ella. 
    A partir de una clase, se pueden instanciar objetos, que representan entidades del mundo real 
    o conceptos mediante abstracción. 

    Una clase posee:
    - **Atributos**: Representan las características del objeto o concepto.
    - **Métodos**: Son las funcionalidades que puede realizar el objeto  o el concepto.
*/

/*
  ====================
   Var c# vs Var js
  ====================
    🔹 **var en C# (tipado estático - compilado)**
      - Es una variable de **tipado implícito**, pero el tipo se determina en tiempo de compilación.
      - Una vez asignado, **no puede cambiar de tipo**.

    🔹 **var en JavaScript (tipado dinámico - interpretado)*
      - Permite cambiar el tipo de valor en cualquier momento.

 */

/*
  ====================
   Propiedades en C#
  ====================
  - En C#, las propiedades (`get` y `set`) pueden definirse directamente mediante `{ get; set; }`.
  - Es posible definir solo un `get` sin un `set`, haciendo que la propiedad sea de solo lectura.
  - Los `set` y `get` pueden ser privados, dependiendo de los requisitos.

  Reglas de nomenclatura:
  - Si una propiedad es privada y no tiene `get` ni `set`, se recomienda usar el prefijo `_` (snake_case).
  - Las propiedades públicas con `get` y `set` deben seguir PascalCase.
*/



/*
   ====================
   Constructor en C#
   ====================
   - Un constructor es un método especial que tiene el mismo nombre que la clase.
   - Su función principal es inicializar objetos y asignar valores en el momento de su creación.
   - En C#, si no se define un constructor, el compilador genera uno vacío por defecto.
   - Se pueden definir múltiples constructores mediante sobrecarga.
*/

/*
   ====================
   This y Base en C#
   ====================
   - **this**: Hace referencia a los atributos o métodos de la instancia actual de la clase.
     Se usa cuando hay ambigüedad entre nombres de parámetros y propiedades.
   - **base()**: Llama al constructor de la clase padre cuando se trabaja con herencia.
*/

/*
   ====================
   Sobrescritura de Equals en C#
   ====================
   - `Equals()` se usa para comparar si dos objetos son iguales.
   - Por defecto, `Equals()` compara referencias en memoria, lo que significa 
	 que dos instancias con los mismos valores no serán consideradas iguales.
   - Sobrescribiendo `Equals()`, podemos definir nuestra propia lógica para comparar 
	 los valores de los atributos y determinar si dos objetos son equivalentes.
*/

/*
   ====================
   Sobrescritura de GetHashCode en C#
   ====================
   - `GetHashCode()` genera un número entero único para representar el objeto.
   - Se usa en estructuras como `Dictionary`, `HashSet` y otras colecciones 
	 que dependen de comparaciones rápidas.
   - Si sobrescribimos `Equals()`, también debemos sobrescribir `GetHashCode()`
	 para mantener coherencia en las comparaciones.
   - Una implementación correcta debe combinar los valores de los atributos 
	 relevantes para obtener un código hash único.
*/

/*
   ====================
   Instanciación de un objeto en C#
   ====================
   En C#, hay tres formas principales de instanciar un objeto de una clase:
*/


// Forma 1: Declarando explícitamente el tipo de la clase
using System;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;

Sale sale = new Sale(100);
Console.WriteLine(sale);

// Forma 2: Usando `var` (el compilador infiere el tipo automáticamente)
var saleTwo = new Sale(100, 200);
Console.WriteLine(saleTwo);

// Forma 3: Utilizando la sintaxis de inicialización implícita (C# 9+)
Sale saleThree = new(100, 200);
Console.WriteLine(saleThree);

// Herencia 
SaleWithTax saleWithTax = new (100, 15.5M);
Console.WriteLine(saleWithTax);
Console.WriteLine("\nMain");
M.Main();
class Sale
{
	// Propiedad pública con acceso directo mediante { get; set; }
	public decimal Total { get; set; }

	// Campo privado con convención de prefijo "_"
	private decimal _totalAmount;

	// Propiedad con validación en el setter
	public decimal TotalAmount
	{
		get => _totalAmount;
		set
		{
			// 'value' representa el valor que se intenta asignar
			if (value < 0)
			{
				Console.WriteLine("El total no puede ser negativo.");
				return;
			}
			_totalAmount = value;
		}
	}

	// Constructor que inicializa 'Total'
	public Sale(decimal total)
	{
		Total = total;
	}

	// Sobrecarga de constructor que también inicializa 'TotalAmount'
	public Sale(decimal total, decimal totalAmount) : this(total)
	{
		TotalAmount = totalAmount;
	}

	// Método para obtener información del objeto
	public string GetInfo()
	{
		return $"Total: {Total}, Total Amount: {TotalAmount}";
	}

	// Sobrecarga de método con parámetro adicional
	public virtual string GetInfo(string message)
	{
		return $"{GetInfo()}\n{message}";
	}

	// Representación del objeto como cadena
	public override string ToString()
	{
		return $"Sale - Total: {Total}, Total Amount: {TotalAmount}";
	}

	// Sobrescritura de Equals (debería mejorarse comparando propiedades)
	public override bool Equals(object? obj)
	{
		// Verifica si el objeto recibido es de tipo Sale
		if (obj is Sale otherSale)
		{
			// Compara los valores de Total y TotalAmount para determinar si son iguales
			return Total == otherSale.Total && TotalAmount == otherSale.TotalAmount;
		}

		// Si el objeto no es de tipo Sale, no son iguales
		return false;
	}

	public override int GetHashCode()
	{
		// Combinar los valores de Total y TotalAmount para generar un hash único
		return HashCode.Combine(Total, TotalAmount);
	}
}


/*
   ====================
   Herencia en C#
   ====================
   La herencia en C# permite reutilizar código y 
   es un concepto fundamental en la programación orientada a objetos (POO).

   - Establece una relación de acoplamiento entre clases, 
	 donde una clase hija hereda el comportamiento y las propiedades de su clase padre.
   - Si la clase padre tiene un constructor con parámetros,
	 la clase hija debe invocarlo explícitamente en su propio constructor.
   - Para permitir que las clases hijas accedan a ciertos atributos o métodos sin hacerlos públicos,
	 se puede usar el modificador `protected`.
   - La herencia no solo permite reutilizar funcionalidades existentes, 
	sino también extenderlas añadiendo nuevos comportamientos en la clase hija.
   - La herencia solo permite una a la vez 
*/
/*
   ====================
   Polimorfismo en C#
   ====================
   El polimorfismo es la capacidad de un método o función de adoptar múltiples comportamientos 
   según la implementación específica.

   - Se puede sobrescribir un método en una clase derivada usando `override` 
	 para modificar su comportamiento.
   - También se puede extender su funcionalidad utilizando `base` para 
	 reutilizar la lógica de la clase padre.
   - El polimorfismo permite escribir código más flexible y reutilizable, 
	 adaptándose a distintas necesidades sin modificar la estructura base.
   - En C#, la sobrescritura de métodos no está habilitada por defecto, 
	 a diferencia de Java, donde los métodos pueden ser sobrescritos a menos que se marquen con `final`.
   - Para permitir la sobrescritura en C#, el método de la clase padre debe estar marcado 
	 con la palabra clave `virtual`.
   - Sobrecarga de metodos , dependera de la entrada de parametros y su tipo.
*/

class SaleWithTax : Sale
{
	public decimal Tax { get; set; }
	public SaleWithTax(decimal total, decimal tax) : base(total)
	{
		Tax = tax;
	}
	public override string GetInfo(string message)
	{
		return base.GetInfo(message) + "Your tax  is:  " + Tax;
	}
}

/*
  ===================
  Interfaces en C#
  ===================
  Una interfaz es un contrato que define un conjunto de métodos y propiedades que una clase debe implementar.

  - Permite **tipar y categorizar clases**, asegurando que cumplan con un comportamiento específico.
  - Se pueden definir métodos sin implementación, obligando a las clases que la implementen a proporcionar su propia lógica.
  - Los constructores y métodos pueden recibir una interfaz como parámetro, lo que permite el uso de **polimorfismo**.
  - Facilita el **desacoplamiento** y promueve buenas prácticas como la **inyección de dependencias**.
  - Se pueden combinar múltiples interfaces en una misma clase para lograr **composición** y evitar una jerarquía rígida de herencia.
  - No le interesa quién implementa la interfaz, solo que la implemente correctamente.
  - Nos manejamos por **abstracciones**.
 */

// Definición de interfaces
interface ISale
{
	decimal Total { get; set; }
}

interface ISave
{
	void Save(ISale sale);
}

interface INotification
{
	string Notification { get; set; }
	void Show();
}

// Implementación de una clase que usa ISale, ISave e INotification
public class SaleTwo : ISale, ISave, INotification
{
	public decimal Total { get; set; } = 0m;
	public string Notification { get; set; } = "Venta guardada exitosamente.";

	public void Show()
	{
		Console.WriteLine(Notification);
	}

	void ISave.Save(ISale sale)
	{
		Console.WriteLine($"Guardando la venta con un total de {sale.Total:C}...");
	}
}

// Implementación de la clase Beer que usa INotification e ISave
public class Beer : INotification, ISave
{
	public string Notification { get; set; } = "Se ha añadido una cerveza al carrito.";

	public void Show()
	{
		Console.WriteLine(Notification);
	}

	void ISave.Save(ISale sale)
	{
		Console.WriteLine($"Guardando la venta con un total de {sale.Total:C}...");
	}
}

// Programa de prueba
class M
{
	private static void Some(INotification notification)
	{
		notification.Show();
	}

	public static void Main()
	{
		SaleTwo saleTwo1 = new();
		Beer beer = new();

		// Prueba del método que recibe INotification
		Some(beer);
		Some(saleTwo1);
		MyList<string> names = new MyList<string>(3);
		names.Add("one");
		names.Add("two");
		names.Add("tree");
		names.Add("four");
		Console.WriteLine("Names:");
		Console.WriteLine(names.GetContent());
		MyList<int> numbers = new MyList<int>(3);
		numbers.Add(6);
		numbers.Add(1);
		numbers.Add(2);
		numbers.Add(3);
		Console.WriteLine("Numbers:");
		Console.WriteLine(numbers.GetContent());

		Console.WriteLine("🍺 Lista de Cervezas:");
		MyList<BeerTwo> beers = new MyList<BeerTwo>(4);
		beers.Add(new BeerTwo("Corona", "México"));
		beers.Add(new BeerTwo("Heineken", "Países Bajos"));
		beers.Add(new BeerTwo("Budweiser", "EE.UU."));
		beers.Add(new BeerTwo("Guinness", "Irlanda"));
		beers.Add(new BeerTwo("Stella Artois", "Bélgica"));
		beers.Add(new BeerTwo("Pilsner", "Ecuador"));
		Console.WriteLine(beers.GetContent());
		Console.WriteLine("Serializer");
		People person = new People("Luigi", "Ecuador", 25);
		Console.WriteLine(person);
		string json = JsonSerializer.Serialize(person);
		Console.WriteLine(json);
		string myJson = @"{ ""Name"":""Luigi"",""Country"":""Ecuador"",""Age"":25}";
		People? luigi = JsonSerializer.Deserialize<People>(myJson);

		Console.WriteLine(luigi);

		// 💡 Demostración de Structs en C#
		Console.WriteLine("\n Estructuras (Struct)");
		Point p1 = new Point(3, 5);
		Point p2 = p1; // Se copia el valor, no la referencia
		p2 = new Point(10, 15); // p1 sigue siendo (3,5), p2 ahora es (10,15)

		Console.WriteLine($" p1: {p1}");  // 📍 p1: (3, 5)
		Console.WriteLine($" p2: {p2}");  // 📍 p2: (10, 15)

		// 💡 Demostración de Clases y Referencias
		Console.WriteLine("\n Clases y referencias");
		People person2 = new People("Luigi", "Ecuador", 25);
		Console.WriteLine(" Antes de asignar la referencia a otro objeto:");
		Console.WriteLine($" {person2}");

		People person3 = person2; // person3 apunta a la misma referencia que person2
		person3.Age = 30; // Se modifica la edad en la misma instancia

		Console.WriteLine("\n Después de modificar la referencia:");
		Console.WriteLine($" person2: {person2}"); // 🎂 Edad: 30 años
		Console.WriteLine($" person3: {person3}"); // 🎂 Edad: 30 años

		// 💡 Demostración de Strings (Inmutabilidad)
		Console.WriteLine("\n Strings e inmutabilidad");
		string name1 = "Luigi";
		string name2 = name1; // Se copia la referencia
		name2 = "Mario"; // Se crea una nueva instancia en memoria

		Console.WriteLine($" name1: {name1}"); // Luigi (no cambia)
		Console.WriteLine($" name2: {name2}"); // Mario (es un nuevo string)

		Console.WriteLine(person2);
		Console.WriteLine(peopleToUp(person2));
		//Funcion puera, no muta al objeto por que crear un nuevo objeto 
		People peopleToUp(People people)
		{
			return new People()
			{
				Name = people.Name.ToUpper(),
				Country = people.Country.ToUpper(),
				Age = people.Age
			};
		}


		// Función de primera clase (orden superior)
		var peopleUp = peopleToUp;

		SomeP(peopleUp, "Hey", person2);
		//Funcion de Orden superiror
		void SomeP(Func<People, People> action, string message, People people)
		{
			Console.WriteLine("Start");
			Console.WriteLine(message);
			Console.WriteLine(action(people));
			Console.WriteLine("End");
		}

		//Landa 
		Operacion sum = (int a, int b) => {
			return a + b;
		};

		Operacion  sumTwo = (a,b)=> a + b;

		sum(5, 5);
		sumTwo(5, 5);

		SumPrint sumThree = (a, b , result) => {
			Console.WriteLine($"Suma de el numero {a} + {b} = {result}");
		};

		SomeThree(sumThree, sumTwo, 3);

		void SomeThree(SumPrint action, Operacion sum , int number)
		{
			int result = sum(number, number);
			action(number, number , result);
		}

		
	}
}

public delegate int Operacion(int a, int b);

public delegate void SumPrint(int a, int b, int result);

/*
  ============================
  Genéricos en C#
  ============================
  - Los genéricos nos permiten escribir código reutilizable y flexible que puede manejar
    diferentes tipos de datos sin perder seguridad en tiempo de compilación.
  - Son útiles cuando queremos trabajar con múltiples tipos sin duplicar lógica.
  - Se definen con `<T>` y permiten operar con cualquier tipo sin necesidad de conversión manual.
  - Ejemplo común: List<T>, Dictionary<TKey, TValue>, MyList<T>.
*/


public class MyList<T>
{
	private List<T> _list;
	private int _limit;


	public MyList(int limit)
	{
		_limit = limit;
		_list = new List<T>();
	}

	public void Add(T item) {
		if (_list.Count < _limit)
		{
			_list.Add(item);
		}
	}
	public string GetContent()
	{
		return _list.Count > 0 ? string.Join(", ", _list) : "Lista vacía";
	}
}

public class BeerTwo
{
	public string Name { get; set; }
	public string Country { get; set; }
	public BeerTwo(string name, string country)
	{
		Name = name;
		Country = country;
	}
	public override string ToString() => $"\nName {Name} Country {Country}";
}
/*
  ============================
  📌 Struct en C#
  ============================
  - Un `struct` (estructura) es un tipo de dato que **se pasa por valor**, a diferencia de las clases (`class`), que se pasan por referencia.
  - Esto significa que al modificar una copia de un `struct`, **no se altera el original**.
  - Son más eficientes en memoria para datos pequeños y no requieren asignación en el heap (memoria dinámica).
  - Se utilizan comúnmente para representar datos inmutables o estructuras de datos simples.
*/

public struct Point
{
	public int X { get; }
	public int Y { get; }

	public Point(int x, int y)
	{
		X = x;
		Y = y;
	}

	public override string ToString()
	{
		return $"Punto: ({X}, {Y})";
	}
}


/*
  ============================
  📌 JSON en C#
  ============================
  - JSON (JavaScript Object Notation) es un formato ligero de intercambio de datos.
  - En C#, podemos convertir (serializar) objetos a formato JSON y viceversa (deserializar).
  - Para esto, podemos utilizar la biblioteca integrada `System.Text.Json` o `Newtonsoft.Json` (más avanzada).
  - La serialización convierte un objeto en una cadena JSON.
  - La deserialización convierte una cadena JSON en un objeto C#.
*/


public class People
{
	public string Name { get; set; } 
	public string Country { get; set; }
	public int Age { get; set; }
	public People()
	{
		Name = "Desconocido";
		Country = "Desconocido";
		Age = 0;
	}
	public People(string name, string country, int age)
	{
		Name = name;
		Country = country;
		Age = age;
	}


	public override string ToString()
	{
		return $"Nombre: {Name},País: {Country}, Edad: {Age} años";
	}
}

/*
  ============================
  📌 Paradigma Funcional en C#
  ============================
  - 📌 **Función pura**: Es una función que siempre devuelve el mismo resultado para los mismos valores de entrada.
  - 🚫 **No tiene efectos secundarios**: No modifica variables globales, archivos, bases de datos ni otros estados externos.
  - 🔄 **Determinismo**: Su salida depende únicamente de sus argumentos de entrada, sin importar factores externos.
  - 🏆 **Ejemplo**: Si le pasamos dos números, siempre devolverá el mismo resultado sin alterar nada más en el programa.
 	
 */


/*
  =============================
  📌 **Función de Primera Clase**
  =============================
  - En C#, las funciones son ciudadanos de primera clase, lo que significa que pueden:
    ✅ Ser almacenadas en variables.
    ✅ Pasarse como parámetros a otras funciones.
    ✅ Retornarse como resultado de una función.

  - Podemos usar **delegados** como `Action<T>` y `Func<T, TResult>` para manejar funciones:
    🔹 `Action<T>`: Representa un método que **no devuelve valor** (`void`).
    🔹 `Func<T, TResult>`: Representa un método que **devuelve un valor**.

  - Esto permite mayor flexibilidad y funcionalidad, como:
    ✅ Composición de funciones.
    ✅ Callbacks para ejecutar código después de un proceso.
    ✅ Construcción de código más modular y reutilizable.
*/


/*
 =============================
  📌 **Funciones Lambda y Delegados en C#**
  =============================
  🔹 **Función Lambda**  
     Una función lambda en C# es una forma concisa de definir una función anónima (sin nombre).  
     Se usan comúnmente como parámetros en funciones de orden superior o cuando no es necesario reutilizar la función en otro lugar.  
     Suelen emplearse con `Action<>`, `Func<>` y `Predicate<>` para simplificar código.

     📌 Ejemplo:  
     ```csharp
     Func<int, int, int> sum = (a, b) => a + b;
     Console.WriteLine(sum(5, 3)); // Salida: 8
     ```

  🔹 **Delegados en C#**  
     Un delegado es un tipo que define una firma de función, lo que permite almacenar referencias a métodos con la misma firma.  
     Son útiles para evitar la definición repetitiva de tipos de funciones y mejorar la reutilización del código.

     📌 Beneficios de los Delegados:  
     ✅ Permiten pasar métodos como parámetros.  
     ✅ Hacen el código más flexible y reutilizable.  
     ✅ Se pueden usar con eventos y callbacks.  
 */

