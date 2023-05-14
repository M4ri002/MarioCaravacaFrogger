using System;
using System.Collections.Generic;
using System.Threading;

namespace M05_UF3_P3_Frogger
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false; //Hace que el cursor no se vea en la pantalla
            Console.WindowHeight = Utils.MAP_HEIGHT + 1; //Ajusta el tamaño de la ventana
            Console.WindowWidth = Utils.MAP_WIDTH;//Ajusta el tamaño de la ventana

            List<Lane> lanes = new List<Lane>(); //Declaramos una lista y le vamos añadiendo todas las lineas declaradas en Lane pasandole por parametro los datos correspondientes. 
            lanes.Add(new Lane(1, false, ConsoleColor.DarkGreen, false, false, 0f,Utils.charLogs, new List<ConsoleColor> { Utils.colorsLogs[0], Utils.colorsLogs[1] })); 
            lanes.Add(new Lane(2, true, ConsoleColor.DarkBlue, false, true, 0.8f, Utils.charLogs, new List<ConsoleColor> { Utils.colorsLogs[1], Utils.colorsLogs[0] }));
            lanes.Add(new Lane(3, true, ConsoleColor.DarkBlue, false, true, 0.6f, Utils.charLogs, new List<ConsoleColor> { Utils.colorsLogs[1], Utils.colorsLogs[1] }));
            lanes.Add(new Lane(4, true, ConsoleColor.DarkBlue, false, true, 0.7f, Utils.charLogs, new List<ConsoleColor> { Utils.colorsLogs[1], Utils.colorsLogs[0] }));
            lanes.Add(new Lane(5, true, ConsoleColor.DarkBlue, false, true, 0.6f, Utils.charLogs, new List<ConsoleColor> { Utils.colorsLogs[0], Utils.colorsLogs[1] }));
            lanes.Add(new Lane(6, true, ConsoleColor.DarkBlue, false, true, 0.7f, Utils.charLogs, new List<ConsoleColor> { Utils.colorsLogs[0], Utils.colorsLogs[1] }));
            lanes.Add(new Lane(7, false, ConsoleColor.DarkGreen, false, false, 0f, Utils.charLogs, new List<ConsoleColor> { Utils.colorsLogs[0], Utils.colorsLogs[1] }));
            lanes.Add(new Lane(8, false, ConsoleColor.Black, true, false, 0.2f, Utils.charCars, new List<ConsoleColor> { Utils.colorsCars[2], Utils.colorsCars[3] }));
            lanes.Add(new Lane(9, false, ConsoleColor.Black, true, false, 0.2f, Utils.charCars, new List<ConsoleColor> { Utils.colorsCars[1], Utils.colorsCars[1] }));
            lanes.Add(new Lane(10, false, ConsoleColor.Black, true, false, 0.2f, Utils.charCars, new List<ConsoleColor> { Utils.colorsCars[0], Utils.colorsCars[1] }));
            lanes.Add(new Lane(11, false, ConsoleColor.Black, true, false, 0.1f, Utils.charCars, new List<ConsoleColor> { Utils.colorsCars[1], Utils.colorsCars[1] }));
            lanes.Add(new Lane(12, false, ConsoleColor.Black, true, false, 0.1f, Utils.charCars, new List<ConsoleColor> { Utils.colorsCars[2], Utils.colorsCars[3] }));
            lanes.Add(new Lane(13, false, ConsoleColor.DarkGreen, false, false, 0f, Utils.charCars, new List<ConsoleColor> { Utils.colorsCars[2], Utils.colorsCars[3] }));
            Player player = new Player(); //Instanciamos al player

            bool running = true;
            while (running) //Creamos un bucle controlado por un bool que dependera del Utils.GAME_STATE
            {
                Utils.GAME_STATE gameState = player.Update(Utils.Input(), lanes); //Igualamos gameState a la funcion update del player porque esta funcion devuelve WIN,LOOSE o RUNNING

                if (gameState == Utils.GAME_STATE.WIN) //Si gana la partida...
                {
                    Console.Clear(); //Limpiamos consola
                    Console.ForegroundColor = ConsoleColor.Gray; //Ponemos color gris (Que afecta al texto en este caso)
                    Console.SetCursorPosition(Console.WindowWidth / 2 - 5, Console.WindowHeight / 2);//Esto centra el texto en medio de la pantalla
                    Console.WriteLine("¡HAS GANADO!"); //Printa este texto
                    running = false;// Salimos del bucle y acaba el programa
                }
                else if (gameState == Utils.GAME_STATE.LOOSE)//Si pierde la partida...
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(Console.WindowWidth / 2 - 5, Console.WindowHeight / 2);
                    Console.WriteLine("¡HAS PERDIDO!");
                    running = false;
                }
                else //Si no se cumple ninguno de los anteriores, es decir el estado de la parida es RUNNING
                {
                    Console.Clear();

                    foreach (Lane lane in lanes)
                    {
                        lane.Update(); //Llamamos a la funcion Update 
                        lane.Draw(); //Llamamos a la funcion Draw 
                    }

                    player.Draw(lanes);//Dibujamos al personaje
                }

                TimeManager.NextFrame();// Pasamos al siguiente fotograma
            }

            Console.CursorVisible = true;//Cursor visible
            Console.WriteLine("\nPresiona cualquier tecla para salir...");
            Console.ReadKey();//Espera un input del usuario
        }
    }
}
