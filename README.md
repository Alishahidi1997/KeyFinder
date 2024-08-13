# KeyFinder

 ## Demo
![](https://github.com/Alishahidi1997/KeyFinder/blob/main/Assets/Demo.gif)

## Design Approach
### Classes
#### Map Generation
A class for keeping the map in a 2D list and update the map changes. 

A class to create the map and instantiate the objects based on this list to generate the map dynamically.

A class for choosing the map from the saved file or download it from a random URL. 

#### Saving and Loading Mechanism
A class to save the check point everytime the user finds a new key.

A class for loading the map from the last checkpoint. 

#### Player Control
A class for controlling the player movement. 

A class for handling the score based on the collider in the objects. 


## Design Approach

## Player Control and Solving the puzzle
You can control the player using the arrow keys or WASD, and look around by dragging the mouse.

Player Tip: A mini-map is located in the bottom right corner of the screen, showing key locations.

Mini-Map Details: Orange spheres indicate key locations, the purple cube marks the door, and the red arrow shows the player's position and direction.

Save Feature: The game automatically saves when a key is found. If the player exits the game, they can resume from the last checkpoint when they start it again.

## Details on how to compile and run the project.
After downloading the project, be sure to download the Avatar.fbx file before opening it. Place the Avatar file in the \Assets\Avatar\Avatar directory. Once done, you can open the project in Unity and enjoy it.
