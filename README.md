# Juego de Ahorcado (SOLID)

## Descripción del Proyecto
Este proyecto es una implementación robusta y educativa del clásico juego del **Ahorcado** para la consola, ha sido desarrollado utilizando el lenguaje C# y sigue principios de diseño de software **SOLID**, lo que garantiza un código limpio, mantenible y escalable. El juego incluye un sistema de categorías (Arquitectura de Software, POO y .NET) y un motor de lógica independiente que gestiona los estados de victoria y derrota.

## Cómo se Juega
1.  **Inicio:** Al ejecutar el juego, se presenta un menú para seleccionar una de las categorías disponibles.
2.  **Adivinar:** El jugador debe ingresar una letra a la vez para intentar descubrir la palabra oculta.
3.  **Intentos:** Se dispone de un máximo de **6 intentos**. Cada error dibujará una parte del ahorcado en la pantalla.
4.  **Pista:** Si el jugador llega a tener 3 o menos intentos restantes, el sistema mostrará automáticamente una pista (la primera letra de la palabra) para ayudarlo.
5.  **Finalización:** El juego termina cuando se completa la palabra o se agotan los intentos. Al final, se ofrece la opción de jugar una nueva partida.

## Vistazo al Juego

<table>
  <tr>
    <td align="center">
      <img src="https://github.com/user-attachments/assets/9e449a53-9fbb-408f-8c1d-80ffa54a63b4" alt="Menú Principal" width="250"/><br/>
      <sub><b>Menú Principal</b></sub>
    </td>
    <td align="center">
      <img src="https://github.com/user-attachments/assets/ed45b715-99c4-4c4c-bc84-4ff84fc51742" alt="Selección de Categoría" width="250"/><br/>
      <sub><b>Selección de Categoría</b></sub>
    </td>
    <td align="center">
      <img src="https://github.com/user-attachments/assets/4331a540-d9ce-4769-b9c7-1858928a0023" alt="Tablero de Juego" width="250"/><br/>
      <sub><b>Partida en Curso</b></sub>
    </td>
  </tr>
  <tr>
    <td align="center" colspan="1">
      <img src="https://github.com/user-attachments/assets/04496cdc-486b-43a4-b933-344baeef5101" alt="Fin del Juego" width="250"/><br/>
      <sub><b>Progreso del Ahorcado</b></sub>
    </td>
    <td align="center" colspan="2">
      <img src="https://github.com/user-attachments/assets/7fbcf930-6a83-404f-be23-e389dd463325" alt="Resultado" width="250"/><br/>
      <sub><b>Resultado Final</b></sub>
    </td>
  </tr>
</table>

## Tecnologías Usadas
* **Lenguaje:** C#
* **Plataforma:** .NET (Versión 10.0)
* **Interfaz:** Consola de comandos (System.Console)
* **Patrones:** Inyección de dependencias y separación de responsabilidades (UI, Lógica de Negocio y Repositorio de Datos).

---
**Cláusula de uso de IA:**
Este proyecto utiliza Inteligencia Artificial para el diseño estético de la interfaz de consola, específicamente en la implementación de esquemas de color dinámicos (`Console.ForegroundColor`) y la disposición visual de los elementos para mejorar la experiencia del usuario.

### Análisis de Deuda Técnica y Principios SOLID

| Situación | Principio violado |
| :--- | :--- |
| `Juego` tiene 4 responsabilidades mezcladas | **SRP** — Single Responsibility Principle |
| Las palabras están hardcodeadas en la clase | **DIP** — Dependency Inversion Principle |
| Agregar un juego nuevo requiere modificar `Juego` | **OCP** — Open/Closed Principle |
