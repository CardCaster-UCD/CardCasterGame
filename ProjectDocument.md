# Game Basic Information #

## Summary ##

**A paragraph-length pitch for your game.**

## Gameplay Explanation ##

**In this section, explain how the game should be played. Treat this as a manual within a game. It is encouraged to explain the button mappings and the most optimal gameplay strategy.**

The player can move around the map using the arrow keys, swing the sword using the space bar, and cast the spells on the cards using the 1, 2, 3 keys. 

**If you did work that should be factored in to your grade that does not fit easily into the proscribed roles, add it here! Please include links to resources and descriptions of game-related material that does not fit into roles here.**

# Main Roles #

* Puzzle : Grant Gilson, Alexis
* World  : Jeehoon Kim, Emily Liu
* Combat : Elios Sgouros, Julio Flores, Gian Carlo Lambert

You should replay any **bold text** with your relevant information. Liberally use the template when necessary and appropriate.

## Combat Team


## World Team

Tilemaps

Sources: https://www.mapeditor.org/, https://seanba.com/supertiled2unity.html
Maps: 

StartMenu \
Background image credit: Milksoft Games \
Source: https://milksoftgames.itch.io/grassy-field \
[scene](https://github.com/GMGilsonECS-UCD/ECS189L/blob/master/Assets/Scenes/StartMenu.unity) \
[script](https://github.com/GMGilsonECS-UCD/ECS189L/blob/master/Assets/Scripts/Menu.cs) 




## Puzzle Team
The main focus of the puzzle team was to coordinate between world and combat teams to create implement features in the world for players to interact with. This keep kept us integrated in many aspect of the game's design like movement/physics and animation/visuals through interactables like:
* vector effector plates (river tiles)
* torches


Our main puzzle map layout is 2 vertical and 3 horizontal river streams. These streams apply force to the player when entering the stream to move the player down stream in the direction of the current. The currents' speed is set to mvoe the player at a speed where they should not be able to reach the other side without something to block their path. Interactable torches are placed around the map to toggle the elevation of rocks that will block the player's path as they flow downstream. 
![](./Docs/images/cave.png)

The river streams are implemented as Unity effectors tieing these gameplay elements tightly to the standard physics engine of Unity. These effectors apply a velocty vector to objects that collide with them.

![](./Docs/images/swimming.gif)

The interactable torches are ignited when hit by any fire type spell and extinguished when hit by a wind type spell. These torches implement a [Publisher/Subscriber](https://github.com/CardCaster-UCD/CardCasterGame/blob/ea08a3673cb4325d2029ab6905b16ba98688e8a3/Assets/Scripts/TorchController.cs#L95) pattern similiar to the Pikimi assignment in week 4. In the case of the example gif, the subscriber is the fade in/out animation of a rock sprite in the river. These torches were implemented with this pattern in mind for future resuse of scripts and prefabs in later areas of the map.
![](./Docs/images/torch.gif)

**Ref**
* [torches assets](https://asymmetric.itch.io/mideval-2d-16x16-torch-sprite-pack-with-animations)
* 

--- original roles ---
## User Interface

**Describe your user interface and how it relates to gameplay. This can be done via the template.**

## Movement/Physics

**Describe the basics of movement and physics in your game. Is it the standard physics model? What did you change or modify? Did you make your movement scripts that do not use the physics system?**
## Animation and Visuals

**List your assets including their sources and licenses.**

**Describe how your work intersects with game feel, graphic design, and world-building. Include your visual style guide if one exists.**

## Input

**Describe the default input configuration.**

**Add an entry for each platform or input style your project supports.**

## Game Logic

**Document what game states and game data you managed and what design patterns you used to complete your task.**

# Sub-Roles

## Audio
**List your assets including their sources and licenses.**

**Describe the implementation of your audio system.**

**Document the sound style.** 

Emily:
### OpeningScene audio:  
Source: Enchanted by Keys of Moon | https://soundcloud.com/keysofmoon
Music promoted by https://www.chosic.com/free-music/all/

License: Creative Commons CC BY 4.0
https://creativecommons.org/licenses/by/4.0/

### Fireball spell audio:
Source: https://soundbible.com/1356-Flame-Arrow.html

License: Attribution 3.0

### FireBlast spell audio:
Source: https://soundbible.com/1135-Torch.html

License: Attribution 3.0

### WindBlast spell audio:
Source: https://soundbible.com/1247-Wind.html

License: Attribution 3.0

### Speedup spell audio:
Source: https://soundbible.com/1636-Power-Up-Ray.html

License: Attribution 3.0



## Gameplay Testing

**Add a link to the full results of your gameplay tests.**

**Summarize the key findings from your gameplay tests.**

## Narrative Design

**Document how the narrative is present in the game via assets, gameplay systems, and gameplay.** 

## Press Kit and Trailer

**Include links to your presskit materials and trailer.**

**Describe how you showcased your work. How did you choose what to show in the trailer? Why did you choose your screenshots?**


## Cross-Platform
Card caster currently builds for Window/MacOS/Linux in standalone executables and WebGL. Consideration was made for user controls for Android and iOS builds of the game but due to time constraints, direct mappings of the touch interface to controlls are not availiable to the mobile versions of the game at this time. However, builds of the game do exists for iOS and Android, but without the aid of a keyboard, will be unplayable. 

Builds are generated automitically on push events to the Card Caster repository through the [Game.ci](https://game.ci/) project.


## Game Feel

**Document what you added to and how you tweaked your game to improve its game feel.**
