TheBall
=======

Предмет на оваа семинарска работа е создавање на апликацијата The Ball. Самата апликација се состои од три едноставни игри Flappy Ball, Fall Ball и Catch Ball. Идејата за првата игра, Flappy Ball, е земена од  добро познатата Андроид верзија на оваа игра, Flappy Bird. Во втората игра, Fall Ball, треба топчето да се движи надолу низ лавиринт од препреки (полици) и што е можно подолго да се игра без да допри на горниот ѕид. Во третата игра, Catch Ball, целта е да се фатат што е можно повеќе од топчињата кои паѓаат.

=======

Почетното мени содржи форма во која што има три копчиња за одбирање на една од игрите која што ќе се игра. 

![Form1](http://i.imgur.com/ulADcqb.png)

При избор на игра се отвара менито на избраната игра. Во мениот на секоја од игрите има копче за почеток на играта (Start Game), копче за преглед на најдобрите играчи (High Scores), копче за помош како се игра избраната игра (How To Play) и копче за исклучување на играта (Exit Game). 

=======

#### FALL BALL
Освен веќе спомнатите копчиња, играта Fall Ball има можност и за одбирање на тежина на играта, односно три нивоа: Easy, Medium и Hard.

![Menu](http://i.imgur.com/48CKDu2.png)

Со притискање на копчето за почеток на играта се отвара нова форма во која што започнува играта. На горниот дел од формата се прикажува освоените поени, кои се зголемуваат секоја секунда за еден плус. Колку подолго се игра играта без губење толку повеќе поени се добиваат. Движењето на топчето и на полиците е направено во следниот код: 

	private void timer1_Tick(object sender, EventArgs e)
        {
            if (!pause)
            {
                if (!ball.endGame())
                {
                    bool polica = true;
                    intervalScore++;
                    if (intervalScore == 50)
                    {
                        intervalScore = 0;
                        Score++;
                    }
                    for (int i = 0; i < shelfList.Count(); i++)
                    {
                        if (i % 2 == 0)
                            shelfList[i].Move(3, heigh, shelfList[i].width, shelfList[i].x);
                        else
                            shelfList[i].Move(3, heigh, width - shelfList[i - 1].width - 50, shelfList[i - 1].width + 50);
                        if (ball.naPolica(shelfList[i]) && polica)
                        {
                            t = i;
                            polica = false;
                            ball.Move(5, width, heigh, left, right, shelfList[i]);
                        }

                    }
                    if (polica)
                    {
                        if (t % 2 != 0)
                            ball.Move(5, width, heigh, left, right, shelfList[t - 1]);
                        else
                            ball.Move(5, width, heigh, left, right, shelfList[t + 1]);

                    }
                    label2.Text = Score.ToString();
                    panel1.Invalidate(kvadrat, true);
                }
                else
                {
                    endGame();
                }
            }
            else
            {
                timer1.Stop();
            }
        }

Најпрво се прави проверка дали е притиснато копчето за пауза, ако е притиснато и играта не е паузирана, тогаш се паузира, а ако е веќе паузирана играта тогаш се продолжува со игра. Потоа се проверува дали играта е завршена. Играта завршува во онај момент кога топчето ќе го допри горниот ѕид. Ако играта е завршена се повикува функцијата endGame(), ако не е завршена се прави движењето на топчето и на сите полици во наредниот момент. Се прават проверки дали топчето е на некоја полица или не е и во зависност од тоа топчето прави различно движење, додека полиците постојано се движат нагоре. Во самата функција за движење на полиците е реализирано создавањето на нов пар полици кога ќе излезат од екранот со рандом должини.
Кога ќе се изгуби, се отвара нова форма во која треба да се внеси име на играчот за да се запиши неговиот резултат. Резултатот на играчот ќе биде запишан во High Scores само ако е помеѓу првите петнаесет. 

![](http://i.imgur.com/jSFZK2e.png)

Ако се притисни копчето Play Again, играта се игра повторно, а ако се притисне копчето Exit Game играта се исклучува.
Со притискање на копчето High Scores од почетното мени, се отвара нова форма во која се прикажуваат петнаесетте највисоки резултати. Резултатите се запишуваат во посебна .txt датотека за секоја игра и за секое ниво и потоа се читаат од нив. Формите за внесување име при завршување на игра и за прегледување на најдобрите играчи се користат во сите три игри. 

![](http://i.imgur.com/wEUzgT2.png)

Со притискање на копчето How To Play се отвара MessageBox во кој што се напишани правилата на играта, копчиња за играње и начин на играње. 

![](http://i.imgur.com/VYpRVTC.png)

=======

###FLAPPY BALL

Со стартување на играта Flappy Ball се отвара мени слично на претходната игра. Со притискање на копчето Start Game, се отвара нова форма и започнува играта. 

Изглед на играта:

![](http://i.imgur.com/Ks4VSvN.png)

Функција со која што се иницијализира почетната состојба на играта, и која се повикува при почеток на нова игра. 

	public void newGame()
        {
            exitGameBtn = true;
            timeStart = 3;
            timer1.Start();
            lblTimeStart.Visible = true;
            lblgameStartin.Visible = true;
            Score = 0;
            upWalls = new List<Wall>();
            downWalls = new List<Wall>();
            playersScore = new List<Player>();
            ball = new Ball(250, 200);
            wall = new Wall(600, 0, 200);
            upWalls.Add(wall);
            wall = new Wall(600, 325, this.Height - 65 - 200);
            downWalls.Add(wall);

            wall = new Wall(750, 0, 100);
            upWalls.Add(wall);
            wall = new Wall(750, 225, this.Height - 65 - 100);
            downWalls.Add(wall);

            wall = new Wall(900, 0, 220);
            upWalls.Add(wall);
            wall = new Wall(900, 345, this.Height - 65 - 220);
            downWalls.Add(wall);

            wall = new Wall(1050, 0, 80);
            upWalls.Add(wall);
            wall = new Wall(1050, 205, this.Height - 65 - 80);
            downWalls.Add(wall);
        }
Останатите копчиња од менито на играта ја имаат истата функционалност како и копчињата на претходната игра.

=======

###CATCH BALL

Со стартување на играта Catch Ball се отвара мени слично на претходната игра. Со притискање на копчето Start Game, се отвара нова форма и започнува играта. Целта на оваа игра е фаќање на што е можно повеќе топчиња кои паѓаат. Притоа играта завршува ако не бидат фатени пет топчиња. Едно топче е фатено ако влезе во средината од кошот. 
 
![](http://i.imgur.com/0p6J0UR.png)

За оваа и за останатите игри се користи функција writeFile() која што ги подредува резултатите на играчите и ги запишува во точната датотека само оние најдобри петнаесет.

	private void writeFile()
        {
            playersScore = playersScore.OrderByDescending(x => x.Score).ToList();
            int pom = 0;
            if (playersScore.Count >= 15) { pom = 15; }
            else pom = playersScore.Count;
            for (int i = 0; i < pom; i++)
            {
                sw.WriteLine(String.Format("{0},{1}", playersScore[i].Name, playersScore[i].Score));
            }
        }

=======

За реализацијата на играта се имплементирани 6 класи (Ball, BallCollection, Basket, Player, Shelf, Wall) и 9 форми (CatchBall, CatchStart, EndGame, FallBall, FallScores, FallStart, FlappyBall, FlappyStart, Form1).
Се надеваме дека ќе ви се допаднат сите три игри и ви посакуваме пријатна игра! 

