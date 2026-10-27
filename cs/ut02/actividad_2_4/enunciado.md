# UT02 - Actividad 4

En esta actividad vamos a trabajar con dos clases: `Jugador` y `Equipo`, implementadas en archivos independientes (`Jugador.cs` y `Equipo.cs`).

Realiza los siguientes apartados en orden y efectúa el commit indicado después de completar cada uno.

| Apartado | Tarea a realizar | Descripción del commit |
|----------|------------------|------------------------|
| a | Copia el directorio `src/cs/ut02/actividad_2_4` proporcionado por el profesor en su repositorio, de manera que quede ubicado en **la misma ruta dentro de tu propio repositorio**. Encontrarás los archivos `Jugador.cs` y `Equipo.cs` dentro de la carpeta del proyecto `actividad_2_4`. | `UT02A04a Copiado proyecto proporcionado por el profesor` |
| b | Añade a la clase `Jugador` un método público `GetNombreCorto()`, **sin parámetros y que devuelva un `string`**. El método deberá devolver el valor del atributo `apodo`, salvo que este sea una cadena vacía (`""`), en cuyo caso devolverá el valor del atributo `nombre`. | `UT02A04b Implementado método GetNombreCorto en Jugador` |
| c | Añade a la clase `Jugador` un método público `GetNombreEquipo()`, **sin parámetros y que devuelva un `string`**, que permita obtener el nombre del equipo al que está vinculado el jugador. Para ello, deberás acceder al atributo `nombre` del objeto `Equipo` referenciado por el atributo `equipo` del jugador. | `UT02A04c Implementado método GetNombreEquipo en Jugador` |
| d | Mejora el método `GetNombreEquipo()` para que compruebe si la referencia `equipo` del jugador es válida. Si es `null`, deberá devolver la cadena `"<<sin equipo>>"` en lugar de intentar acceder a un objeto inexistente. | `UT02A04d Añadido control de referencia nula en GetNombreEquipo` |
| e | Implementa en la clase `Equipo` el método público `Fichar()`, que recibirá como parámetro una referencia a un objeto `Jugador`. El método deberá **vincular el jugador recibido al equipo que realiza el fichaje**, asignando la referencia correspondiente al atributo `equipo` del jugador. | `UT02A04e Implementado método Fichar en Equipo` |
| f | Desarrolla código en `Program.Main()` para **crear un objeto `Equipo` y dos objetos `Jugador`**, asignándoles los datos que inventes. Realiza las operaciones necesarias para probar todos los métodos implementados en los apartados anteriores, mostrando por consola los resultados. Asegúrate de comprobar también el comportamiento de `GetNombreCorto()` cuando un jugador no tiene apodo y de `GetNombreEquipo()` antes y después de fichar a un jugador. | `UT02A04f Creados objetos y probados los métodos implementados` |

## TIPS

**TIP 1. Comprobar si una referencia apunta a un objeto**

En C#, una referencia con valor `null` no apunta a ningún objeto. Puedes comprobarlo mediante una condición:

```csharp
if (equipo == null)
{
    // La referencia no apunta a ningún objeto
}
```

También puedes utilizar `equipo != null` para comprobar que la referencia sí apunta a un objeto.

**TIP 2. Referirse al propio objeto mediante `this`**

En C#, la palabra clave `this` permite que un objeto **haga referencia a sí mismo** desde cualquiera de sus métodos de instancia.

Por ejemplo:

```csharp
class Persona
{
    public Persona amigo;

    public void HacermeAmigoDeMiMismo()
    {
        amigo = this;
    }
}
```

En este ejemplo, `this` representa al objeto `Persona` que está ejecutando el método. Por tanto, después de llamar a `HacermeAmigoDeMiMismo()`, el atributo `amigo` apuntará al propio objeto.

**Recuerda:** puedes utilizar `this` cuando necesites pasar o asignar una referencia al objeto actual, en lugar de crear uno nuevo.
