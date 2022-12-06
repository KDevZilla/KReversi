# KReversi


![Game](https://github.com/KDevZilla/ImageUpload/blob/main/KReversi/001.png)  
Select player and map  

![Game](https://github.com/KDevZilla/ImageUpload/blob/main/KReversi/000_Main_KReversi.png)  
Main game.  


![Game](https://github.com/KDevZilla/ImageUpload/blob/main/KReversi/Create_Bot.png)  
Create bot feature.  

For Developer please look at these articles.
The contents are the same, I just posted them 2 places.
https://www.codeproject.com/Articles/5348843/KReversi-Learn-to-Implement-Minimax-Algorithm-by-C  
https://github.com/KDevZilla/ArticlesPublic/blob/main/KReversi.md  

# Features 
1. Support Mode Human vs Human, Human vs Bot, Bot vs Bot.
2. Support board editor. 
3. Support Bot creator. You can choose an image and customize an AI score
		that will be used to evaluate the board.
		
4. Can show the bot's last move Minimax search tree.
5. Can change the profile picture of Human Player1 and Human Player2
6. Can navigate the move.
7. Support Dark Mode.

## File Extensions used by the program.
1. .brd is used as board information.
2. .bot is used as bot information. 
3. .rev is used as game save information, Game information retains the history of the move,   
which is what distinguishes it from a board game, so you can navigate it via the navigate control.

## How to play ##
The rule of the game is exactly the same as a normal Reversi game.

## How to setup a project
1. Just download a project, it is just a small program written in C# Windows Form.
2. There are 2 projects
      KReversi: This is the main project
      KReversiUnitTest: This it the test project

3. The nesecially file already being configured as "Copy to Output Directory" so you no need to manually 
copy or configure anything, jut run the program
4. For testing the project, you can just run The test cases in in all of test class in KReversiUnitTest project.
