# Exam Summary
  Create a mobile Slot Machine app and project.

  References:
  
  - Google Play: [Double Win Vegas](https://play.google.com/store/apps/details?id=ppl.unity.cubeslots&hl=en)
  - App Store: [Double Win Vegas](https://apps.apple.com/us/app/double-win-vegas-casino-slots/id1056430196)

  Play the app in the references to get an idea on how a digital slotmachine works.
  
## Requirements
  
### Software
  
  - Create a slot machine app using Unity 2020 or later.
  - Put your Unity project on github.com (include apk build).
  - Create a README.md on your git.
   
## Slot Machine Details
    
**Slot Machine Specs**
    
  - Size: 5 reels, 3 rows
  - Payout lines: 20 
  
**UI Specs**

- Spin button
- Bet display and controls >> (-) BET AMOUNT (+)
- Spin result display 
- Player coin balance display
- Info button that triggers a popup showing line payouts

**Basic UI Layout**
	
	| Player Coins:                                                   |
	|        | Reel 1  |  Reel 2 |  Reel 3 |  Reel 4 |  Reel 5 |      |
	|        | Reel 1  |  Reel 2 |  Reel 3 |  Reel 4 |  Reel 5 |      |
	|        | Reel 1  |  Reel 2 |  Reel 3 |  Reel 4 |  Reel 5 |      |
	|                                                                 |
	|  (-) Total Bet (+)        |   winnings   |         (spin button)| 
	
- Player Coins shows the current balance of the player. Note that the player must not be able to spin if his/her balance is below Total Bet value.
- Total Bet = bet value * lines
	-  A bet of 1 with 20 lines has a Total Bet = 20
	-  A bet of 100 has a Total Bet = 2000
-  Sum of winnings obtained per spin. This resets to 0 on new spins.
-  Spin Button can start a spin when idle or trigger a stop during spins.


**Symbols**

- Symbol data must have and id and payouts for combinations of (3,4, and 5 streaks)

		eg.
		Sample payouts:
			symbol "A" has payout 1 (3 symbols), 5 (4 symbols), 10 (5 symbols)
		   	symbol "B" has payout 2 (3 symbols), 8 (4 symbols), 25 (5 symbols)
		Sample Results:
		   	result "A, A, A, B, C", payout is 1 (due to 3 A symbols)
		   	result "B, B, B, B, A", payout is 8 (due to 4 B symbols)
		Sample Data: 
			{ id: 0, name: "A", payout: [0,0,1,5,10]}
			{ id: 1, name: "B", payout: [0,0,2,8,25]}
              
              
**Lines**

- Lines are coordinates on the visible reel symbols.
- Given a reel result matrix of symbols:  spinResult[row][reels], 
        the line would contain coordinates: line[rows]
        
		eg.
		  spinResult[3][5]
		      "A, A, A, B, C"
		      "B, A, C, F, G"
		      "A, G, B, D, E"
		      
		  Sample lines:
		      line_1 {0,0,0,0,0} = "A,G,B,D,E", line_1 result: {symbol="A",count=1,payout=0} 
		      line_2 {1,1,1,1,1} = "B,A,C,F,G", line_2 result: {symbol="B",count=1,payout=0}
		      line_3 {2,2,2,2,2} = "A,A,A,B,C", line_3 result: {symbol="A",count=3,payout=1}
		      line_4 {0,1,2,1,0} = "A,A,A,F,E", line_4 result: {symbol="A",count=3,payout=1}
		      
		  Sample total result for 4 lines:
		      total payout = 2
  - NOTE: Exam requires 20 lines. Create your own line combinations for matching symbols from left to right.
      
**Reels**

  - The machine must have 5 reels.
  - Each reel will have its own data list of symbols.
  - Reel data should be replaceable.
  - Reel game objects must be able to handle spin animations for its symbols.
      
**Reel Spin**

- First spin button click starts the reel spin animations.
- Spin button clicks while the reel is spinning must trigger the reels to stop. 
- When stopped, reel symbols must end up in proper alignment (3 rows = 3 visible symbols per reel, properly centered)

**Spin Result Setup**

- Simple:
	- The results are based on the centered symbols when the reel spin stops. 
- Advanced:
	- Before spinning, symbols may be targetted (randomly) as results.
	- These targets will be the center symbols when the reel stops. 
	- During spin wind up, the system can calculate the spins to take and where to stop.
        
**Result Sample**
 
  	Given a 5 reel machine, each reel with 10 symbols. 
  	The symbol targets would be within a range of 0-9
  	
  	example: 
  	targets {0,2,8,2,0}
  	Reel1: stop on 1st symbol
  	Reel2: stop on 3rd symbol
  	Reel3: stop on 9th symbol
  	Reel4: stop on 3rd symbol
  	Reel5: stop on 1st symbol
  	
  	Result matrix:
  	             reel 1   reel 2  reel 3   reel 4  reel 5
  	          --------------------------------------------- 
  	row 2     |    1        3        9       3       1    |
  	row 1     |    0        2        8       2       0    |
  	row 0     |    9        1        7       1       9    |
  	          --------------------------------------------- 
          
          
### Firebase Remote Config (Bonus)
- Use a third party service for controllable online data. 
- Suggested service: 
	- Firebase Remote Config 
	- https://firebase.google.com/docs/remote-config
- Required accessible data on your remote service:
    - Reel data (list of symbol ids per reel)
    - Symbol Payout data (payouts for each symbol)
    - Line data (line coordinates)
    - Machine max lines (how many lines will be used by the machine)
- Use json as your data format.
      
        
### Documentation
- Unity version used.
- System setup (main classes, controllers, objects)
- List of data sources and how to edit them
- Additional notes:
    
    - Discuss Scalability of system
    - Discuss Flexibility of the system
    - Discuss your use of MVC in the project
    - What are the possible future improvements of your project
          
### Assets 
- You may use the assets provided in the zip.          
- You may also use code from your own personal libraries.

### Deliverables
- Your github link "github.com/(name)/anino_exam" with the following contents:
    - Unity project
    - README.md
    - builds/slotmachine.apk
- Your remote config link, add carl.j@anino.co as a member.


*Good luck!*

   
      
      
**Author**

- Carl Joven (carl.j@anino.co), Lead Software Engr.