# Pacman-Tunado

Este projeto é um protótipo não finalizado de uma releitura que eu estava fazendo do Pacman.
Com o codinome Pacman-Tunado, a ideia era refazer o clássico arcade porém com mais features.

## Novas Features
Algumas das ideias que tive era do personagem principal na verdade ser um caça-fantasmas, e dessa forma ao invés de termos o power-up que permitia o jogador comer o fantasma,
nos teríamos baterias para a arma contra fantasmas. Arma essa que seria como uma espécie de aspirador. O jogador iria mirar no fantasma e segurar espaço até que este fosse totalmente sugado para a mochila.

A ideia era que para sugar fantasmas demorava alguns segundos e só dava para sugar um de cada vez, portanto o jogador deveria tomar cuidado pois enquanto ele estivesse lidando com um inimigo, outros viriam por todos
os outros lados para encurralá-lo.

Como eu disse anteriormente, o protótipo nunca foi finalizado. Porém eu desenvolvi toda a parte que remete ao jogo clássico, desde a movimentação do jogador até a IA dos fantasmas.

# O que eu aprendi
Durante o desenvolvimento desse projeto, eu me envolvi com alguns assuntos que na época ainda não me eram tão familiares quanto hoje. 

## A*
Para a movimentação dos inimigos, eu precisava de um algoritmo de pathfinding bom e eficiente, visto que seriam diversos inimigos todos eles utilizando o mesmo algoritmo ao mesmo tempo.
Após muita pesquisa, escolhi o A*, que é provavelmente o algoritmo de busca mais utilizado no desenvolvimento de jogos.
Sua implementação foi bem divertida e aprendi bastante sobre algoritmos.

## Arquitetura e testes

Se hoje em dia eu sou uma pessoa que preza muito por arquitetura de software e testes automatizado, o Pacman-Tunado possui grande parte da culpa.
Esse foi o primeiro projeto em que eu estudei e tomei cuidado com tais assuntos.

Um padrão que utilizei muito foi o Humble Pattern, que facilitou demais a escrever testes.

