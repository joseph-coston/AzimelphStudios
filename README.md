# AzimelphStudios
CSE389 Project Repository

Our Game is still in heavy development. The progress currently made allows for a brief amount of play and 
experimentation. However there objectives and enemies layed out serve only for development and debugging.

The option available to the player is movement in a 3d environment. 
The player can currently play with several different weapons, and find a series of prototype pickups in the game 
world. Each pickup prototype can change attributes of gameplay. Accuracy Pickups decrease the spread angle 
of spells cast from the wand. Speed pickups increase the maximum player velocity on both ground and air. These 
pickups are only prototypes as they do not reflect what was intended to appear in the actual finished game.

The environment was supposed to include obstacles, like hills bushes and rocks, but our terrain was never finished.
Right now there is only a basic terain mesh that needs major tweaking before it will be ready for the final game. 
The player is able to navigate the game world using standard WASD movement controls and mouse controlled camera and 
spellcasting. The game world is dark, and the skybox is set to a starry sky, both to give an impression of night time
to the game world. Player lighting is controlled by a point source attached to the wands and a connected script to 
correlate the player's mana level to the aparent intensity of ilumination. This is meant to allow the player to see
what is around them in their immediate vicinity while casting things further off in darkness and shadow. The 
mana-related light intensity is meant as a deterrant against the player needlessly casting spells for fear of being 
lost in the dark.

The player has a health bar to keep track of their life. If enemies were functional, they would deal damage 
when a certain distance from the player, reducing the life total for each hit. As the game stands, there are some 
prefab enemy robots to test weapons and enemy behaviors with; these enemies are not intended to be the final enemies 
implemented in the finished game. The player can cast magicspells using one of four current wands with differing 
VFX and damage characteristics. For instance, the Firebolt wand can be charged up to cast a much stronger spell
at the cost of more mana, but may backfire and injure the player in close combat with it's area of effect on impact;
on the other hand the Lightningbolt wand can be used continuously for a long time and deals moderate to severe damage 
quite rapidly, but its accuracy and range are the lowest out of all the wands, making it more suitable for those who
prefer close combat fighting styles. Casting magic drains mana, represented by a blue bar. This bar will slowly refill
when not using the wand, but the rate of mana regeneration and the delay after firing before regenration begins varies 
from wand to wand. 

Another important game feature to note are the Mushroom Trees. Depending on their color, some emit light and have a 
falling spore type effect. Those with such effects also have persistant fields of effect beneath them that either 
deal the player and enemies damage or replenish health. These mushroom trees were originally intended to be scattered 
around the map, either in groves or standing alone, to provide the player with an interesting terrain based environmental 
hazard/support fearue for encouraging imergent strategization. Maybe, the player could attempt to lead enemies into the 
harmful fungi, or possibly try to defend a position around the beneficial kind?


"Production 2"

Many features originally intended for the game have not been implemented. Due to the major changes in the work 
environment, mainly as an effect of the quarantine, the following features are either incomplete or missing entirely.

Enemies have not been fully finalized. Enemies have a sprites and some movement and characteristics, but are 
built on a pre-existing prefabs. Thus not all functionalities are to the expectations of a fantasy horror game. 

The objective of the game is still unfinished. The seven totem like artifacts have not been coded or modeled, 
so there is no current end state for the game. 

The terrain was never completed, nor were enemies populated on the map, so the player cannot really play the game.

Overall, the game is in an unfinished state due to unforeseen circumstances. Many of the core features and 
aspects have been fully or partially realized.


