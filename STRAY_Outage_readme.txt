STRAY - Outage:
- Austin Lindquist: austin.lindquist@gatech.edu
- Roger Lee: rlee311@gatech.edu
- Yeajin Shin: yshin89@gatech.edu
- Tamara Kunter: tkunter3@gatech.edu

Starting Scene: StartMenu.unity

Overview: You are a space engineer who is running out of battery and needs to make an emergency visit at an
		abandoned space station to fuel up on Power Banks (4). However, something seems off with the station and 
		you want to get in and out as soon as possible. 
		Goal: pick up the 4 Power Banks and make it back to your ship (starting zone) alive.

How to Play:
	- Movement: WASD
	- Camera: Mouse 
	- Interact: E key
	- Run: hold Shift key
	- Pause: Esc key (Tab to Quit application)

Observations:
	- Wandering AI Aliens; obeserve mannerism based on player proximity and footsteps
	- Doors/Key system (Red, Green, and Cyan doors + keys)
	- Randomized Power Bank locations each iteration
	- The aesthetics of the entire projects (audio, visuals, gamefeel, esc).

Known Problem Areas: 
	- Sometimes AI collide with one another, causing them to sometimes get stuck

Manifest:
	- Austin: (Game Prefabs/Items) AI, Player, Alien/Ghoul, Power Banks, custom audio clips -> GhoulController.cs, PlayerController.cs, FieldOfView.cs, StartingZone.cs, Enemy.cs, Billboard.cs, 
	- Roger: (Game Prefabs/Items) All game scenes, Physical Game Map, Doors, Keycards, Game State Manager -> GameStateManager.cs, DoorKey.cs, DoorOpener.cs
	- Yeajin: (Game Prefabs/Items) Power Bank UI, Player Inventory, All Game State UI -> PBUI.cs, InventoryDisplay.cs, InventorySlot_UI.cs, StaticInventoryDisplay.cs, InventoryItemData.cs, InventoryHolder.cs, InventorySLot.cs, InventorySystem.cs, TextFadeOut.cs
	- Tamara: All audio for the game, Randomized Power Bank Supplies, Randomized Power Bank Locations -> PowerBankManager.cs
	* Sania: brainstorming and asset finding (has dropped the course)


***Of course, please let me know if the OSX build doesn't work; I don't have a Mac to test it :< 
