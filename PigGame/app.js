/*
GAME RULES:

- The game has 2 players, playing in rounds
- In each turn, a player rolls a dice as many times as he whishes. Each result get added to his ROUND score
- BUT, if the player rolls a 1, all his ROUND score gets lost. After that, it's the next player's turn
- The player can choose to 'Hold', which means that his ROUND score gets added to his GLBAL score. After that, it's the next player's turn
- The first player to reach 100 points on GLOBAL score wins the game

*/
//it is cleaner to declare all variables up here. 
var scores, roundScore, activePlayer, gamePlaying;
init(); 
//math.random picks a random number between 0 and 1, when we multiple by six it gives us a random number between 0 and 5.
//math.floor takes the decimal value away, then we add 1 becuase there is not a zero on the dice and that gives us a random
//value between 1 and 6
//the # selects id's from css
//activeplayer will set the current to 0 or 1
document.querySelector('.btn-roll').addEventListener('click', function() {
    if(gamePlaying){ 
        // 1. random number
        var dice= Math.floor(Math.random()* 6)+1;
        // 2. Display result
        var diceDom =  document.querySelector('.dice');
        diceDom.style.display= 'block';
        diceDom.src= 'dice-' + dice + '.png'

            //3. update round score only IF rolled number was not a 1
            if(dice !== 1){
            //add score
                roundScore += dice;
                document.querySelector('#current-' + activePlayer).textContent = roundScore;
            }
            else { 
                nextPlayer();
            }


    }
   

});
document.querySelector('.btn-hold').addEventListener('click', function(){
    if(gamePlaying){
        //1. add current score to global score
    scores[activePlayer] += roundScore;
    //2. update ui
    document.querySelector('#score-' + activePlayer).textContent = scores[activePlayer];    

    //3. check if player won the game
    if(scores[activePlayer] >=100)
    {
        document.querySelector('#name-' + activePlayer).textContent = 'Winner!';
        document.querySelector('.player-' + activePlayer + '-panel').classList.add('winner');
        document.querySelector('.player-' + activePlayer + '-panel').classList.remove('active');
        gamePlaying=false;
    }
    else{
        nextPlayer();
    } 

    }
     
    

})


function nextPlayer(){
    //next player
        //this is a turnary operator and is the same as an if else statement
        activePlayer === 0 ? activePlayer=1 : activePlayer=0;
        //set round score back to zero
        roundScore=0;

        document.getElementById('current-0').textContent='0';
        document.getElementById('current-1').textContent='0';
        //this removes the active from the html file
        //Instead of add/remove we use toggle to swith back an forth
        document.querySelector('.player-0-panel').classList.toggle('active');
        document.querySelector('.player-1-panel').classList.toggle('active');
        //document.querySelector('.player-0-panel').classList.remove('active');
        //document.querySelector('.player-1-panel').classList.add('active');

        //document.querySelector('.dice').style.display = 'none'; I took this out becuase I did not
        //like the dice disappearing when a 1 was rolled 
}

document.querySelector('.btn-new').addEventListener('click', init);


 function init(){
    scores= [0,0];
    roundScore=0;
    activePlayer=0;  //this calls the player from the zero based array, that is why we use player 0 and player 1
    //the . selects classes from css
    gamePlaying=true;

    document.querySelector('.dice').style.display= 'none';
    

    //this is faster than querySelector

    document.getElementById('score-0').textContent = '0';
    document.getElementById('score-1').textContent = '0';
    document.getElementById('current-0').textContent = '0';
    document.getElementById('current-1').textContent = '0';
    document.getElementById('name-0' ).textContent = 'Player1';
    document.getElementById('name-1' ).textContent = 'Player2';
    document.querySelector('.player-0-panel').classList.remove('winner');
    document.querySelector('.player-1-panel').classList.remove('winner');
    document.querySelector('.player-0-panel').classList.remove('active');
    document.querySelector('.player-1-panel').classList.remove('active');
    document.querySelector('.player-0-panel').classList.add('active');

 }
