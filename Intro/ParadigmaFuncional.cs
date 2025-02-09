using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intro
{
	internal class ParadigmaFuncional
	{
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
	}
}
