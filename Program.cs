
using NaveEspacial;
using System.Drawing;

Ventana ventana;
Nave nave;
Enemigos enemigo1;
Enemigos enemigo2;
Enemigos enemigoBoss;
bool jugar = true;
bool BossFinal = false;

void Iniciar()
{
    ventana = new Ventana(170, 45, ConsoleColor.Black, new Point(5, 3), new Point(165, 43)); // 213 y 50
    ventana.DibujaMarco();
    nave = new Nave(new Point(80,30),ConsoleColor.Red,ventana);
    nave.Dibujar();
    enemigo1 = new Enemigos(new Point(50,10),ConsoleColor.Cyan,ventana,TipoEnemigo.Normal,
        nave);
    enemigo1.Dibujar();
    enemigo2 = new Enemigos(new Point(20,12), ConsoleColor.Red, ventana, TipoEnemigo.Normal
        ,nave);
    enemigo2.Dibujar();
    enemigoBoss = new Enemigos(new Point(100, 10), ConsoleColor.Magenta, ventana, TipoEnemigo.Boss,
        nave);

    nave.Enemigos.Add(enemigo1);
    nave.Enemigos.Add(enemigo2);
    nave.Enemigos.Add(enemigoBoss); 

}
void Game ()
{
    while(jugar)
    {
        if(!enemigo1.Vivo && !enemigo2.Vivo && !BossFinal)
        {
            BossFinal = true;
            ventana.Peligro();
        }
        if(BossFinal)
        {
            enemigoBoss.Mover();
            enemigoBoss.Informacion(140);
        }
        else
        {
            enemigo1.Mover();
            enemigo1.Informacion(100);
            enemigo2.Mover();
            enemigo2.Informacion(120);
        }

        nave.Mover(2);
        nave.Disparar();
        if(nave.Vida <= 0 )
        {
            jugar = false;
            nave.Muerte();
        }
        if(!enemigoBoss.Vivo)
        {
            jugar = false;
        }
    }
}
Iniciar();
Game();
