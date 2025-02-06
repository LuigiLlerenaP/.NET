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
Sale sale = new Sale(100);

// Forma 2: Usando `var` (el compilador infiere el tipo automáticamente)
var saleTwo = new Sale(100, 200);

// Forma 3: Utilizando la sintaxis de inicialización implícita (C# 9+)
Sale saleThree = new(100, 200);



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
	public string GetInfo(string message)
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