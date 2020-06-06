# TicTacToe

Проект изработен од Матеј Јакимовски во рамки на предметот Визуелно Програмирање
***
## Опис
Во рамките на овој проект е изработена класичната игра [X-Точка](https://en.wikipedia.org/wiki/Tic-tac-toe). 

Апликацијата е претставена со едноставен дизајн. Имплементирани се различни режими на игра, каде играчот може да избере дали ќе игра против друг играч или против компјутер со различни нивоа на тежина. 

## Упатство за користење

При стартување на апликација се прикажува главниот прозорец, каде што корисникот има опции да започне нова игра или да го промени дизајнот на таблата на која се исцртуваат играните потези. Во долниот десен агол се испишува статусот на играта, кој ни кажува дали во моментов има игра во тек, доколку играта е завршена, кој е победникот или доколку играта е во тек, ни кажува кој играч е на ред.
<p align="center">
<img src="https://github.com/Jakimovski/TicTacToe/blob/master/TicTacToe/Resources/OpenApp.png">
</p>

#### Започнување на нова игра
Доколку играчот одбере да започне нова игра, се отвора нов прозорец, каде што може да се избере дали играта да биде од типот играч против играч или играч против компјутер.

Ако корисникот одбере да започне игра против друг играч, се овозможуваат полиња за внес на имињата на двајцата играчи. Откако ќе се внесат имињата, се овозможува копчето „Start Game“.
<p align="center">
<img src="https://github.com/Jakimovski/TicTacToe/blob/master/TicTacToe/Resources/NewGamePVP.png">
</p>
Игра од типот играч против компјутер може да се започне така што ќе се одбере game mode „Player vs Computer“. Откако ќе се одбере ваков тип на игра, се нуди опција дали играчот сака да игра како „X“ или „О“. На крај се избира едно од нивоата на тежина со кое ќе игра компјутерот.
<p align="center">
<img src="https://github.com/Jakimovski/TicTacToe/blob/master/TicTacToe/Resources/NewGameComputer.png">
</p>
Откако ќе се кликне „Start Game“ копчето, прозорецот „Start new game“ се затвора и играта започнува.

#### Тек на играта
На главниот прозорец се појавува табела во која се испишува резултатот. Резултатот се ажурира по завршување на секој меч. Играчот кој ќе победи добива 1 поен, а доколку е нерешено и двајцата играчи добиваат по 0.5 поени.
<p align="center">
<img src="https://github.com/Jakimovski/TicTacToe/blob/master/TicTacToe/Resources/GameStarted.png">
</p>
Играта трае додека не се спојат 3 исти знаци, хоризонтално, вертикално или по дијагонала. Додека трае играта, играчот може да прави потези со кликнување на некое од слободните места на таблата.

#### Крај на играта
По завршување на секој меч се појавува прозорец преку кој играчот може да избере дали сака реванш или не. Доколку играчот одбере да игра реванш, се стартува нова игра во која се менуваат страните. Доколку не се игра реванш, се затвора прозорецот и се испишува името на победникот.
<p align="center">
<img src="https://github.com/Jakimovski/TicTacToe/blob/master/TicTacToe/Resources/GameFinished.png">
</p>

#### Customize Board
При клик на копчето „Customize Board“, се отвора нов прозорец во кој корисникот може да ги менува боите за „X“, „О“ и таблата врз која се игра.
<p align="center">
<img src="https://github.com/Jakimovski/TicTacToe/blob/master/TicTacToe/Resources/CustomizeBoard.png">
</p>
Откако ќе се изберат саканите бои, со клик на „Save Changes“ истите се зачувуваат и се менуваат во главниот прозорец.
<p align="center">
<img src="https://github.com/Jakimovski/TicTacToe/blob/master/TicTacToe/Resources/BoardCustomized.png">
</p>
Оваа функционалност е достапна во секое време, без разлика дали има игра во тек или не.

## Решение на проблемот

#### Класи
+ Главната логика на играта, потребните податоци, како и моменталната состојба се чуваат во класата `public class Game`. 
```c#
public class Game
    {
        /// <summary>
        /// Colors used for drawing
        /// </summary>
        public static Color ColorBoard { get; set; } = Color.Black;
        public static Color ColorX { get; set; } = Color.Black;
        public static Color ColorO { get; set; } = Color.Black;
        /// <summary>
        /// Current game board
        /// </summary>
        public char[,] Board { get; set; }
        /// <summary>
        /// Is X's turn
        /// </summary>
        public bool XTurn { get; set; }
        /// <summary>
        /// Stores objects from PlayX and PlayO classes (used for drawing)
        /// </summary>
        public List<IPlay> Plays { get; set; }
        /// <summary>
        /// Winner of the game
        /// Possible values: 'X', 'O' and 'T' for tie
        /// </summary>
        public char Winner { get; set; }
        /// <summary>
        /// Is the game mode player vs player
        /// </summary>
        public bool PVP { get; set; }
        /// <summary>
        /// Is AI playing as X
        /// </summary>
        public bool AIFirstMove { get; set; }
        /// <summary>
        /// Is the game over
        /// </summary>
        public bool Over { get; set; }
        /// <summary>
        /// Stores an object (PlayX or PlayO)
        /// Used for drawing on a hovered square (if it's available)
        /// </summary>
        public IPlay Hovered { get; set; }
        /// <summary>
        /// Difficulty of the game
        /// 1 - Easy, 2 - Medium, 3 - Hard
        /// </summary>
        public int Difficullty { get; set; }
        
        private char player1 = 'X';
        private char player2 = 'O';
        /// <summary>
        /// scores used in Minimax (assuming AI is playing as O, if AI is playing as X scoreX=10, scoreO=-10)
        /// </summary>
        private float scoreX = -10;
        private float scoreO = 10;
        private float scoreTie = 0;
        /// <summary>
        /// used in Minimax to generate random depth (for medium difficulty only)
        /// </summary>
        private static Random random = new Random();
    }  
```

+ Класите кои се задолжени за цртање на направените потези се `public class PlayX` и `public class PlayO`. Овие класи го имплементираат интерфејсот `public interface IPlay`.

+ `public class Score` класата се користи за чување на моменталниот резултат и за имињата на играчите.

#### Функции

+ `AddPlay(int x, int y);` Функција со која се додава потег. Функцијата се повикува при клик на главната форма и како аргументи ги прима координатите на кликот. 

+ `WinCheck();` Функција со која се врши проверка дали играта е завршена и дали има победник.

+ `RandomMove();` Функција за генерирање на random потег од страна на компјутерот. Се користи за имплементација на Easy difficulty.

+ `AIMove();` Функција за одредување на потег од страна на компјутерот со помош на Minimax алгоритамот. Се користи за имплементација на Medium и Hard difficulty.

+ `Minimax(char[,] board, int depth, bool isMaximizing, float alpha, float beta);` Функција со која е имплементиран алгоритамот [Minimax with Alpha-beta pruning](https://en.wikipedia.org/wiki/Alpha%E2%80%93beta_pruning). Се користи за одредување на најдобриот можен потег од страна на компјутерот кога нивото на тежина е Hard. Алгоритамот е модифициран и не секогаш го одредува најдобриот потег кога играта е со Medium difficulty.


